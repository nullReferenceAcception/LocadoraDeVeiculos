using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public partial class TabelaFuncionarioControl : UserControl
    {
        public TabelaFuncionarioControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Login", HeaderText = "Login" },

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone" },

                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereço" },

                new DataGridViewTextBoxColumn { DataPropertyName = "DataAdmissao", HeaderText = "Data de Admissão" }
            };

            return colunas;
        }

        public int ObtemNumeroFuncionarioSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Funcionario> funcionarios)
        {
            grid.Rows.Clear();

            foreach (Funcionario funcionario in funcionarios)
                grid.Rows.Add(funcionario.Id, funcionario.Nome, funcionario.Login, funcionario.Telefone, funcionario.Endereco, funcionario.DataAdmissao);
        }
    }
}
