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
            textBoxID.Text = Cliente.Id.ToString();
            textBoxNome.Text = Cliente.Nome;
            textBoxEndereco.Text = Cliente.Endereco;
            maskedTextBoxCNH.Text = Cliente.CNH;
            textBoxEmail.Text = Cliente.Email;
            maskedTextBoxTelefone.Text = Cliente.Telefone;

            if (Cliente.Id != 0)
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
    }
}
