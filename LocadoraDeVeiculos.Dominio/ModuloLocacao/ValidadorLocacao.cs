using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloLocacao
{
    public class ValidadorLocacao : AbstractValidator<Locacao>
    {
        public ValidadorLocacao()
        {
            Regex regEx = new Regex("^[1-9]{2}[0-9]{4,5}[0-9]{4}$");
            DateTime hoje = DateTime.Today;

            hoje = hoje.AddHours(23).AddMinutes(59).AddSeconds(59);

            RuleFor(x => x.DataLocacao)
                   .NotNull().NotEmpty().GreaterThan(DateTime.MinValue).GreaterThanOrEqualTo(hoje.AddDays(-1));

            RuleFor(x => x.DataDevolucaoPrevista)
                    .NotNull().NotEmpty().GreaterThan(DateTime.MinValue).GreaterThan(hoje.AddDays(-1));

            RuleFor(x => x.Funcionario)
                 .NotNull().NotEmpty();

            RuleFor(x => x.Cliente)
               .NotNull().NotEmpty();

            RuleFor(x => x.Cliente)
                .NotNull().NotEmpty();

            RuleFor(x => x.Condutor)
              .NotNull().NotEmpty();

            RuleFor(x => x.Veiculo)
             .NotNull().NotEmpty();

            RuleFor(x => x.PlanoCobranca)
             .NotNull().NotEmpty();

            RuleFor(x => x.Taxas)
              .NotNull().NotEmpty();
        }

    }
}
