using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public interface IServicoCliente : IServico<Cliente>
    {
        Result<List<Cliente>> SelecionarTodosClientesQueSaoPessoaFisica();
        Result<List<Cliente>> SelecionarTodosClientesQueSaoPessoaJuridica();
    }
}
