using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taikandi;

namespace LocadoraDeVeiculos.Servico.Compartilhado
{
    public abstract class ServicoBase<T, TValidador>
        where T : EntidadeBase<T>
        where TValidador : AbstractValidator<T>
    {
        TValidador validador;
        IRepositorio<T> repositorio;
        IContextoPersistencia contexto;

        public ServicoBase(AbstractValidator<T> validationRules, IRepositorio<T> repositorio, IContextoPersistencia contexto)
        {
            this.validador = (TValidador)validationRules;
            this.repositorio = repositorio;
            this.contexto = contexto;
        }

        public virtual Result<T> Inserir(T registro)
        {
            registro.Id = SequentialGuid.NewGuid();

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
                contexto.GravarDados();
                Log.Logger.Debug("Inserido: {@registro}", JsonConvert.SerializeObject(registro, Formatting.Indented));
                return Result.Ok(registro);
            }
            catch (Exception ex)
            {
                StringBuilder msgErro = new StringBuilder("Falha no sistema ao tentar inserir ");

                Log.Logger.Error(ex, msgErro + "{classe}" + "{id}", typeof(T).Name, registro.Id);

                return Result.Fail(msgErro.Append(typeof(T).Name).ToString());
            }
        }

        public virtual Result<T> Editar(T registro)
        {
            Log.Logger.Debug("Editando: {nome} - ID: {id}", typeof(T).Name, registro.Id);

            Result resultadoValidacao = ValidarRegistro(registro);

            if (resultadoValidacao.IsFailed)
            {
                LogFalha("Editar", registro, resultadoValidacao.Errors);
                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorio.Editar(registro);
                contexto.GravarDados();
                Log.Logger.Debug("Editado: {@registro}", JsonConvert.SerializeObject(registro, Formatting.Indented));
                return Result.Ok(registro);
            }
            catch (Exception ex)
            {
                StringBuilder msgErro = new StringBuilder("Falha no sistema ao tentar editar ");

                Log.Logger.Error(ex, msgErro + "{classe}" + "{id}", typeof(T).Name, registro.Id);

                return Result.Fail(msgErro.Append(typeof(T).Name).ToString());
            }
        }

        public Result Excluir(T registro)
        {
            Log.Logger.Debug("Excluindo: {classe}", typeof(T).Name);

            try
            {
                repositorio.Excluir(registro);
                contexto.GravarDados();

                Log.Logger.Debug("Excluido: {@registro}", JsonConvert.SerializeObject(registro, Formatting.Indented));

                return Result.Ok();
            }
            catch (Exception ex)
            {
                StringBuilder msgErro = new StringBuilder("Falha no sistema ao tentar excluir o ");

                Log.Logger.Error(ex, msgErro + "{classe}" + "{id}", typeof(T).Name, registro.Id);

                return Result.Fail(msgErro.Append(typeof(T).Name).ToString());
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
                StringBuilder msgErro = new StringBuilder("Falha no sistema ao tentar selecionar todos os  ");

                Log.Logger.Error(ex, msgErro + "{classe}", typeof(T).Name);

                return Result.Fail(msgErro.Append(typeof(T).Name).ToString());
            }
        }

        public Result<T> SelecionarPorGuid(Guid id)
        {
            try
            {
                return Result.Ok(repositorio.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                StringBuilder msgErro = new StringBuilder("Falha no sistema ao tentar selecionar o ");

                Log.Logger.Error(ex, msgErro + "{classe}", typeof(T).Name);

                return Result.Fail(msgErro.Append(typeof(T).Name).ToString());
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
                StringBuilder msgErro = new StringBuilder("Falha no sistema ao pegar quantidade de ");

                Log.Logger.Error(ex, msgErro + "{classe}", typeof(T).Name);

                return Result.Fail(msgErro.Append(typeof(T).Name).ToString());
            }
        }

        protected abstract string MensagemDeErroSeTiverDuplicidade { get; }

        protected virtual bool HaDuplicidade(T registro)
        {
            if (TiverDuplicidade(registro))
                return true;

            return false;
        }

        protected bool TiverDuplicidade(T registro)
        {
            return repositorio.VerificarDuplicidade(registro);
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

        private Result ValidarRegistro(T registro)
        {
            var resultadoValidacao = validador.Validate(registro);

            List<Error> erros = new();

            foreach (ValidationFailure erro in resultadoValidacao.Errors)
                erros.Add(new Error(erro.ErrorMessage));

            if (HaDuplicidade(registro))
                erros.Add(new Error(MensagemDeErroSeTiverDuplicidade));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }
    }
}
