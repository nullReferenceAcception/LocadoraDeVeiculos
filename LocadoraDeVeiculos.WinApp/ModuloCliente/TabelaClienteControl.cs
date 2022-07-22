using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public partial class TabelaClienteControl : UserControl
    {
        public TabelaClienteControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Endereço", HeaderText = "Endereço"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CNH", HeaderText = "CNH"},

                new DataGridViewTextBoxColumn { DataPropertyName = "E-mail", HeaderText = "E-mail"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CPF/CNPJ", HeaderText = "CPF/CNPJ"}

            };
            return colunas;
        }

        public Guid ObtemGuidClienteSelecionado()
        {
            return grid.ObterId<Guid>();
        }

        public void AtualizarRegistros(List<Cliente> clientes)
        {
            grid.Rows.Clear();
            foreach (Cliente cliente in clientes)
            {
                if (cliente.CNPJ == null)
                {
                    grid.Rows.Add(cliente.Id, cliente.Nome, cliente.Endereco, double.Parse(cliente.Telefone), cliente.CNH, cliente.Email, double.Parse(cliente.CPF));
                    this.grid.Columns[6].DefaultCellStyle.Format = @"000\.000\.000\-00";
                }
                else
                {
                    grid.Rows.Add(cliente.Id, cliente.Nome, cliente.Endereco, double.Parse(cliente.Telefone), "Não cadastrado", cliente.Email, double.Parse(cliente.CNPJ));
                    this.grid.Columns[6].DefaultCellStyle.Format = @"00\.000\.000\/0000\-00";
                }
                this.grid.Columns[3].DefaultCellStyle.Format = "(##) #####-####";
            }
        }
    }
}
