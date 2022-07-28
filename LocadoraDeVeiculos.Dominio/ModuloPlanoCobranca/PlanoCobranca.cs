using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca
{
    public class PlanoCobranca : EntidadeBase<PlanoCobranca>
    {
        public string Nome { get; set; }
        public int KmLivreIncluso { get; set; }
        public decimal ValorDia { get; set; }
        public decimal ValorPorKm { get; set; }
        public GrupoVeiculos GrupoVeiculos { get; set; }
        public Guid GrupoVeiculosId { get; set; }
        public PlanoEnum Plano { get; set; }
        
        public PlanoCobranca()
        {

        }
        public override string ToString()
        {
            return Nome;
        }
        public PlanoCobranca(string nome, int kmLivreIncluso, decimal valorDia, decimal valorPorKm, PlanoEnum planoEnum , GrupoVeiculos GrupoVeiculos)
        {
            Nome = nome;
            KmLivreIncluso = kmLivreIncluso;
            ValorDia = valorDia;
            ValorPorKm = valorPorKm;
            this.GrupoVeiculos = GrupoVeiculos;
            this.Plano = planoEnum;
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
                   GrupoVeiculosId == cobranca.GrupoVeiculosId &&
                   ValorPorKm == cobranca.ValorPorKm;
        }
    }
}
