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

            RuleFor(x => x.PrecoCombustiveis.Etanol)
                .Custom((x, contexto) =>
                {
                    if ((!(decimal.TryParse(x, out decimal value)) || value <= 0))
                        contexto.AddFailure($"'{x}' não é válido!");
                });

            RuleFor(x => x.PrecoCombustiveis.Alcool)
                .Custom((x, contexto) =>
                {
                    if ((!(decimal.TryParse(x, out decimal value)) || value <= 0))
                        contexto.AddFailure($"'{x}' não é válido!");
                });

            RuleFor(x => x.PrecoCombustiveis.Gasolina)
                .Custom((x, contexto) =>
                {
                    if ((!(decimal.TryParse(x, out decimal value)) || value <= 0))
                        contexto.AddFailure($"'{x}' não é válido!");
                });

            RuleFor(x => x.PrecoCombustiveis.Diesel)
                .Custom((x, contexto) =>
                {
                    if ((!(decimal.TryParse(x, out decimal value)) || value <= 0))
                        contexto.AddFailure($"'{x}' não é válido!");
                });

            RuleFor(x => x.PrecoCombustiveis.GNV)
                .Custom((x, contexto) =>
                {
                    if ((!(decimal.TryParse(x, out decimal value)) || value <= 0))
                        contexto.AddFailure($"'{x}' não é válido!");
                });
        }
    }
}
