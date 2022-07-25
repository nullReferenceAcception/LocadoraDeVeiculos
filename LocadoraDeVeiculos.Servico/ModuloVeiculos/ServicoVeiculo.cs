using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloVeiculos
{
    public class ServicoVeiculo : ServicoBase<Veiculo, ValidadorVeiculo>, IServicoVeiculo
    {
        IRepositorioVeiculo _repositorioVeiculo;

        public ServicoVeiculo(IRepositorioVeiculo repositorioVeiculo) : base(new ValidadorVeiculo(), repositorioVeiculo)
        {
            this._repositorioVeiculo = repositorioVeiculo;
        }

        protected override string MensagemDeErroSeTiverDuplicidade => "Placa já cadastrada";
    }
}
