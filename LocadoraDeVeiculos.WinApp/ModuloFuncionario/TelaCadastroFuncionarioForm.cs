﻿using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.Compartilhado;
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
            textBoxSalario.AplicarMascaraMoeda();
        }

        public Func<Funcionario, ValidationResult>? GravarRegistro { get; set; }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            ObterDadosDaTela();

            var resultado = GravarRegistro!(Funcionario!);

            if (!resultado.IsValid)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape(resultado.Errors[0].ErrorMessage);
                DialogResult = DialogResult.None;
            }
        }

        private void ObterDadosDaTela()
        {
            Funcionario!.Nome = textBoxNome.Text;
            Funcionario!.Email = textBoxEmail.Text;
            Funcionario!.Telefone = maskedTextBoxTelefone.Text;
            Funcionario!.Endereco = textBoxEndereco.Text;
            Funcionario!.Login = textBoxLogin.Text;
            Funcionario!.Senha = textBoxSenha.Text;
            Funcionario!.DataAdmissao = dateTimePickerDataAdmissao.Value;
            Funcionario!.Salario = Convert.ToDecimal(textBoxSalario.Text.ToString().Replace("R$", ""));
            Funcionario!.Cidade = textBoxCidade.Text;
            Funcionario!.EhAdmin = radioButtonAdmin.Checked == true ? Funcionario.EhAdmin = true : Funcionario.EhAdmin = false;
            Funcionario!.EstaAtivo = true;
        }

        private void ConfigurarTelaEditar()
        {
            textBoxID.Text = _funcionario!.Id.ToString();
            textBoxNome.Text = _funcionario!.Nome;
            textBoxEmail.Text = _funcionario.Email;
            maskedTextBoxTelefone.Text = _funcionario.Telefone;
            textBoxEndereco.Text = _funcionario.Endereco;
            textBoxLogin.Text = _funcionario.Login;
            textBoxSalario.Text = "R$ " + _funcionario.Salario.ToString();
            textBoxSenha.Text = _funcionario.Senha;
            textBoxCidade.Text = _funcionario.Cidade;

            if (_funcionario.DataAdmissao > DateTime.MinValue)
                dateTimePickerDataAdmissao.Value = _funcionario.DataAdmissao;

            if(_funcionario.Id != 0)
                _ = _funcionario.EhAdmin ? radioButtonAdmin.Checked = true : radioButtonFuncionario.Checked = true;
        }
    }
}