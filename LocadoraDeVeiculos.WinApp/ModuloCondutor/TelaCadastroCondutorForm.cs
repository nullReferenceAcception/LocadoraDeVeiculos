using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public partial class TelaCadastroCondutorForm : Form
    {
        private Condutor? _Condutor;
        private IServicoCliente servicoCliente;
        public TelaCadastroCondutorForm(IServicoCliente servicoCliente)
        {

            InitializeComponent();

            this.servicoCliente = servicoCliente;
            comboBoxEmpresa.DataSource = servicoCliente.SelecionarTodosClientesQueSaoPessoaFisica();
        }

        public Condutor? Condutor
        {
            get { return _Condutor; }
            set
            {
                _Condutor = value!;    
                ConfigurarTelaEditar();
            }
        }

        public Func<Condutor, ValidationResult>? GravarRegistro { get; set; }

        private void ConfigurarTelaEditar()
        {
            textBoxID.Text = _Condutor!.Id.ToString();
            textBoxNome.Text = _Condutor!.Nome;
            textBoxEndereco.Text = _Condutor.Endereco;
            maskedTextBoxCNH.Text = _Condutor.CNH;
            if (_Condutor.Id != 0)
                dateTimePickerValidadeCNH.Value = _Condutor.DataValidadeCNH;
            textBoxEmail.Text = _Condutor.Email;
            maskedTextBoxTelefone.Text = _Condutor.Telefone;

           
        }

        private void ObterDadosDaTela()
        {
            _Condutor!.Nome = textBoxNome.Text;
            _Condutor.Endereco = textBoxEndereco.Text;
            _Condutor.CNH = maskedTextBoxCNH.Text;
            _Condutor.DataValidadeCNH = dateTimePickerValidadeCNH.Value;
            _Condutor.CPF = maskedTextBoxCPF.Text;
            _Condutor.Email = textBoxEmail.Text;
            _Condutor.Telefone = maskedTextBoxTelefone.Text;
        }

 

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            ObterDadosDaTela();

            var resultadoValidacao = GravarRegistro!(_Condutor!);

            if (!resultadoValidacao.IsValid)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape(resultadoValidacao.Errors[0].ErrorMessage);
                DialogResult = DialogResult.None;
            }
        }

        private void comboBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
