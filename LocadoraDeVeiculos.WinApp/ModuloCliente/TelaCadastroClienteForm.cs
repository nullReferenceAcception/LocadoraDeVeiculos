using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public partial class TelaCadastroClienteForm : Form
    {
        private Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set
            {
                _cliente = value;
                ConfigurarTelaEditar();
            }
        }

        public TelaCadastroClienteForm()
        {
            InitializeComponent();
            this.ConfigurarTela();
            ConfigurarComponentes();
        }

        public Func<Cliente, ValidationResult> GravarRegistro { get; set; }

        private void ConfigurarTelaEditar()
        {
            textBoxGuid.Text = Cliente.Guid.ToString();
            textBoxNome.Text = Cliente.Nome;
            textBoxEndereco.Text = Cliente.Endereco;
            maskedTextBoxCNH.Text = Cliente.CNH;
            textBoxEmail.Text = Cliente.Email;
            maskedTextBoxTelefone.Text = Cliente.Telefone;

            if (Cliente.Guid != Guid.Empty)
            {
                if (string.IsNullOrEmpty(Cliente.CPF))
                {
                    maskedTextBoxCNPJ.Text = Cliente.CNPJ;
                    radioButtonCNPJ.Checked = true;
                }
                else
                {
                    maskedTextBoxCPF.Text = Cliente.CPF;
                    radioButtonCPF.Checked = true;
                    dateTimePickerValidadeCNH.Value = Cliente.DataValidadeCNH;
                }
            }
        }

        private void ObterDadosDaTela()
        {
            Cliente.Nome = textBoxNome.Text;
            Cliente.Endereco = textBoxEndereco.Text;
            Cliente.CNH = maskedTextBoxCNH.Text;
            Cliente.CNPJ = maskedTextBoxCNPJ.Text;
            Cliente.CPF = maskedTextBoxCPF.Text;
            Cliente.Email = textBoxEmail.Text;
            Cliente.Telefone = maskedTextBoxTelefone.Text;
            Cliente.PessoaFisica = radioButtonCPF.Checked == true ? Cliente.PessoaFisica = true : Cliente.PessoaFisica = false;
            Cliente.DataValidadeCNH = dateTimePickerValidadeCNH.Value;

            if (Cliente.PessoaFisica)
                Cliente.CNPJ = null!;
            else
                Cliente.CPF = null!;
        }

        private void radioCPFbtn_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBoxCNH.Enabled = true;
            maskedTextBoxCPF.Enabled = true;
            maskedTextBoxCNPJ.Enabled = false;
            dateTimePickerValidadeCNH.EstadoDeHabilitacao(true);
            maskedTextBoxCNPJ.Clear();
            maskedTextBoxCPF.Focus();
            labelCNPJ.Cursor = DefaultCursor;
            labelCPF.Cursor = Cursors.Hand;
            labelCNH.Cursor = Cursors.Hand;
            labelValidadeCNH.Cursor = Cursors.Hand;
        }

        private void radioCNPJbtn_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBoxCNH.Enabled = false;
            maskedTextBoxCNPJ.Enabled = true;
            maskedTextBoxCPF.Enabled = false;
            dateTimePickerValidadeCNH.EstadoDeHabilitacao(false);
            maskedTextBoxCPF.Clear();
            maskedTextBoxCNPJ.Focus();
            maskedTextBoxCNH.Clear();
            labelCPF.Cursor = DefaultCursor;
            labelCNH.Cursor = DefaultCursor;
            labelValidadeCNH.Cursor = DefaultCursor;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ObterDadosDaTela();

            var resultadoValidacao = GravarRegistro(Cliente);

            if (!resultadoValidacao.IsValid)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(resultadoValidacao.Errors[0].ErrorMessage, CorParaRodape.Red);
                DialogResult = DialogResult.None;
            }
        }

        private void ConfigurarComponentes()
        {
            textBoxNome.AceitaSoLetras();
            textBoxNome.Focus();
        }

        private void labelNome_Click(object sender, EventArgs e)
        {
            textBoxNome.Select();
        }

        private void labelEndereco_Click(object sender, EventArgs e)
        {
            textBoxEndereco.Select();
        }

        private void labelEmail_Click(object sender, EventArgs e)
        {
            textBoxEmail.Select();
        }

        private void labelTelefone_Click(object sender, EventArgs e)
        {
            maskedTextBoxTelefone.Select();
        }

        private void labelCPF_Click(object sender, EventArgs e)
        {
            maskedTextBoxCPF.Select();
        }

        private void labelCNPJ_Click(object sender, EventArgs e)
        {
            maskedTextBoxCNPJ.Select();
        }

        private void labelCNH_Click(object sender, EventArgs e)
        {
            maskedTextBoxCNH.Select();
        }

        private void labelValidadeCNH_Click(object sender, EventArgs e)
        {
            dateTimePickerValidadeCNH.Select();
            SendKeys.Send("%{DOWN}");
        }
    }
}
