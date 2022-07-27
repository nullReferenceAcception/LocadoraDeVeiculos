using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloLocacao
{
    public class ServicoLocacao : ServicoBase<Locacao, ValidadorLocacao>, IServicoLocacao
    {
        public ServicoLocacao(IRepositorioLocacao repositorioGrupoVeiculos, IContextoPersistencia contexto) : base(new ValidadorLocacao(), repositorioGrupoVeiculos, contexto)
        {
        }

        protected override string MensagemDeErroSeTiverDuplicidade { get; set; } = "Veiculo já está alocado";
    }
}
