using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos
{
    public class ValidadorGrupoVeiculos : AbstractValidator<GrupoVeiculos>
    {
        public ValidadorGrupoVeiculos()
        {
            Regex regEx = new Regex("^[a-z A-Z0-9]*$");

            RuleFor(x => x.Nome)
                    .NotNull().NotEmpty().MinimumLength(3).Matches(regEx);
        }
    }
}
