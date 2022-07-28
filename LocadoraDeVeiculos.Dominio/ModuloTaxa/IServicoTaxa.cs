using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public interface IServicoTaxa : IServico<Taxa>
    {
        Result<List<Taxa>> SelecionarTodosAdicionais();
    }
}
