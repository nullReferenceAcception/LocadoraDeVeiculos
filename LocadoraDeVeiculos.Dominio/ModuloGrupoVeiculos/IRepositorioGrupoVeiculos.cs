using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos
{
    public interface IRepositorioGrupoVeiculos : IRepositorio<GrupoVeiculos>
    {
        GrupoVeiculos SelecionarGrupoDoPlano(PlanoCobranca p);
    }
}
