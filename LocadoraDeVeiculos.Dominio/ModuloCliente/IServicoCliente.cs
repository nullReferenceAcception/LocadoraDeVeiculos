using LocadoraDeVeiculos.Dominio.Compartilhado;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public interface IServicoCliente : IServico<Cliente>
    {
        List<Cliente> SelecionarTodosClientesQueSaoPessoaFisica();
        List<Cliente> SelecionarTodosClientesQueSaoPessoaJuridica();
    }
}
