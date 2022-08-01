using FluentValidation;
using System;

namespace LocadoraDeVeiculos.Dominio.ModuloDevolucao
{
    public class ValidadorDevolucao : AbstractValidator<Devolucao>
    {
        public ValidadorDevolucao()
        {
            RuleFor(x => x.Locacao)
                .NotNull().NotEmpty();
            RuleFor(x => x.DataDevolucaoReal.Date)
                .NotNull().NotEmpty().GreaterThanOrEqualTo(DateTime.Today).GreaterThanOrEqualTo(x => x.Locacao.DataLocacao);
            RuleFor(x => x.Tanque)
                .NotNull().NotEmpty();
            RuleFor(x => x.ValorTotalReal)
                .NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
