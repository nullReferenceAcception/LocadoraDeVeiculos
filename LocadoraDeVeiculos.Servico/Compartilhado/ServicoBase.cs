using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Servico.Compartilhado
{
    public abstract class ServicoBase<T, TValidador>
        where T : EntidadeBase<T>
        where TValidador : AbstractValidator<T>
    {

        TValidador validador;
        IRepositorio<T> repositorio;

        public abstract ValidationResult HaDuplicidadeFilha(T registro,ValidationResult resultadoValidacao);

        public ServicoBase(AbstractValidator<T> validationRules, IRepositorio<T> repositorio)
        {
            this.validador = (TValidador)validationRules;
            this.repositorio = repositorio;
        }

        public virtual ValidationResult Inserir(T registro)
        {
            var resultadoValidacao = validador.Validate(registro);

            resultadoValidacao = HaDuplicidadeFilha(registro, resultadoValidacao);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            repositorio.Inserir(registro);
            return resultadoValidacao;

        }

        protected virtual ValidationResult HaDuplicidadeMae(string error,T registro, ValidationResult resultadoValidacao)
        {
            if (repositorio.VerificarDuplicidade(repositorio.SqlDuplicidade(registro)))
            {
                resultadoValidacao.Errors.Add(new ValidationFailure("", error));
            }
            return resultadoValidacao;

        }


        public virtual ValidationResult Editar(T registro)
        {
            var resultadoValidacao = validador.Validate(registro);

            resultadoValidacao = HaDuplicidadeFilha(registro, resultadoValidacao);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            repositorio.Editar(registro);
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


    }
}
