using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System;
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Guid", HeaderText = "Guid", MinimumWidth = 185},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "E-mail"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Login", HeaderText = "Login" },

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone" },

                new DataGridViewTextBoxColumn { DataPropertyName = "DataAdmissao", HeaderText = "Data de Admissão" },

                new DataGridViewTextBoxColumn { DataPropertyName = "Salario", HeaderText = "Salário"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereço" },

                new DataGridViewTextBoxColumn { DataPropertyName = "Cidade", HeaderText = "Cidade" }
            };

            return colunas;
        }

        public Guid ObtemGuidFuncionarioSelecionado()
        {
            return grid.ObterGuid<Guid>();
        }

        public void AtualizarRegistros(List<Funcionario> funcionarios)
        {
            grid.Rows.Clear();

            foreach (Funcionario funcionario in funcionarios)
                grid.Rows.Add(funcionario.Guid, funcionario.Nome, funcionario.Email, funcionario.Login, double.Parse(funcionario.Telefone), funcionario.DataAdmissao.ToShortDateString(), "R$ " + funcionario.Salario, funcionario.Endereco,  funcionario.Cidade);
            this.grid.Columns[4].DefaultCellStyle.Format = "(##) #####-####";
        }
    }
}
