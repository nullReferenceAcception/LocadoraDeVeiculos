using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculo
{
    public partial class TabelaGrupoVeiculoControl : UserControl
    {
        public TabelaGrupoVeiculoControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descrição"}
            };

            return colunas;
        }

        public int ObtemNumeroSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<GrupoVeiculos> registros)
        {
            grid.Rows.Clear();

            foreach (GrupoVeiculos registro in registros)
                grid.Rows.Add(registro.Id, registro.Nome);
        }
    }
}
