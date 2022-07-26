using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloTaxa
{
    public class ServicoTaxa : ServicoBase<Taxa, ValidadorTaxa>, IServicoTaxa
    {
        public ServicoTaxa(IRepositorioTaxa repositorioTaxa, IContextoPersistencia contexto) : base(new ValidadorTaxa(), repositorioTaxa, contexto)
        {
        }

        protected override string MensagemDeErroSeTiverDuplicidade => "Descrição já cadastrada";
    }
}
