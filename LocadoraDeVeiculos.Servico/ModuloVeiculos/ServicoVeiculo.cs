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
            Serilog.Log.Logger.Information("Ué²");
        }

        protected override string SqlMensagemDeErroSeTiverDuplicidade => "Placa já cadastrada";
    }
}
