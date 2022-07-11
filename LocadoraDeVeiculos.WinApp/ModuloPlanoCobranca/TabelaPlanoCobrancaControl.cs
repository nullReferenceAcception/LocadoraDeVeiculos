using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoCobranca
{
    public partial class TabelaPlanoCobrancaControl : UserControl
    {
        public TabelaPlanoCobrancaControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "KM livre incluso", HeaderText = "KM livre incluso"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Valor dia", HeaderText = "Valor dia"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Valor por Km", HeaderText = "Valor por Km" },

                new DataGridViewTextBoxColumn { DataPropertyName = "Grupo de veiculo", HeaderText = "Grupo de veiculo" },

                new DataGridViewTextBoxColumn { DataPropertyName = "Tipo do plano", HeaderText = "Plano" },

        };

            return colunas;
        }

        public Guid ObtemGuidPlanoCobrancaSelecionada()
        {
            return grid.ObterGuid<Guid>();
        }

        public void AtualizarRegistros(List<PlanoCobranca> PlanoCobrancas)
        {
            grid.Rows.Clear();

            foreach (PlanoCobranca PlanoCobranca in PlanoCobrancas)
                    grid.Rows.Add(PlanoCobranca.Guid, PlanoCobranca.Nome, PlanoCobranca.KmLivreIncluso, PlanoCobranca.ValorDia, PlanoCobranca.ValorPorKm, PlanoCobranca.GrupoVeiculos.Nome, PlanoCobranca.Plano);
        }
    }
}
