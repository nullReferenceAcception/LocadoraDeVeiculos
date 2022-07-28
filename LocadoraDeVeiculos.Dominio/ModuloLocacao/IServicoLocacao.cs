using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloLocacao
{
    public interface IServicoLocacao : IServico<Locacao>
    {
        void RemoverTaxas(Locacao locacao, List<Taxa> taxas);
    }
}
