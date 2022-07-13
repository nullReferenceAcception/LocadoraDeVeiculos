using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    public partial class TelaCadastroDevolucaoForm : Form
    {
        public TelaCadastroDevolucaoForm()
        {
            InitializeComponent();
            this.ConfigurarTela();
            this.AjustarLabelsHover();
        }

        private void labelLocacao_Click(object sender, EventArgs e)
        {
            comboBoxLocacao.DroppedDown = true;
            comboBoxLocacao.SelectedIndex = 0;
            comboBoxLocacao.Select();
        }

        private void labelTanque_Click(object sender, EventArgs e)
        {
            textBoxTanque.Focus();
        }

        private void labelDataDevolucao_Click(object sender, EventArgs e)
        {
            dateTimePickerDataDevolucao.Select();
            SendKeys.Send("%{DOWN}");
        }
    }
}
