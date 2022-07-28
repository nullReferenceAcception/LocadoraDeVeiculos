using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public interface IRepositorioTaxa : IRepositorio<Taxa>
    {
        List<Taxa> SelecionarTodosAdicionais();
    }
}
