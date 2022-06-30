using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public class ValidadorTaxa : AbstractValidator<Taxa>
    {
        public ValidadorTaxa()
        {
            Regex padraoNome = new Regex("^[A-Z\\sa-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]*$");

            RuleFor(x => x.Descricao)
                .NotNull().NotEmpty().MinimumLength(2).Matches(padraoNome);
            RuleFor(x => x.Valor)
                .NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
