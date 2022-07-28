using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public interface IServicoCondutor : IServico<Condutor>
    {
        Result<List<Condutor>> SelecionarTodosDoCliente(Cliente selectedItem);
    }
}
