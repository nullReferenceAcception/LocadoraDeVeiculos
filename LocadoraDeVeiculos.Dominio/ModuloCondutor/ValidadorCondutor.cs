using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class ValidadorCondutor : AbstractValidator<Condutor>
    {
        public ValidadorCondutor()
        {
            Regex regEx = new Regex("^[1-9]{2}[0-9]{4,5}[0-9]{4}$");
            DateTime hoje = DateTime.Today;

            hoje = hoje.AddHours(23).AddMinutes(59).AddSeconds(59);

            RuleFor(x => x.Telefone)
                    .NotNull().NotEmpty().Matches(regEx);

            RuleFor(x => x.Email)
                    .NotNull().NotEmpty().EmailAddress();

            RuleFor(x => x.Nome)
                    .NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Endereco)
                    .NotNull().NotEmpty().MinimumLength(4);

            RuleFor(x => x.CPF)
                .NotNull().NotEmpty().MinimumLength(11);

            RuleFor(x => x.CNH)
                .NotNull().NotEmpty().MinimumLength(11);

            RuleFor(x => x.DataValidadeCNH)
                .NotNull().NotEmpty().GreaterThan(DateTime.MinValue).GreaterThanOrEqualTo(hoje.AddDays(-1));  //maior que - - - - menor ou igual
        }
    }
}
