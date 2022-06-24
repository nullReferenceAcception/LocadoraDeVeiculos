using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public partial class TelaCadastroFuncionarioForm : Form
    {
        private Funcionario? _funcionario;
        public Funcionario? Funcionario
        {
            get { return _funcionario; }
            set
            {
                _funcionario = value!;
                ConfigurarTelaEditar();
            }
        }

        public TelaCadastroFuncionarioForm()
        {
            InitializeComponent();
            this.ConfigurarTela();
        }

        public Func<Funcionario, ValidationResult>? GravarRegistro { get; set; }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            Funcionario!.Nome = textBoxNome.Text;
            Funcionario!.Email = textBoxEmail.Text;
            Funcionario!.Telefone = textBoxTelefone.Text;
            Funcionario!.Endereco = textBoxEndereco.Text;
            Funcionario!.Login = textBoxLogin.Text;
            Funcionario!.Senha = textBoxSenha.Text;
            Funcionario!.DataAdmissao = dateTimePickerDataAdmissao.Value;
            Funcionario!.Salario = Convert.ToDecimal(textBoxSalario.Text);
            Funcionario!.EhAdmin = radioButtonAdmin.Checked == true ? Funcionario.EhAdmin = true : Funcionario.EhAdmin = false;

            var resultado = GravarRegistro!(Funcionario);

            if(!resultado.IsValid)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape(resultado.Errors[0].ErrorMessage);
                DialogResult = DialogResult.None;
            }
        }

        private void ConfigurarTelaEditar()
        {
            textBoxNome.Text = _funcionario!.Nome;
            textBoxEmail.Text = _funcionario.Email;
            textBoxTelefone.Text = _funcionario.Telefone;
            textBoxEndereco.Text = _funcionario.Endereco;
            textBoxLogin.Text = _funcionario.Login;
            textBoxSalario.Text = Convert.ToDecimal(_funcionario.Salario).ToString();
            textBoxSenha.Text = _funcionario.Senha;
            if (_funcionario.DataAdmissao > DateTime.MinValue)
                dateTimePickerDataAdmissao.Value = _funcionario.DataAdmissao;

            if(_funcionario.Id != 0)
                _ = _funcionario.EhAdmin ? radioButtonAdmin.Checked = true : radioButtonFuncionario.Checked = true;
        }
    }
}
