using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public partial class TelaCadastroClienteForm : Form
    {
        private Cliente? _cliente;

        public Cliente? cliente
        {
            get { return _cliente; }
            set
            {
                _cliente = value!;
                ConfigurarTelaEditar();
            }
        }

        public TelaCadastroClienteForm()
        {
            InitializeComponent();
            textBoxNome.Focus();
        }

        public Func<Cliente, ValidationResult>? GravarRegistro { get; set; }

        private void ConfigurarTelaEditar()
        {
            textBoxID.Text = _cliente!.Id.ToString();
            textBoxNome.Text = _cliente!.Nome;
            textBoxEndereco.Text = _cliente.Endereco;
            maskedTextBoxCNH.Text = _cliente.CNH;
            textBoxEmail.Text = _cliente.Email;
            maskedTextBoxTelefone.Text = _cliente.Telefone;

            if (_cliente.Id != 0)
            {
                if (string.IsNullOrEmpty(_cliente.CPF))
                {
                    maskedTextBoxCNPJ.Text = _cliente.CNPJ;
                    radioButtonCNPJ.Checked = true;
                }
                else
                {
                    maskedTextBoxCPF.Text = _cliente.CPF;
                    radioButtonCPF.Checked = true;
                    dateTimePickerValidadeCNH.Value = _cliente.DataValidadeCNH;
                }
            }
        }

        private void ObterDadosDaTela()
        {
            _cliente!.Nome = textBoxNome.Text;
            _cliente.Endereco = textBoxEndereco.Text;
            _cliente.CNH = maskedTextBoxCNH.Text;
            _cliente.CNPJ = maskedTextBoxCNPJ.Text;
            _cliente.CPF = maskedTextBoxCPF.Text;
            _cliente.Email = textBoxEmail.Text;
            _cliente.Telefone = maskedTextBoxTelefone.Text;
            _cliente.PessoaFisica = radioButtonCPF.Checked == true ? _cliente.PessoaFisica = true : _cliente.PessoaFisica = false;
            _cliente.DataValidadeCNH = dateTimePickerValidadeCNH.Value;

            if (_cliente.PessoaFisica)
                _cliente.CNPJ = null!;
            else
                _cliente.CPF = null!;
        }

        private void radioCPFbtn_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBoxCNH.Enabled = true;
            maskedTextBoxCPF.Enabled = true;
            maskedTextBoxCNPJ.Enabled = false;
            maskedTextBoxCNPJ.Clear();
            maskedTextBoxCPF.Focus();
        }

        private void radioCNPJbtn_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBoxCNH.Enabled = false;
            maskedTextBoxCNPJ.Enabled = true;
            maskedTextBoxCPF.Enabled = false;
            maskedTextBoxCPF.Clear();
            maskedTextBoxCNPJ.Focus();
            maskedTextBoxCNH.Clear();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ObterDadosDaTela();

            var resultadoValidacao = GravarRegistro!(_cliente!);

            if (!resultadoValidacao.IsValid)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape(resultadoValidacao.Errors[0].ErrorMessage);
                DialogResult = DialogResult.None;
            }
        }
    }
}
