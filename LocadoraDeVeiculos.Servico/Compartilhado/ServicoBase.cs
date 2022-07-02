using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio;
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
            ValidationResult resultadoValidacao = ValidarRegistro(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            repositorio.Inserir(registro);
            return resultadoValidacao;
        }

        public virtual ValidationResult Editar(T registro)
        {
            ValidationResult resultadoValidacao = ValidarRegistro(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            repositorio.Editar(registro);
            return resultadoValidacao;
        }

        private ValidationResult ValidarRegistro(T registro)
        {
            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            resultadoValidacao = HaDuplicidade(registro, resultadoValidacao);
            return resultadoValidacao;
        }

        public ValidationResult Excluir(T registro)
        {
            ValidationResult resultadoValidacao = new();

            string mensagem = repositorio.Excluir(registro);

            if (!string.IsNullOrEmpty(mensagem))
                resultadoValidacao.Errors.Add(new ValidationFailure("", mensagem));

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

        protected abstract string SqlMensagemDeErro { get; }

        protected virtual ValidationResult HaDuplicidade( T registro, ValidationResult resultadoValidacao)
        {
            if (TiverDuplicidade(registro))
                resultadoValidacao.Errors.Add(new ValidationFailure("", SqlMensagemDeErro));

            return resultadoValidacao;
        }

        private bool TiverDuplicidade(T registro)
        {
            return repositorio.VerificarDuplicidade(repositorio.SqlDuplicidade(registro));
        }
    }
}
