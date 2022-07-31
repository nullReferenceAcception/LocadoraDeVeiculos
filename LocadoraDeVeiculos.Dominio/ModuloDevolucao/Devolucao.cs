using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloDevolucao
{
    public class Devolucao : EntidadeBase<Devolucao>
    {
        public Locacao Locacao { get; set; }
        public Guid LocacaoId { get; set; }
        public DateTime DataDevolucaoReal { get; set; }
        public List<Taxa> TaxasAdicionais { get; set; }
        public TanqueEnum Tanque { get; set; }
        public decimal ValorTotalReal { get; set; }

        public Devolucao()
        {
            TaxasAdicionais = new();
        }

        public override bool Equals(object? obj)
        {
            return obj is Devolucao devolucao &&
                   Id.Equals(devolucao.Id) &&
                   EqualityComparer<Locacao>.Default.Equals(Locacao, devolucao.Locacao) &&
                   LocacaoId.Equals(devolucao.LocacaoId) &&
                   DataDevolucaoReal == devolucao.DataDevolucaoReal &&
                   CompararTaxas(devolucao) &&
                   ValorTotalReal == devolucao.ValorTotalReal &&
                   Tanque == devolucao.Tanque;
        }

        private bool CompararTaxas(Devolucao devolucao)
        {
            if (TaxasAdicionais.Count != devolucao.TaxasAdicionais.Count)
                return false;

            for (int i = 0; i < TaxasAdicionais.Count; i++)
                if (EqualityComparer<Taxa>.Default.Equals(TaxasAdicionais[i], devolucao.TaxasAdicionais[i]))
                    return false;

            return true;
        }
    }
}
