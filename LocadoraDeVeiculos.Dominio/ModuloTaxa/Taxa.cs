using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public class Taxa : EntidadeBase<Taxa>
    {
        public string? Descricao { get; set; }
        public decimal? Valor { get; set; }

        public override void Atualizar(Taxa registro)
        {
            this.Descricao = registro.Descricao;
            this.Valor = registro.Valor;
        }
        public override bool Equals(object? obj)
        {
            return obj is Taxa taxa &&
                   Id == taxa.Id &&
                   Descricao == taxa.Descricao &&
                   Valor == taxa.Valor;
        }
    }
}
