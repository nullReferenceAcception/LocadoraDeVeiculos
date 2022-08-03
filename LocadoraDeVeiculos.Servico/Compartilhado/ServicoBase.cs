using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using Locadora.Infra.Configs;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;
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
        private readonly ConfiguracaoAplicacaoLocadora configuracao;

        public ServicoBase(AbstractValidator<T> validationRules, IRepositorio<T> repositorio, IContextoPersistencia contexto, ConfiguracaoAplicacaoLocadora configuracao)
        {
            this.validador = (TValidador)validationRules;
            this.repositorio = repositorio;
            this.contexto = contexto;
            this.configuracao = configuracao;
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
                Log.Logger.Debug("Inserido: {@registro}", registro, Formatting.Indented);
                return Result.Ok(registro);
            }
            catch (Exception ex)
            {
                StringBuilder msgErro = new StringBuilder("Falha no sistema ao tentar inserir ");

                Log.Logger.Error(ex, msgErro + "{classe}" + "{id}" + "{VersaoSistema}", typeof(T).Name, registro.Id, configuracao.VersaoSistema);

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
                Log.Logger.Debug("Editado: {@registro}", registro, Formatting.Indented);
                return Result.Ok(registro);
            }
            catch (Exception ex)
            {
                StringBuilder msgErro = new StringBuilder("Falha no sistema ao tentar editar ");

                Log.Logger.Error(ex, msgErro + "{classe}" + "{id}" + "{VersaoSistema}", typeof(T).Name, registro.Id, configuracao.VersaoSistema);

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

                Log.Logger.Debug("Excluido: {@registro}", registro, Formatting.Indented);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                StringBuilder msgErro = new StringBuilder();

                if (ex is DbUpdateException || ex is InvalidOperationException)
                {
                    msgErro.Append($"O {typeof(T).Name} esta sendo usado por outro registro");
                    contexto.DesfazerAlteracoes();
                }
                else
                    msgErro.Append($"falha no sistema ao tentar excluir o {typeof(T).Name}");

                Log.Logger.Error(ex, msgErro + "{classe}" + "{id}" + "{VersaoSistema}", typeof(T).Name, registro.Id, configuracao.VersaoSistema);

                return Result.Fail(msgErro.ToString());
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

                Log.Logger.Error(ex, msgErro + "{classe}" + "{VersaoSistema}", typeof(T).Name, configuracao.VersaoSistema);

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
                StringBuilder msgErro = new("Selecionado o ");

                Log.Logger.Error(ex, msgErro + "{classe}" + "{VersaoSistema}", typeof(T).Name, configuracao.VersaoSistema);

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
                StringBuilder msgErro = new("Falha no sistema ao pegar quantidade de ");

                Log.Logger.Error(ex, msgErro + "{classe}" + "{VersaoSistema}", typeof(T).Name, configuracao.VersaoSistema);

                return Result.Fail(msgErro.Append(typeof(T).Name).ToString());
            }
        }

        protected abstract string MensagemDeErroSeTiverDuplicidade { get; set; }

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
            Log.Logger.Error("Falha ao {funcao} \n {@registro}", funcao, registro);

            foreach (var item in erros)
                if (item == (erros[erros.Count - 1]))
                    Log.Logger.Error(item.Message + Environment.NewLine);
                else
                    Log.Logger.Error(item.Message);
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
            {
                contexto.DesfazerAlteracoes();
                return Result.Fail(erros);
            }

            return Result.Ok();
        }
    }
}
