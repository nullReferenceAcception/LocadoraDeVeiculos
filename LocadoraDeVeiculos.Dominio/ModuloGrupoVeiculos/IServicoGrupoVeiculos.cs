using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos
{
    public interface IServicoGrupoVeiculos : IServico<GrupoVeiculos>
    {
        Result<GrupoVeiculos> SelecionarTodosDoPlano(PlanoCobranca p);
    }
}
