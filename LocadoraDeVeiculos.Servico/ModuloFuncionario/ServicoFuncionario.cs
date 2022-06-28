using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Servico.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Servico.ModuloFuncionario
{
    public class ServicoFuncionario : ServicoBase<Funcionario, ValidadorFuncionario>, IServicoFuncionario
    {
        IRepositorioFuncionario repositorio;
        public ServicoFuncionario(IRepositorioFuncionario repositorio) : base(new ValidadorFuncionario(), repositorio)
        {
            this.repositorio = repositorio;
        }

        public override ValidationResult HaDuplicidade(Funcionario registro, ValidationResult resultadoValidacao)
        {
            if (repositorio.VerificarDuplicidade(repositorio.SqlDuplicidadeLogin(registro)))
            {
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Login já está cadastrado"));
            }

           else if (repositorio.VerificarDuplicidade(repositorio.SqlDuplicidadeNome(registro)))
            {
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Nome já está cadastrado"));
            }

            return resultadoValidacao;

        }

    }
}
