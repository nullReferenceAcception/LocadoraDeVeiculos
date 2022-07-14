using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using Taikandi;

namespace LocadoraDeVeiculos.Servico.Compartilhado
{
    public abstract class ServicoBase<T, TValidador>
        where T : EntidadeBase<T>
        where TValidador : AbstractValidator<T>
    {
        TValidador validador;
        IRepositorio<T> repositorio;

        public ServicoBase(AbstractValidator<T> validationRules, IRepositorio<T> repositorio)
        {
            this.validador = (TValidador)validationRules;
            this.repositorio = repositorio;
        }

        public virtual Result<T> Inserir(T registro)
        {
            registro.Guid = SequentialGuid.NewGuid();

            Log.Logger.Debug("Inserindo: {nome}", typeof(T).Name);

            Result resultadoValidacao = ValidarRegistro(registro);

            if (resultadoValidacao.IsFailed)
            {
                LogFalha("Inserir", registro, resultadoValidacao.Errors);
                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorio.Inserir(registro);
                Log.Logger.Debug("Inserido: {@registro}", JsonConvert.SerializeObject(registro, Formatting.Indented));
                return Result.Ok(registro);
            }
            catch (Exception ex)
            {
                string mensagem = "Falha no sistema ao tentar inserir ";
                Log.Logger.Error(ex, mensagem + "{nome}" + registro.Guid, typeof(T).Name);
                return Result.Fail(mensagem);
            }
        }

        public virtual Result<T> Editar(T registro)
        {
            Log.Logger.Debug("Editando: {nome} - ID: {guid}", typeof(T).Name, registro.Guid);

            Result resultadoValidacao = ValidarRegistro(registro);

            if (resultadoValidacao.IsFailed)
            {
                LogFalha("Editar", registro, resultadoValidacao.Errors);
                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorio.Editar(registro);
                Log.Logger.Debug("Editado: {@registro}", JsonConvert.SerializeObject(registro, Formatting.Indented));
                return Result.Ok(registro);
            }
            catch (Exception ex)
            {
                string mensagem = "Falha no sistema ao tentar editar ";
                Log.Logger.Error(ex, mensagem + "{nome}" + registro.Guid, typeof(T).Name);
                return Result.Fail(mensagem);
            }
        }

        public Result Excluir(T registro)
        {
            Log.Logger.Debug("Excluindo: {classe}", typeof(T).Name);

            try
            {
                repositorio.Excluir(registro);

                Log.Logger.Debug("Excluido: {@registro}", JsonConvert.SerializeObject(registro, Formatting.Indented));

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o ";

                Log.Logger.Error(ex, msgErro + "{classe}" + "{Guid}", typeof(T).Name, registro.Guid);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<T>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorio.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = $"Falha no sistema ao tentar selecionar todos os ";

                Log.Logger.Error(ex, msgErro + "{classe}", typeof(T).Name + "s");

                return Result.Fail(msgErro);
            }
        }

        public Result<T> SelecionarPorGuid(Guid guid)
        {
            try
            {
                return Result.Ok(repositorio.SelecionarPorGuid(guid));
            }
            catch (Exception ex)
            {
                string msgErro = $"Falha no sistema ao tentar selecionar o ";

                Log.Logger.Error(ex, msgErro + "{classe}  + {Guid}", typeof(T).Name, guid );

                return Result.Fail(msgErro);
            }
        }

        public Result<int> QuantidadeRegistro()
        {
            try
            {
                return Result.Ok(repositorio.QuantidadeRegistros());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao pegar quantidade de ";

                Log.Logger.Error(ex, msgErro + "{classe}", typeof(T).Name);
                return Result.Fail(msgErro);
            }
        }

        protected abstract string SqlMensagemDeErroSeTiverDuplicidade { get; }

        protected virtual bool HaDuplicidade(T registro)
        {
            if (TiverDuplicidade(registro))
                return true;
            return false;
        }

        private void LogFalha(string funcao, T registro, List<IError> erros)
        {
            Log.Logger.Error("Falha ao {funcao} \n {@registro}", funcao, JsonConvert.SerializeObject(registro, Formatting.Indented));

            foreach (var item in erros)
            {
                if (item == (erros[erros.Count - 1]))
                    Log.Logger.Error(item.Message + Environment.NewLine);
                else
                    Log.Logger.Error(item.Message);
            }
        }

        protected bool TiverDuplicidade(T registro)
        {
            return repositorio.VerificarDuplicidade(repositorio.SqlDuplicidade(registro));
        }

        private Result ValidarRegistro(T registro)
        {
            var resultadoValidacao = validador.Validate(registro);

            List<Error> erros = new();

            foreach (ValidationFailure erro in resultadoValidacao.Errors)
                erros.Add(new Error(erro.ErrorMessage));

            if (HaDuplicidade(registro))
                erros.Add(new Error(SqlMensagemDeErroSeTiverDuplicidade));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }
    }
}
