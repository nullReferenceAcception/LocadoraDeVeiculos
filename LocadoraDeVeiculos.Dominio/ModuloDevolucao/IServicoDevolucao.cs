using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloDevolucao
{
    public interface IServicoDevolucao : IServico<Devolucao>
    {
        void RemoverTaxas(Devolucao devolucao, List<Taxa> taxas) { }
    }
}
