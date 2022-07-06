using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloGrupoVeiculos
{
    public class ServicoGrupoVeiculos : ServicoBase<GrupoVeiculos, ValidadorGrupoVeiculos>, IServicoGrupoVeiculos
    {
        public ServicoGrupoVeiculos(IRepositorioGrupoVeiculos repositorioGrupoVeiculos) : base(new ValidadorGrupoVeiculos(), repositorioGrupoVeiculos)
        {
        }

        protected override string SqlMensagemDeErroSeTiverDuplicidade => "Nome já está cadastrado";
    }
}
