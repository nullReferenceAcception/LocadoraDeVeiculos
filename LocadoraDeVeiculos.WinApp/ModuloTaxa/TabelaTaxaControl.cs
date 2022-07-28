using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public partial class TabelaTaxaControl : UserControl
    {
        public TabelaTaxaControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descrição"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Tipo", HeaderText = "Tipo"}
            };

            return colunas;
        }

        public Guid ObtemGuidTaxaSelecionada()
        {
            return grid.ObterId<Guid>();
        }

        public void AtualizarRegistros(List<Taxa> taxas)
        {
            grid.Rows.Clear();
            foreach (Taxa taxa in taxas)
                if (taxa.EhDiaria)
                    grid.Rows.Add(taxa.Id, taxa.Descricao, taxa.Valor, "Diária");
                else
                    grid.Rows.Add(taxa.Id, taxa.Descricao, taxa.Valor, "Fixo");
        }
    }
}
