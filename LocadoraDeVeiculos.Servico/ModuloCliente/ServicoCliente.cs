using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Servico.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Servico.ModuloCliente
{
    public class ServicoCliente : ServicoBase<Cliente, ValidadorCliente>, IServicoCliente
    {
        public ServicoCliente(IRepositorioCliente repositorio) : base(new ValidadorCliente(), repositorio)
        {
        }
    }
}
