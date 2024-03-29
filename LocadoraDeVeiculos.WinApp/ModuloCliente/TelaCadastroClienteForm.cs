﻿using FluentResults;
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
            this.AjustarLabelsHover();
        }

        public Func<Cliente, Result<Cliente>> GravarRegistro { get; set; }

        private void ConfigurarTelaEditar()
        {
            textBoxGuid.Text = Cliente.Id.ToString();
            textBoxNome.Text = Cliente.Nome;
            textBoxEndereco.Text = Cliente.Endereco;
            textBoxEmail.Text = Cliente.Email;
            maskedTextBoxTelefone.Text = Cliente.Telefone;

            if (Cliente.Id != Guid.Empty)
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
                }
            }
        }

        private void ObterDadosDaTela()
        {
            Cliente.Nome = textBoxNome.Text;
            Cliente.Endereco = textBoxEndereco.Text;
            Cliente.CNPJ = maskedTextBoxCNPJ.Text;
            Cliente.CPF = maskedTextBoxCPF.Text;
            Cliente.Email = textBoxEmail.Text;
            Cliente.Telefone = maskedTextBoxTelefone.Text;
            Cliente.PessoaFisica = radioButtonCPF.Checked == true ? Cliente.PessoaFisica = true : Cliente.PessoaFisica = false;

            if (Cliente.PessoaFisica)
                Cliente.CNPJ = null!;
            else
                Cliente.CPF = null!;
        }

        private void radioCPFbtn_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBoxCPF.Enabled = true;
            maskedTextBoxCNPJ.Enabled = false;
            maskedTextBoxCNPJ.Clear();
            maskedTextBoxCPF.Focus();
            labelCNPJ.Cursor = DefaultCursor;
            labelCPF.Cursor = Cursors.Hand;
            labelCNPJ.AjustarLabelsHoverParaBlack();
            labelCPF.AjustarLabelsHoverParaBlue();

        }

        private void radioCNPJbtn_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBoxCNPJ.Enabled = true;
            maskedTextBoxCPF.Enabled = false;
            maskedTextBoxCPF.Clear();
            maskedTextBoxCNPJ.Focus();
            labelCPF.Cursor = DefaultCursor;
            labelCNPJ.Cursor = Cursors.Hand;


            labelCNPJ.AjustarLabelsHoverParaBlue();
            labelCPF.AjustarLabelsHoverParaBlack();

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ObterDadosDaTela();

            var resultadoValidacao = GravarRegistro(Cliente);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro, CorParaRodape.Red);

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

    }
}
