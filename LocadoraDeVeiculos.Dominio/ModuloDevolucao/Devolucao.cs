using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using System;

namespace LocadoraDeVeiculos.Dominio.ModuloDevolucao
{
    public class Devolucao : EntidadeBase<Devolucao>
    {
        public Locacao Locacao { get; set; }
        public DateTime DataDevolucaoReal { get; set; }
        public override bool Equals(object? obj)
        {
            throw new NotImplementedException();
        }
    }
}
