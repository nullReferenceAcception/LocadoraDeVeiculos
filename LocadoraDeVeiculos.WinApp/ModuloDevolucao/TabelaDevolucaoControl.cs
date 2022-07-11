﻿using System.Windows.Forms;

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
                new DataGridViewTextBoxColumn { DataPropertyName = "guid", HeaderText = "guid"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo"},
            };

            return colunas;
        }

        public int ObtemGuidDevolucaoSelecionada()
        {
            return grid.ObterGuid<int>();
        }

        public void AtualizarRegistros(/**/)
        {
            //grid.Rows.Clear();

            //foreach (Devolucao devolucao in devolucoes)

            //    grid.Rows.Add();
        }
    }
}
