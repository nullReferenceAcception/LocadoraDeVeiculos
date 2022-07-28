using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public interface IServicoVeiculo : IServico<Veiculo>
    {
        Result<List<Veiculo>> SelecionarTodosDoGrupo(GrupoVeiculos grupo);
    }
}
