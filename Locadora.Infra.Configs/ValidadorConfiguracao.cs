using FluentValidation;

namespace Locadora.Infra.Configs
{
    public class ValidadorConfiguracao : AbstractValidator<ConfiguracaoAplicacaoLocadora>
    {
        public ValidadorConfiguracao()
        {
            RuleFor(x => x.VersaoSistema)
                .NotNull().NotEmpty();
            RuleFor(x => x.ConfiguracaoLogs.DiretorioSaida)
                .NotNull().NotEmpty();
            RuleFor(x => x.ConnectionStrings.SqlServer)
                .NotNull().NotEmpty();
            RuleFor(x => decimal.Parse(x.PrecoCombustiveis.Etanol))
                .NotNull().NotEmpty().GreaterThan(0m);
            RuleFor(x => decimal.Parse(x.PrecoCombustiveis.Alcool))
                .NotNull().NotEmpty().GreaterThan(0m);
            RuleFor(x => decimal.Parse(x.PrecoCombustiveis.Gasolina))
                .NotNull().NotEmpty().GreaterThan(0m);
            RuleFor(x => decimal.Parse(x.PrecoCombustiveis.Diesel))
                .NotNull().NotEmpty().GreaterThan(0m);

            RuleFor(x => x.PrecoCombustiveis.GNV)
                .Custom((x, context) =>
                {
                    if ((!(decimal.TryParse(x, out decimal value)) || value <= 0))
                        context.AddFailure($"{x} is not a valid number or less than 0");
                });
        }
    }
}
