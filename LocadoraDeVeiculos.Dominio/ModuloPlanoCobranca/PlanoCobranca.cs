using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca
{
    public class PlanoCobranca : EntidadeBase<PlanoCobranca>
    {
        public string Nome { get; set; }
        public int KmLivreIncluso { get; set; }
        public decimal ValorDia { get; set; }
        public decimal ValorPorKm { get; set; }
        public GrupoVeiculos GrupoVeiculos { get; set; }

        public PlanoCobranca()
        {

        }

        public PlanoCobranca(string nome, int kmLivreIncluso, decimal valorDia, decimal valorPorKm, GrupoVeiculos GrupoVeiculos)
        {
            Nome = nome;
            KmLivreIncluso = kmLivreIncluso;
            ValorDia = valorDia;
            ValorPorKm = valorPorKm;
            this.GrupoVeiculos = GrupoVeiculos;
        }

        public PlanoCobranca(string nome, int kmLivreIncluso, decimal valorDia, decimal valorPorKm)
        {
            Nome = nome;
            KmLivreIncluso = kmLivreIncluso;
            ValorDia = valorDia;
            ValorPorKm = valorPorKm;
        }

        public override bool Equals(object? obj)
        {
            return obj is PlanoCobranca cobranca &&
                   Id == cobranca.Id &&
                   Nome == cobranca.Nome &&
                   KmLivreIncluso == cobranca.KmLivreIncluso &&
                   ValorDia == cobranca.ValorDia &&
                   ValorPorKm == cobranca.ValorPorKm;
        }
    }
}
