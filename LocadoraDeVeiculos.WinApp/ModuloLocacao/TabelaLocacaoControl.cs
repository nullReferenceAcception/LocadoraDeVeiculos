﻿using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public partial class TabelaLocacaoControl : UserControl
    {
        public TabelaLocacaoControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }
        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Guid", HeaderText = "Guid"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Funcionario", HeaderText = "Funcionario"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Condutor", HeaderText = "Condutor"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Veiculo", HeaderText = "Veiculo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "PlanoCobranca", HeaderText = "PlanoCobranca"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Data de Locacao", HeaderText = "Data de Locacao"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Data de devolucao prevista", HeaderText = "Data de devolucao prevista"},

            };

            return colunas;
        }

        public Guid ObtemGuidLocacaoSelecionado()
        {
            return grid.ObterId<Guid>();
        }

        public void AtualizarRegistros(List<Locacao> locacoes)
        {
            grid.Rows.Clear();

            foreach (Locacao locacao in locacoes)
                grid.Rows.Add(locacao.Id, locacao.Funcionario.Nome, locacao.Cliente.Nome, locacao.Condutor.Nome, locacao.Veiculo.Placa, locacao.PlanoCobranca.Nome, locacao.DataLocacao, locacao.DataDevolucaoPrevista);
        }
    }
}
