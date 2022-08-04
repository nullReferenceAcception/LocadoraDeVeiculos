using Locadora.Infra.Configs;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
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
        public decimal KmRodados { get; set; }

        public decimal CalcularTotal(ConfiguracaoAplicacaoLocadora configuracao)
        {
            int totalDias = (int)Math.Ceiling((DataDevolucaoReal.Date - Locacao.DataLocacao.Date).TotalDays);

            decimal valorTotal = Locacao.PlanoCobranca.ValorDia * totalDias;

            decimal totalKm = KmRodados - Locacao.PlanoCobranca.KmLivreIncluso;

            if (totalKm > 0)
                valorTotal += Locacao.PlanoCobranca.ValorPorKm * totalKm;

            foreach (Taxa item in Locacao.Taxas)
            {
                if (item.EhDiaria)
                    valorTotal += item.Valor * totalDias;
                else
                    valorTotal += item.Valor;
            }

            foreach (Taxa item in TaxasAdicionais)
            {
                if (item.EhDiaria)
                    valorTotal += item.Valor * totalDias;
                else
                    valorTotal += item.Valor;
            }

            if (DataDevolucaoReal.Date > Locacao.DataDevolucaoPrevista.Date)
                valorTotal += valorTotal * 0.10m;

            var custoCombustivel = 0m;

            switch (Locacao.Veiculo.Combustivel)
            {
                case CombustivelEnum.Diesel:
                    custoCombustivel = Decimal.Parse(configuracao.PrecoCombustiveis.Diesel);
                    break;
                case CombustivelEnum.Gasolina:
                    custoCombustivel = Decimal.Parse(configuracao.PrecoCombustiveis.Gasolina);
                    break;
                case CombustivelEnum.Álcool:
                    custoCombustivel = Decimal.Parse(configuracao.PrecoCombustiveis.Alcool);
                    break;
                case CombustivelEnum.Etanol:
                    custoCombustivel = Decimal.Parse(configuracao.PrecoCombustiveis.Etanol);
                    break;
                case CombustivelEnum.GNV:
                    custoCombustivel = Decimal.Parse(configuracao.PrecoCombustiveis.GNV);
                    break;
            }

            var tamanhoTanque = Locacao.Veiculo.CapacidadeTanque;

            switch (Tanque)
            {
                case TanqueEnum.Cheio:
                    break;
                case TanqueEnum.TresQuartos:
                    var umQuarto = tamanhoTanque / 4;
                    valorTotal += umQuarto * custoCombustivel;
                    break;
                case TanqueEnum.Meio:
                    var meio = tamanhoTanque / 2;
                    valorTotal += meio * custoCombustivel;
                    break;
                case TanqueEnum.UmQuarto:
                    var tresQuartos = tamanhoTanque * 3 / 4;
                    valorTotal += tresQuartos * custoCombustivel;
                    break;
                case TanqueEnum.Vazio:
                    valorTotal += tamanhoTanque * custoCombustivel;
                    break;
            }

            return valorTotal;
        }

        public Devolucao()
        {
            TaxasAdicionais = new();
        }

        public Devolucao(Locacao locacao, Guid locacaoId, DateTime dataDevolucaoReal,
            List<Taxa> taxasAdicionais, TanqueEnum tanque, decimal valorTotalReal, decimal kmRodados)
        {
            Locacao = locacao;
            LocacaoId = locacaoId;
            DataDevolucaoReal = dataDevolucaoReal;
            TaxasAdicionais = taxasAdicionais;
            Tanque = tanque;
            ValorTotalReal = valorTotalReal;
            KmRodados = kmRodados;
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
                if (!EqualityComparer<Taxa>.Default.Equals(TaxasAdicionais[i], devolucao.TaxasAdicionais[i]))
                    return false;

            return true;
        }
    }
}
