using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        Cliente c;
        public ValidadorCliente()
        {
            Regex regEx = new Regex("^[1-9]{2}[0-9]{4,5}[0-9]{4}$");

            RuleFor(x => x.Telefone)
                .NotNull().NotEmpty().Matches(regEx);

            RuleFor(x => x.Email)
                .NotNull().NotEmpty().EmailAddress();

            RuleFor(x => x.Nome)
                .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Endereco)
                .NotNull().NotEmpty().MinimumLength(4);

            RuleFor(x => x.PessoaFisica)
                .NotNull();



            When(x => x.PessoaFisica, () =>
            {
                RuleFor(x => x.CPF)
                  .NotNull().NotEmpty().MinimumLength(11);

                RuleFor(x => x.CNH)
                .NotNull().NotEmpty().MinimumLength(11);
            });


            When(x => !x.PessoaFisica, () =>
            {
                RuleFor(x => x.CNPJ)
                .NotNull().NotEmpty().MinimumLength(14);
            });
        }


    }
}
