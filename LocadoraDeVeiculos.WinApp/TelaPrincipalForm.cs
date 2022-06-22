using LocadoraDeVeiculosDeVeiculos.WinApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                labelRodape.Text = string.Empty;
                labelTipoCadastro.Text = string.Empty;

                InicializarControladores();
            }

            public static TelaPrincipalForm Instancia
            {
                get;
                private set;
            }

            public void AtualizarRodape(string mensagem)
            {
                labelRodape.Text = mensagem;
            }

            private void tarefasMenuItem_Click(object sender, EventArgs e)
            {
                ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
            }

            private void contatosMenuItem_Click(object sender, EventArgs e)
            {
                ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
            }

            private void compromissosMenuItem_Click(object sender, EventArgs e)
            {
                ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
            }

            private void despesasMenuItem_Click(object sender, EventArgs e)
            {
                ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
            }

            private void materiasMenuItem_Click(object sender, EventArgs e)
            {
                ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
            }

            private void questoesMenuItem_Click(object sender, EventArgs e)
            {
                ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
            }

            private void testesMenuItem_Click(object sender, EventArgs e)
            {
                ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
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

            private void btnFiltrar_Click(object sender, EventArgs e)
            {
                controlador.Filtrar();
            }

            private void btnGerarPdf_Click(object sender, EventArgs e)
            {
                controlador.GerarPdf();
            }

            private void btnVisualizar_Click(object sender, EventArgs e)
            {
                controlador.Visualizar();
            }

            private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
            {
                btnInserir.Enabled = configuracao.InserirHabilitado;
                btnEditar.Enabled = configuracao.EditarHabilitado;
                btnExcluir.Enabled = configuracao.ExcluirHabilitado;
                btnFiltrar.Enabled = configuracao.FiltrarHabilitado;
                btnGerarPdf.Enabled = configuracao.GerarPdfHabilitado;
                btnVisualizar.Enabled = configuracao.VisualizarHabilitado;
            }

            private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
            {
                btnInserir.ToolTipText = configuracao.TooltipInserir;
                btnEditar.ToolTipText = configuracao.TooltipEditar;
                btnExcluir.ToolTipText = configuracao.TooltipExcluir;
                btnFiltrar.ToolTipText = configuracao.TooltipFiltrar;
                btnGerarPdf.ToolTipText = configuracao.TooltipGerarPdf;
                btnVisualizar.ToolTipText = configuracao.TooltipVisualizar;
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
                AtualizarRodape("");

                var listagemControl = controlador.ObtemListagem();

                panelRegistros.Controls.Clear();

                listagemControl.Dock = DockStyle.Fill;

                panelRegistros.Controls.Add(listagemControl);
            }

            private void InicializarControladores()
            {
                //exemplos

                //  IRepositorioMateria repositorioMateria = new RepositorioMateriaEmArquivo(contextoDados);


                controladores = new Dictionary<string, ControladorBase>();

                //     controladores.Add("Matérias", new ControladorMateria(repositorioMateria, repositorioDisciplina));
            }


        }
    }

