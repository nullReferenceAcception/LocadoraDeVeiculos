using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public class Taxa : EntidadeBase<Taxa>
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool EhDiaria { get; set; }
        public bool EhAdicional { get; set; }

        public List<Locacao> Locacoes;
        public List<Devolucao> Devolucoes;

        public Taxa()
        {
            Valor = 0;
        }

        public Taxa(string descricao, decimal valor, bool ehDiaria)
        {
            Descricao = descricao;
            Valor = valor;
            this.EhDiaria = ehDiaria;
        }

        public Taxa(string descricao, decimal valor, bool ehDiaria, bool ehAdicional)
        {
            Descricao = descricao;
            Valor = valor;
            this.EhDiaria = ehDiaria;
            this.EhAdicional = ehAdicional;
        }

        public override bool Equals(object? obj)
        {
            return obj is Taxa taxa &&
                   Id.Equals(taxa.Id) &&
                   Descricao == taxa.Descricao &&
                   Valor == taxa.Valor &&
                   EhDiaria == taxa.EhDiaria &&
                   EhAdicional == taxa.EhAdicional &&
                   EqualityComparer<List<Locacao>>.Default.Equals(Locacoes, taxa.Locacoes) &&
                   EqualityComparer<List<Devolucao>>.Default.Equals(Devolucoes, taxa.Devolucoes);
        }

        public override string ToString()
        {
            return Descricao + " , R$" + Valor;
        }
    }
}
