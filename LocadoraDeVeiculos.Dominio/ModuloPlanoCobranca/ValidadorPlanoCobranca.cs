using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca
{
    public class ValidadorPlanoCobranca : AbstractValidator<PlanoCobranca>
    {
        public ValidadorPlanoCobranca()
        {
            Regex padraoNome = new Regex("^[A-Z\\sa-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]*$");

            RuleFor(x => x.Nome)
                .NotNull().NotEmpty().MinimumLength(2).Matches(padraoNome);
            RuleFor(x => x.GrupoVeiculos)
               .NotNull().NotEmpty();

            RuleFor(x => x.ValorDia)
                .NotNull().NotEmpty().GreaterThan(0);

            When(x => x.Plano == PlanoEnum.Diario, () =>
            {
                RuleFor(x => x.ValorPorKm)
                .NotNull().NotEmpty().GreaterThan(0);

            });

            When(x => x.Plano == PlanoEnum.KmControlado, () =>
            {
                RuleFor(x => x.ValorPorKm)
                .NotNull().NotEmpty().GreaterThan(0);

                RuleFor(x => x.KmLivreIncluso)
              .NotNull().NotEmpty().GreaterThan(0);
            });


        }
    }
}
