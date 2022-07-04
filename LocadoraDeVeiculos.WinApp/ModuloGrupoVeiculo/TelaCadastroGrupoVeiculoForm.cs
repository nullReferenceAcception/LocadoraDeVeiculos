using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculo
{
    public partial class TelaCadastroGrupoVeiculoForm : Form
    {
        private GrupoVeiculos? grupoVeiculos;
        public GrupoVeiculos? GrupoVeiculos
        {
            get { return grupoVeiculos; }
            set
            {
                grupoVeiculos = value!;
                ConfigurarTelaEditar();
            }
        }

        public Func<GrupoVeiculos, ValidationResult>? GravarRegistro { get; set; }

        public TelaCadastroGrupoVeiculoForm()
        {
            InitializeComponent();
            this.ConfigurarTela();
            ConfigurarComponentes();
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            ObterDadosDaTela();

            var resultadoValidacao = GravarRegistro!(GrupoVeiculos!);

            if (!resultadoValidacao.IsValid)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape(resultadoValidacao.Errors[0].ErrorMessage);
                DialogResult = DialogResult.None;
            }
        }

        private void ConfigurarTelaEditar()
        {
            textBoxID.Text = grupoVeiculos!.Id.ToString();
            textBoxNome.Text = grupoVeiculos!.Nome;
        }

        private void ObterDadosDaTela()
        {
            GrupoVeiculos!.Nome = textBoxNome.Text;
        }

        private void ConfigurarComponentes()
        {
            textBoxNome.Focus();
            textBoxNome.AceitaSoLetras();
        }
    }
}
