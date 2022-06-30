﻿using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloFuncionario
{
    public class ServicoFuncionario : ServicoBase<Funcionario, ValidadorFuncionario>, IServicoFuncionario
    {
        IRepositorioFuncionario repositorio;
        public ServicoFuncionario(IRepositorioFuncionario repositorio) : base(new ValidadorFuncionario(), repositorio)
        {
            this.repositorio = repositorio;
        }

        public override ValidationResult HaDuplicidadeFilha(Funcionario registro, ValidationResult resultadoValidacao)
        {
            if (repositorio.VerificarDuplicidade(repositorio.SqlDuplicidade(registro)))
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Login já está cadastrado"));

            return resultadoValidacao;
        }
    }
}