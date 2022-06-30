using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos
{
    public class ValidadorGrupoVeiculos : AbstractValidator<GrupoVeiculos>
    {
        public ValidadorGrupoVeiculos()
        {
            Regex padraoNome = new Regex("^[A-Z\\sa-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]*$");

            RuleFor(x => x.Nome)
                    .NotNull().NotEmpty().MinimumLength(3).Matches(padraoNome);
        }
    }
}
