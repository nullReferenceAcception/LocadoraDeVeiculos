using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio;
using Newtonsoft.Json;
using Serilog;
using System.Collections.Generic;

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

        public virtual ValidationResult Inserir(T registro)
        {
            Log.Logger.Debug($"Inserindo: {typeof(T).Name}");

            ValidationResult resultadoValidacao = ValidarRegistro(registro);

            if (resultadoValidacao.IsValid == false)
            {
                LogFalha("Inserir", registro, resultadoValidacao);
                return resultadoValidacao;
            }

            repositorio.Inserir(registro);
            Log.Logger.Debug("Inserido: {@registro}", JsonConvert.SerializeObject(registro, Formatting.Indented));

            return resultadoValidacao;
        }

        public virtual ValidationResult Editar(T registro)
        {
            Log.Logger.Debug($"Editando: {typeof(T).Name}");

            ValidationResult resultadoValidacao = ValidarRegistro(registro);

            if (resultadoValidacao.IsValid == false)
            {
                LogFalha("Editar", registro, resultadoValidacao);
                return resultadoValidacao;
            }

            repositorio.Editar(registro);

            Log.Logger.Debug("Editado: {@registro}", JsonConvert.SerializeObject(registro, Formatting.Indented));

            return resultadoValidacao;
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

        public T SelecionarPorID(int ID)
        {
            return repositorio.SelecionarPorID(ID);
        }

        public int QuantidadeRegistro()
        {
            return repositorio.QuantidadeRegistros();
        }

        protected abstract string SqlMensagemDeErroSeTiverDuplicidade { get; }

        protected virtual ValidationResult HaDuplicidade(T registro, ValidationResult resultadoValidacao)
        {
            if (TiverDuplicidade(registro))
                resultadoValidacao.Errors.Add(new ValidationFailure("", SqlMensagemDeErroSeTiverDuplicidade));

            return resultadoValidacao;
        }

        private static void LogFalha(string funcao, T registro, ValidationResult resultadoValidacao)
        {
            Log.Logger.Error("Falha ao {funcao} \n {@registro}", funcao, JsonConvert.SerializeObject(registro, Formatting.Indented));

            foreach (var item in resultadoValidacao.Errors)
                Log.Logger.Error(item.ErrorMessage);
        }

        private bool TiverDuplicidade(T registro)
        {
            return repositorio.VerificarDuplicidade(repositorio.SqlDuplicidade(registro));
        }

        private ValidationResult ValidarRegistro(T registro)
        {
            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            resultadoValidacao = HaDuplicidade(registro, resultadoValidacao);

            return resultadoValidacao;
        }
    }
}
