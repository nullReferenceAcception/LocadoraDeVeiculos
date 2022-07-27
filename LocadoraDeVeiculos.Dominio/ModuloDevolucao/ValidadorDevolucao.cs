using FluentValidation;

namespace LocadoraDeVeiculos.Dominio.ModuloDevolucao
{
    public class ValidadorDevolucao : AbstractValidator<Devolucao>
    {
        public ValidadorDevolucao()
        {
            RuleFor(x => x.Locacao)
                .NotNull().NotEmpty();
            RuleFor(x => x.DataDevolucaoReal)
                .NotNull().NotEmpty();
            RuleFor(x => x.Tanque)
                .NotNull().NotEmpty();
        }
    }
}
