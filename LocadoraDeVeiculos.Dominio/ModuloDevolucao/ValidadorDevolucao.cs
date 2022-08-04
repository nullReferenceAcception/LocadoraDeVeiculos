using FluentValidation;
using System;

namespace LocadoraDeVeiculos.Dominio.ModuloDevolucao
{
    public class ValidadorDevolucao : AbstractValidator<Devolucao>
    {
        public ValidadorDevolucao()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Locacao)
                .NotNull().NotEmpty();
            RuleFor(x => x.ValorTotalReal)
                .NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.DataDevolucaoReal.Date)
                .NotNull().NotEmpty().GreaterThanOrEqualTo(DateTime.Today).GreaterThanOrEqualTo(x => x.Locacao.DataLocacao);
        }
    }
}
