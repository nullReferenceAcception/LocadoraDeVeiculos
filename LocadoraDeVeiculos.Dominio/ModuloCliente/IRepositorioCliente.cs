using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        List<Cliente> SelecionarTodosClientesQueSaoPessoaFisica();
        List<Cliente> SelecionarTodosClientesQueSaoPessoaJuridica();
        public bool VerificarDuplicidadeCNPJ(Cliente registro);
    }
}
