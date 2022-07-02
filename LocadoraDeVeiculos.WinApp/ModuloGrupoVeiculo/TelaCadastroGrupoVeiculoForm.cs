using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculo
{
    // existe um textBoxNome que não existe no designer e nao sei tirar use o textBoxName
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
            textBoxNome.Focus();
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
            textBoxName.Text = grupoVeiculos!.Nome;
        }

        private void ObterDadosDaTela()
        {
            GrupoVeiculos!.Nome = textBoxName.Text;
        }
    }
}
