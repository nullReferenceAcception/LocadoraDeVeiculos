using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Endereço", HeaderText = "Endereço"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CNH", HeaderText = "CNH"},

                new DataGridViewTextBoxColumn { DataPropertyName = "E-mail", HeaderText = "E-mail"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CPF/CNPJ", HeaderText = "CPF/CNPJ"}

        };
            return colunas;
        }

        public int ObtemNumeroClienteSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Cliente> clientes)
        {
            grid.Rows.Clear();
            //TODO arrumar mascara para o telefone e CNPJ/CPF aqui
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
