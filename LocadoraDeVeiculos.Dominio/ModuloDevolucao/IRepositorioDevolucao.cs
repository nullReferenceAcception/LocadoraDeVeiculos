using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloDevolucao
{
    public interface IRepositorioDevolucao : IRepositorio<Devolucao>
    {
        void RemoverTaxas(Devolucao devolucao, List<Taxa> taxas);
    }
}
