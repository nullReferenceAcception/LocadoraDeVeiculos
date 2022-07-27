﻿using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloLocacao
{
    public class Locacao : EntidadeBase<Locacao>
    {
        public Locacao()
        {
        }

        public Locacao(Funcionario funcionario, Cliente cliente,
            Condutor condutor, Veiculo veiculo, PlanoCobranca planoCobranca,
            DateTime dataLocacao, DateTime dataDevolucao, List<Taxa> taxas, bool estaAtivo)
        {
            Funcionario = funcionario;
            Cliente = cliente;
            Condutor = condutor;
            Veiculo = veiculo;
            PlanoCobranca = planoCobranca;
            DataLocacao = dataLocacao;
            DataDevolucaoPrevista = dataDevolucao;
            Taxas = taxas;
            EstaAtivo = estaAtivo;
        }

      public Funcionario Funcionario { get; set; }
      public Guid FuncionarioId { get; set; }
      public Cliente Cliente { get; set; }
      public Guid ClienteId { get; set; }
      public Condutor Condutor { get; set; }
      public Guid CondutorId { get; set; }
      public Veiculo Veiculo { get; set; }
      public Guid VeiculoId { get; set; }
      public PlanoCobranca PlanoCobranca { get; set; }
      public Guid PlanoCobrancaId { get; set; }
      public DateTime DataLocacao { get; set; }
      public DateTime DataDevolucaoPrevista { get; set; }
      public List<Taxa> Taxas { get; set; }
      public bool EstaAtivo { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Locacao locacao &&
                   Id.Equals(locacao.Id) &&
                   EqualityComparer<Funcionario>.Default.Equals(Funcionario, locacao.Funcionario) &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, locacao.Cliente) &&
                   EqualityComparer<Condutor>.Default.Equals(Condutor, locacao.Condutor) &&
                   EqualityComparer<Veiculo>.Default.Equals(Veiculo, locacao.Veiculo) &&
                   EqualityComparer<PlanoCobranca>.Default.Equals(PlanoCobranca, locacao.PlanoCobranca) &&
                   DataLocacao == locacao.DataLocacao &&
                   DataDevolucaoPrevista == locacao.DataDevolucaoPrevista &&
                   EstaAtivo == locacao.EstaAtivo &&
                  CompararTaxas(locacao);
        }

        private bool CompararTaxas(Locacao locacao)
        {
            if (Taxas.Count != locacao.Taxas.Count)
                return false;
           for (int i = 0; i < Taxas.Count; i++)
            {
                if(EqualityComparer<Taxa>.Default.Equals(Taxas[i], locacao.Taxas[i]))
                    return false;
            }
            return true;
        }
    }
}
