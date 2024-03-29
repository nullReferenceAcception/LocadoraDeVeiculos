﻿using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            Regex regEx = new Regex("^[1-9]{2}[0-9]{4,5}[0-9]{4}$");

            DateTime hoje = DateTime.Today;
            hoje = hoje.AddHours(23).AddMinutes(59).AddSeconds(59);

            Regex padraoNome = new Regex("^[A-Z a-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]*$");

            RuleFor(x => x.Telefone)
                .NotNull().NotEmpty().Matches(regEx);

            RuleFor(x => x.Email)
                .NotNull().NotEmpty().EmailAddress();

            RuleFor(x => x.Nome)
                .NotNull().NotEmpty().MinimumLength(3).Matches(padraoNome);

            RuleFor(x => x.Endereco)
                .NotNull().NotEmpty().MinimumLength(4);

            RuleFor(x => x.PessoaFisica)
                .NotNull();

            When(x => x.PessoaFisica, () =>
            {
                RuleFor(x => x.CPF)
                  .NotNull().NotEmpty().MinimumLength(11).MaximumLength(11);


            });

            When(x => !x.PessoaFisica, () =>
            {
                RuleFor(x => x.CNPJ)
                .NotNull().NotEmpty().MinimumLength(14).MaximumLength(14);
            });
        }
    }
}
