using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
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

        private void ConfigurarTelaEditar()
        {
            textBoxNome.Text = _cliente.Nome;
            textBoxEndereco.Text = _cliente.Endereco;
            textBoxCNH.Text = _cliente.CNH;
            //textBoxCNPJ.Text = _cliente.CNPJ;
            //textBoxCPF.Text = _cliente.CPF;
            textBoxEmail.Text = _cliente.Email;
            textBoxTelefone.Text = _cliente.Telefone;
            //radioCPFbtn.Checked = _cliente.PessoaFisica == true ? true : false;
            //radioCNPJbtn.Checked = _cliente.PessoaFisica == false ? false : true;

            if(string.IsNullOrEmpty(_cliente.CPF))
            {
                textBoxCNPJ.Text = _cliente.CNPJ;
                radioCNPJbtn.Checked = true;
            }

            else
            {
                textBoxCPF.Text = _cliente.CPF;
                radioCPFbtn.Checked = true;
            }
        }

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

        public Func<Cliente, ValidationResult>? GravarRegistro { get; set; }

       

        private void btnGravar_Click(object sender, EventArgs e)
        {
            _cliente!.Nome = textBoxNome.Text;
            _cliente.Endereco = textBoxEndereco.Text;
            _cliente.CNH = textBoxCNH.Text;
            _cliente.CNPJ = textBoxCNPJ.Text;
            _cliente.CPF = textBoxCPF.Text;
            _cliente.Email = textBoxEmail.Text;
            _cliente.Telefone = textBoxTelefone.Text;
            _cliente.PessoaFisica = radioCPFbtn.Checked == true ? _cliente.PessoaFisica = true : _cliente.PessoaFisica = false;


            if (_cliente.PessoaFisica)
                _cliente.CNPJ = null;

            else
                _cliente.CPF = null;

            var resultadoValidacao = GravarRegistro!(_cliente);



            if (!resultadoValidacao.IsValid)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape(resultadoValidacao.Errors[0].ErrorMessage);
                DialogResult = DialogResult.None;
            }
        }
    }
}
