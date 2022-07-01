using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        List<Cliente> SelecionarTodosClientesQueSaoPessoaFisica();
    }
}
