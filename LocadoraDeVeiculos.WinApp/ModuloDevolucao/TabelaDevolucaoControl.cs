using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    public partial class TabelaDevolucaoControl : UserControl
    {
        public TabelaDevolucaoControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "PlanoCobranca", HeaderText = "Plano de cobrança"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataLocacao", HeaderText = "Locação"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataDevolucaoPrevista", HeaderText = "Data dev. prevista:"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataDevolucao", HeaderText = "Data dev. real"},
            };

            return colunas;
        }

        public Guid ObtemGuidDevolucaoSelecionada()
        {
            return grid.ObterId<Guid>();
        }

        public void AtualizarRegistros(List<Devolucao> devolucoes)
        {
            grid.Rows.Clear();

            foreach (Devolucao devolucao in devolucoes)
                grid.Rows.Add(devolucao.Id, devolucao.Locacao.Funcionario.Nome, devolucao.Locacao.Cliente.Nome, devolucao.Locacao.Condutor.Nome, devolucao.Locacao.Veiculo.Modelo, devolucao.Locacao.PlanoCobranca, devolucao.Locacao.DataLocacao, devolucao.Locacao.DataDevolucaoPrevista, devolucao.DataDevolucaoReal);
        }
    }
}
