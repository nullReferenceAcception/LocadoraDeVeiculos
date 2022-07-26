using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloGrupoVeiculos
{
    public class ServicoGrupoVeiculos : ServicoBase<GrupoVeiculos, ValidadorGrupoVeiculos>, IServicoGrupoVeiculos
    {
        public ServicoGrupoVeiculos(IRepositorioGrupoVeiculos repositorioGrupoVeiculos, IContextoPersistencia contexto) : base(new ValidadorGrupoVeiculos(), repositorioGrupoVeiculos, contexto)
        {
        }

        protected override string MensagemDeErroSeTiverDuplicidade { get; set; } = "Nome já está cadastrado";
    }
}
