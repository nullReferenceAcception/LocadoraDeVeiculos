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

        protected override string SqlMensagemDeErroDeDuplicidade => "Placa já cadastrada";
    }
}
