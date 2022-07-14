using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculo
{
    public partial class TelaCadastroGrupoVeiculoForm : Form
    {
        private GrupoVeiculos grupoVeiculos;
        public GrupoVeiculos GrupoVeiculos
        {
            get { return grupoVeiculos; }
            set
            {
                grupoVeiculos = value;
                ConfigurarTelaEditar();
            }
        }

        public Func<GrupoVeiculos, Result<GrupoVeiculos>> GravarRegistro { get; set; }

        public TelaCadastroGrupoVeiculoForm()
        {
            InitializeComponent();
            this.ConfigurarTela();
            ConfigurarComponentes();
            this.AjustarLabelsHover();
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            ObterDadosDaTela();

            var resultadoValidacao = GravarRegistro(GrupoVeiculos);

            if (resultadoValidacao.IsFailed)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(resultadoValidacao.Errors[0].Message, CorParaRodape.Red);
                DialogResult = DialogResult.None;
            }
        }

        private void ConfigurarTelaEditar()
        {
            textBoxGuid.Text = grupoVeiculos.Guid.ToString();
            textBoxNome.Text = grupoVeiculos.Nome;
        }

        private void ObterDadosDaTela()
        {
            GrupoVeiculos.Nome = textBoxNome.Text;
        }

        private void ConfigurarComponentes()
        {
            textBoxNome.Focus();
            textBoxNome.AceitaSoLetras();
        }

        private void labelNome_Click(object sender, EventArgs e)
        {
            textBoxNome.Focus();
        }
    }
}
