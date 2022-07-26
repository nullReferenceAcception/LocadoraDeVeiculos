using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloVeiculos
{
    public class ServicoVeiculo : ServicoBase<Veiculo, ValidadorVeiculo>, IServicoVeiculo
    {
        IRepositorioVeiculo _repositorioVeiculo;

        public ServicoVeiculo(IRepositorioVeiculo repositorioVeiculo, IContextoPersistencia contexto) : base(new ValidadorVeiculo(), repositorioVeiculo, contexto)
        {
            this._repositorioVeiculo = repositorioVeiculo;
        }

        protected override string MensagemDeErroSeTiverDuplicidade { get; set; } = "Placa já está cadastrado";
    }
}
