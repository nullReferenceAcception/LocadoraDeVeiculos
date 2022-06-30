using FluentValidation;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public class ValidadorVeiculo : AbstractValidator<Veiculo>
    {
        public ValidadorVeiculo()
        {
            RuleFor(x => x.Modelo)
                .NotNull().NotEmpty().MinimumLength(2);

            RuleFor(x => x.Marca)
                .NotNull().NotEmpty();

            RuleFor(x => x.Placa)
                .NotNull().NotEmpty().MinimumLength(7);

            RuleFor(x => x.GrupoVeiculos)
                .NotNull().NotEmpty();

            RuleFor(x => x.Combustivel)
                .NotNull().NotEmpty();

            RuleFor(x => x.Cor)
                .NotNull().NotEmpty();

            RuleFor(x => x.Foto)
                .NotNull().NotEmpty();

            RuleFor(x => x.Ano)
                .NotNull().NotEmpty().GreaterThanOrEqualTo(2000);

            RuleFor(x => x.CapacidadeTanque)
                .NotNull().NotEmpty().GreaterThan(0);

            RuleFor(x => x.KmPercorrido)
                .NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
