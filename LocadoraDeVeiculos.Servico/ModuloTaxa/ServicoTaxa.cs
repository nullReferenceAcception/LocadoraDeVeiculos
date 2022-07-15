using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloTaxa
{
    public class ServicoTaxa : ServicoBase<Taxa, ValidadorTaxa>, IServicoTaxa
    {
        public ServicoTaxa(IRepositorioTaxa repositorioTaxa) : base(new ValidadorTaxa(), repositorioTaxa)
        {
        }

        protected override string MensagemDeErroSeTiverDuplicidade => "Descrição já cadastrada";
    }
}
