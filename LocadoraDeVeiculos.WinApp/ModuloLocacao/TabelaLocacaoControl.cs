using LocadoraDeVeiculos.Dominio.ModuloLocacao;
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Guid", HeaderText = "Guid", MinimumWidth = 185},

                new DataGridViewTextBoxColumn { DataPropertyName = "Funcionario", HeaderText = "Funcionário"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Condutor", HeaderText = "Condutor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Veiculo", HeaderText = "Veículo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "PlanoCobranca", HeaderText = "Plano de Cobrança"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Data de Locacao", HeaderText = "Data de Locação"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Data de devolucao prevista", HeaderText = "Data de dev. prev."},

                new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status"},
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
                grid.Rows.Add(locacao.Id, locacao.Funcionario.Nome, locacao.Cliente.Nome, locacao.Condutor == null ? locacao.Cliente.Nome : locacao.Condutor.Nome, locacao.Veiculo.Modelo, locacao.PlanoCobranca.Nome, locacao.DataLocacao, locacao.DataDevolucaoPrevista, locacao.Status);
        }
    }
}
