using FluentValidation;
using System.Text.RegularExpressions;


namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class ValidadorCondutor : AbstractValidator<Condutor>
    {

        public ValidadorCondutor()
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

            RuleFor(x => x.CPF)
                .NotNull().NotEmpty().MinimumLength(11);

            RuleFor(x => x.CNH)
                .NotNull().NotEmpty().MinimumLength(11);
        }


    }
}
