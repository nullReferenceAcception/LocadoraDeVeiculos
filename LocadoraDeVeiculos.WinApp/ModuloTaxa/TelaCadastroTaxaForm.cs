using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public partial class TelaCadastroTaxaForm : Form
    {
        private Taxa? _taxa;
        public Taxa? Taxa
        {
            get { return _taxa; }
            set
            {
                _taxa = value!;
                ConfigurarTelaEditar();
            }
        }
        public TelaCadastroTaxaForm()
        {
            InitializeComponent();
            this.ConfigurarTela();
        }

        public Func<Taxa, ValidationResult>? GravarRegistro { get; set; }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            ObterDadosDaTela();

            if (string.IsNullOrEmpty(textBoxValor.Text))
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape("Campo valor não pode ser vazio");
                DialogResult = DialogResult.None;
                return;
            }

            var resultadoValidacao = GravarRegistro!(Taxa!);

            if (!resultadoValidacao.IsValid)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape(resultadoValidacao.Errors[0].ErrorMessage);
                DialogResult = DialogResult.None;
            }
        }

        private void ConfigurarTelaEditar()
        {
            textBoxID.Text = _taxa!.Id.ToString();
            textBoxDescricao.Text = _taxa!.Descricao;
            textBoxValor.Text = _taxa.Valor.ToString();
        }

        private void ObterDadosDaTela()
        {
            Taxa!.Descricao = textBoxDescricao.Text;
            Taxa!.Valor = Convert.ToDecimal(textBoxValor.Text);
        }
    }
}
