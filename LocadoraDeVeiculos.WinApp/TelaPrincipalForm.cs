﻿using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloVeiculo;
using LocadoraDeVeiculos.Servico.ModuloCliente;
using LocadoraDeVeiculos.Servico.ModuloCondutor;
using LocadoraDeVeiculos.Servico.ModuloFuncionario;
using LocadoraDeVeiculos.Servico.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Servico.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Servico.ModuloTaxa;
using LocadoraDeVeiculos.Servico.ModuloVeiculos;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculo;
using LocadoraDeVeiculos.WinApp.ModuloPlanoCobranca;
using LocadoraDeVeiculos.WinApp.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;

        public TelaPrincipalForm()
        {
            InitializeComponent();

            Instancia = this;

            labelTipoCadastro.Text = "Olá";
            AtualizarRodape("Seja bem-vindo(a)!", CorParaRodape.White);

            InicializarControladores();
        }

        public static TelaPrincipalForm Instancia
        {
            get;
            private set;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            controlador.Visualizar();
        }
        private void btnFuncionariosDesativados_Click(object sender, EventArgs e)
        {
            bool tipoFuncionario = controlador.VisualizarDesativados();

            DesabilitarBotoes(tipoFuncionario);

            ConfigurarToolTips(tipoFuncionario);
        }

        private void planoDeCobrancaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void clientesMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void gruposDeVeiculosMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void taxasMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void funcionariosMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }
        private void condutoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);

        }
        private void veículosMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
            btnGerarPdf.Enabled = configuracao.GerarPdfHabilitado;
            btnVisualizar.Enabled = configuracao.VisualizarHabilitado;
            btnFuncionariosDesativados.Enabled = configuracao.FuncionariosDesabilitados;
        }

        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
            btnGerarPdf.ToolTipText = configuracao.TooltipGerarPdf;
            btnVisualizar.ToolTipText = configuracao.TooltipVisualizar;
            btnFuncionariosDesativados.ToolTipText = configuracao.ToolTipFuncionariosDesabilitados;
        }

        private void ConfigurarTooltipsInativos()
        {
            btnVisualizar.ToolTipText = "Visualizar funcionário desativado";
            btnFuncionariosDesativados.ToolTipText = "Visualizar funcionários ativos";
            btnInserir.ToolTipText = string.Empty;
            btnEditar.ToolTipText = string.Empty;
            btnExcluir.ToolTipText = string.Empty;
        }

        private void ConfigurarTelaPrincipal(ToolStripMenuItem opcaoSelecionada)
        {
            var tipo = opcaoSelecionada.Text;

            controlador = controladores[tipo];

            ConfigurarToolbox();

            ConfigurarListagem();
        }

        private void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("", CorParaRodape.White);

            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

        private void InicializarControladores()
        {
            RepositorioTaxa repositorioTaxa = new();
            RepositorioFuncionario repositorioFuncionario = new();
            RepositorioGrupoVeiculos repositorioGrupoVeiculos = new();
            RepositorioCliente repositorioCliente = new();
            RepositorioCondutor repositorioCondutor = new();
            RepositorioVeiculo repositorioVeiculo = new();
            RepositorioPlanoCobranca repositorioPlanoCobranca = new();

            ServicoTaxa servicoTaxa = new(repositorioTaxa);
            ServicoFuncionario servicoFuncionario = new(repositorioFuncionario);
            ServicoGrupoVeiculos servicoGrupoVeiculos = new(repositorioGrupoVeiculos);
            ServicoCliente servicoCliente = new(repositorioCliente);
            ServicoVeiculo servicoVeiculo = new(repositorioVeiculo);
            ServicoCondutor servicoCondutor = new(repositorioCondutor);
            ServicoPlanoCobranca servicoPlanoCobranca = new(repositorioPlanoCobranca);

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Taxas", new ControladorTaxa(servicoTaxa));
            controladores.Add("Funcionários", new ControladorFuncionario(servicoFuncionario));
            controladores.Add("Grupos de Veículos", new ControladorGrupoVeiculos(servicoGrupoVeiculos));
            controladores.Add("Clientes", new ControladorCliente(servicoCliente));
            controladores.Add("Veículos", new ControladorVeiculo(servicoVeiculo, servicoGrupoVeiculos));
            controladores.Add("Condutores", new ControladorCondutor(servicoCondutor, servicoCliente));
            controladores.Add("Plano de cobrança", new ControladorPlanoCobranca(servicoPlanoCobranca, servicoGrupoVeiculos));
        }

        public void AtualizarRodape(string mensagem, CorParaRodape cor)
        {
            labelRodape.Text = mensagem;
            labelRodape.ForeColor = Color.FromName(cor.ToString());
        }

        private void DesabilitarBotoes(bool status)
        {
            btnInserir.Enabled = status;
            btnEditar.Enabled = status;
            btnExcluir.Enabled = status;
        }

        private void ConfigurarToolTips(bool funcionarioAtivo)
        {
            if (funcionarioAtivo)
                ConfigurarToolbox();
            else
                ConfigurarTooltipsInativos();
        }
    }
}
