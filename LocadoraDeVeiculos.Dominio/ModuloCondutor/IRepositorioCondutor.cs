using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public interface IRepositorioCondutor : IRepositorio<Condutor>
    {
       List<Condutor> SelecionarTodosDoCliente(Cliente cliente);
    }
}
