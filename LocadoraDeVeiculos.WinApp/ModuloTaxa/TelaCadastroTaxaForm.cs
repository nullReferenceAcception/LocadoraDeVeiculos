using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.Compartilhado;
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
            textBoxValor.AceitaNumeroEVirgulaPoeMascaraMoeda();
            this.ConfigurarTela();
            ConfigurarComponentes();
        }

        public Func<Taxa, ValidationResult>? GravarRegistro { get; set; }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            ObterDadosDaTela();

            var resultadoValidacao = GravarRegistro!(Taxa!);

            if (!resultadoValidacao.IsValid)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape(resultadoValidacao.Errors[0].ErrorMessage,TelaPrincipalForm.Cor.Red);
                DialogResult = DialogResult.None;
            }
        }

        private void ConfigurarTelaEditar()
        {
            textBoxID.Text = _taxa!.Id.ToString();
            textBoxDescricao.Text = _taxa!.Descricao;
            textBoxValor.Text = "R$ " + _taxa.Valor.ToString();
            _ = Taxa!.EhDiaria ? radioButtonDiario.Checked = true : radioButtonFixo.Checked = true;
        }

        private void ObterDadosDaTela()
        {
            Taxa!.Descricao = textBoxDescricao.Text;
            Taxa!.Valor = Convert.ToDecimal(textBoxValor.Text.ToString().Replace("R$ ", ""));
            if (radioButtonDiario.Checked)
                Taxa!.EhDiaria = true;
            else
                Taxa!.EhDiaria = false;
        }

        private void ConfigurarComponentes()
        {
            textBoxDescricao.AceitaSoLetras();
            textBoxDescricao.Focus();
        }
    }
}
