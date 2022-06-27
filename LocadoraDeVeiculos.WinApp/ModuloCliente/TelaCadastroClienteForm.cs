using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public partial class TelaCadastroClienteForm : Form
    {
        private Cliente? _cliente;

        public TelaCadastroClienteForm()
        {
            InitializeComponent();
        }

        public Cliente? cliente
        {
            get { return _cliente; }
            set
            {
                _cliente = value!;
                ConfigurarTelaEditar();
            }
        }

        public Func<Cliente, ValidationResult>? GravarRegistro { get; set; }

        private void ConfigurarTelaEditar()
        {
            textBoxNome.Text = _cliente!.Nome;
            textBoxEndereco.Text = _cliente.Endereco;
            textBoxCNH.Text = _cliente.CNH;
            textBoxEmail.Text = _cliente.Email;
            maskedTextBoxTelefone.Text = _cliente.Telefone;


            if(string.IsNullOrEmpty(_cliente.CPF))
            {
                maskedTextBoxCNPJ.Text = _cliente.CNPJ;
                radioButtonCNPJ.Checked = true;
            }

            else
            {
                maskedTextBoxCPF.Text = _cliente.CPF;
                radioButtonCPF.Checked = true;
            }
        }

        private void radioCPFbtn_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCNH.Enabled = true;
            maskedTextBoxCPF.Enabled = true;
            maskedTextBoxCNPJ.Enabled = false;
            maskedTextBoxCNPJ.Clear();
            maskedTextBoxCPF.Focus();
        }

        private void radioCNPJbtn_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCNH.Enabled = false;
            maskedTextBoxCNPJ.Enabled = true;
            maskedTextBoxCPF.Enabled = false;
            maskedTextBoxCPF.Clear();
            maskedTextBoxCNPJ.Focus();
            textBoxCNH.Clear();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            _cliente!.Nome = textBoxNome.Text;
            _cliente.Endereco = textBoxEndereco.Text;
            _cliente.CNH = textBoxCNH.Text;
            _cliente.CNPJ = maskedTextBoxCNPJ.Text;
            _cliente.CPF = maskedTextBoxCPF.Text;
            _cliente.Email = textBoxEmail.Text;
            _cliente.Telefone = maskedTextBoxTelefone.Text;
            _cliente.PessoaFisica = radioButtonCPF.Checked == true ? _cliente.PessoaFisica = true : _cliente.PessoaFisica = false;

            if (_cliente.PessoaFisica)
                _cliente.CNPJ = null!;

            else
                _cliente.CPF = null!;

            var resultadoValidacao = GravarRegistro!(_cliente);

            if (!resultadoValidacao.IsValid)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape(resultadoValidacao.Errors[0].ErrorMessage);
                DialogResult = DialogResult.None;
            }
        }
    }
}
