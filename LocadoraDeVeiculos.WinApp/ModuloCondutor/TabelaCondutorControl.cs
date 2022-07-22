using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public partial class TabelaCondutorControl : UserControl
    {
        public TabelaCondutorControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Endereço", HeaderText = "Endereço"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CNH", HeaderText = "CNH"},

                new DataGridViewTextBoxColumn { DataPropertyName = "E-mail", HeaderText = "E-mail"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CPF", HeaderText = "CPF"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Empresa", HeaderText = "Empresa"}

        };
            return colunas;
        }
        public Guid ObtemGuidCondutorSelecionado()
        {
            return grid.ObterId<Guid>();
        }

        public void AtualizarRegistros(List<Condutor> condutores)
        {
            grid.Rows.Clear();
            //TODO arrumar mascara para o telefone e CNPJ/CPF aqui
            foreach (Condutor condutor in condutores)
            {
                    grid.Rows.Add(condutor.Id, condutor.Nome, condutor.Endereco, double.Parse(condutor.Telefone), condutor.CNH, condutor.Email, double.Parse(condutor.CPF), condutor.Cliente.Nome);
                    this.grid.Columns[6].DefaultCellStyle.Format = @"000\.000\.000\-00";
                    this.grid.Columns[3].DefaultCellStyle.Format = "(##) #####-####";
            }
        }
    }
}
