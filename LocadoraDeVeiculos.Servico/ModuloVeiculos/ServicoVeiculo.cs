using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloVeiculos
{
    public class ServicoVeiculo : ServicoBase<Veiculo, ValidadorVeiculo>, IServicoVeiculo
    {
        IRepositorioVeiculo _repositorioVeiculo;

        public ServicoVeiculo(IRepositorioVeiculo repositorio) : base(new ValidadorVeiculo(), repositorio)
        {
            this._repositorioVeiculo = repositorio;
        }
        public override ValidationResult HaDuplicidadeFilha(Veiculo registro, ValidationResult resultadoValidacao)
        {
            if (_repositorioVeiculo.VerificarDuplicidade(_repositorioVeiculo.SqlDuplicidadePlaca(registro)))
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Placa já cadastrada"));

            return resultadoValidacao;
        }
    }
}
