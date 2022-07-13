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

        public ValidationResult Excluir(T registro)
        {
            Log.Logger.Debug($"Excluindo: {typeof(T).Name}");

            ValidationResult resultadoValidacao = new();

            string mensagem = repositorio.Excluir(registro);

            if (!string.IsNullOrEmpty(mensagem))
            {
                resultadoValidacao.Errors.Add(new ValidationFailure("", mensagem));
                LogFalha("Excluir", registro, resultadoValidacao);
                return resultadoValidacao;
            }

            Log.Logger.Debug("Excluido: {@registro}", JsonConvert.SerializeObject(registro, Formatting.Indented));

            return resultadoValidacao;
        }

        public List<T> SelecionarTodos()
        {
            return repositorio.SelecionarTodos();
        }

        public T SelecionarPorGuid(Guid guid)
        {
            return repositorio.SelecionarPorGuid(guid);
        }

        public int QuantidadeRegistro()
        {
            return repositorio.QuantidadeRegistros();
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
