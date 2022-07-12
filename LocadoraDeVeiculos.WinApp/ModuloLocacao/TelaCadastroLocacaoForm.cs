using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public partial class TelaCadastroLocacaoForm : Form
    {
        public TelaCadastroLocacaoForm()
        {
            InitializeComponent();
            this.ConfigurarTela();
        }

        private void labelNome_Click(object sender, EventArgs e)
        {
            labelNome.Focus();
        }

        private void labelCliente_Click(object sender, EventArgs e)
        {
            comboBoxCliente.DroppedDown = true;
            comboBoxCliente.SelectedIndex = 0;
            comboBoxCliente.Select();
        }

        private void labelVeiculo_Click(object sender, EventArgs e)
        {
            comboBoxVeiculo.DroppedDown = true;
            comboBoxVeiculo.SelectedIndex = 0;
            comboBoxVeiculo.Select();
        }

        private void labelDataLocacao_Click(object sender, EventArgs e)
        {
            dateTimePickerDataLocacao.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void labelDevolucao_Click(object sender, EventArgs e)
        {
            dateTimePickerDataPrevistaDevolucao.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void labelPlanoCobranca_Click(object sender, EventArgs e)
        {
            comboBoxPlanoCobranca.DroppedDown = true;
            comboBoxPlanoCobranca.SelectedIndex = 0;
            comboBoxPlanoCobranca.Select();
        }
    }
}
