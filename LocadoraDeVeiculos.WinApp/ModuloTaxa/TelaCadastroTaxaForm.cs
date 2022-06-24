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
                textBoxDescricao.Text = _taxa.Descricao;
                textBoxValor.Text = _taxa.Valor.ToString();
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
            Taxa!.Descricao = textBoxDescricao.Text;
            Taxa.Valor = Convert.ToDecimal(textBoxValor.Text);

            var resultadoValidacao = GravarRegistro!(Taxa);

            if (!resultadoValidacao.IsValid)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape(resultadoValidacao.Errors[0].ErrorMessage);
                DialogResult = DialogResult.None;
            }
        }
    }
}
