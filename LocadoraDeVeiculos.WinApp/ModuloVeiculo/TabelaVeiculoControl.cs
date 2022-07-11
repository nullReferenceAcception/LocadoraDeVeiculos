using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public partial class TabelaVeiculoControl : UserControl
    {
        public TabelaVeiculoControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cor", HeaderText = "Cor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Ano", HeaderText = "Ano"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Combustivel", HeaderText = "Combustível"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CapacidadeTanque", HeaderText = "Capac. tanque"},

                new DataGridViewTextBoxColumn { DataPropertyName = "KmPercorrido", HeaderText = "Km percorridos"},

                new DataGridViewTextBoxColumn { DataPropertyName = "GrupoVeiculos", HeaderText = "Grupo de Veículos"},

                new DataGridViewImageColumn { DataPropertyName = "Foto", HeaderText = "Foto"}
            };

            return colunas;
        }

        public Guid ObtemGuidVeiculoSelecionado()
        {
            return grid.ObterGuid<Guid>();
        }

        public void AtualizarRegistros(List<Veiculo> veiculos)
        {
            grid.Rows.Clear();

            foreach (Veiculo veiculo in veiculos)

                grid.Rows.Add(veiculo.guid, veiculo.Modelo, veiculo.Marca, veiculo.Placa, veiculo.Cor, veiculo.Ano, veiculo.Combustivel, veiculo.CapacidadeTanque, veiculo.KmPercorrido, veiculo.GrupoVeiculos, veiculo.Foto);
        }
    }
}
