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
                _taxa.Descricao = textBoxDescricao.Text;
                _taxa.Valor = Convert.ToDecimal(textBoxValor.Text);
            }
        }
        public TelaCadastroTaxaForm()
        {
            InitializeComponent();
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
