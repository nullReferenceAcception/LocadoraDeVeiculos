using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public class ValidadorTaxa : AbstractValidator<Taxa>
    {
    
        public ValidadorTaxa()
        {
             Regex regEx = new Regex("^[a-z A-Z0-9]*$");

            RuleFor(x => x.Descricao)
                .NotNull().NotEmpty().MinimumLength(3).Matches(regEx);
            RuleFor(x => x.Valor)
                .NotNull().NotEmpty().GreaterThan(0);

        }

        


    }
}
