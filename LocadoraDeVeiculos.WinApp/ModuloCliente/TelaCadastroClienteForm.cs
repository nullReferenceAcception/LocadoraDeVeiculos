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
    public partial class TelaCadastroClienteForm : Form
    {
        public TelaCadastroClienteForm()
        {
            InitializeComponent();
        }

        private void radioCPFbtn_CheckedChanged(object sender, EventArgs e)
        {
            
            textBoxCPF.Enabled = true;
            textBoxCNPJ.Enabled = false;
            textBoxCNPJ.Clear();
            textBoxCPF.Focus();
        }

        private void radioCNPJbtn_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCNPJ.Enabled = true;
            textBoxCPF.Enabled = false;
            textBoxCPF.Clear();
            textBoxCNPJ.Focus();
            
        }
    }
}
