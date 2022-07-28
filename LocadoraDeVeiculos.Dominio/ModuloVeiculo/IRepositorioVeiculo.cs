using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public interface IRepositorioVeiculo : IRepositorio<Veiculo>
    {
        List<Veiculo> SelecionarTodosDoGrupo(GrupoVeiculos grupo);
    }
}
