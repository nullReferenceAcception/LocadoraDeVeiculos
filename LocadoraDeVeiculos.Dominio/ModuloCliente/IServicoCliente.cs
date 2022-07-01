using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public interface IServicoCliente : IServico<Cliente>
    {
        List<Cliente> SelecionarTodosClientesQueSaoPessoaFisica();
    }
}
