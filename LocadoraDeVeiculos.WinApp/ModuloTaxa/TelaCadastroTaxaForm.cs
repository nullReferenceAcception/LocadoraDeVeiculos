using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public partial class TelaCadastroTaxaForm : Form
    {
        private Taxa _taxa;
        public Taxa Taxa
        {
            get { return _taxa; }
            set
            {
                _taxa = value;
                ConfigurarTelaEditar();
            }
        }

        public TelaCadastroTaxaForm()
        {
            InitializeComponent();
            textBoxValor.AceitaNumeroEVirgulaPoeMascaraMoeda();
            this.ConfigurarTela();
            ConfigurarComponentes();
            this.AjustarLabelsHover();
        }

        public Func<Taxa, Result<Taxa>> GravarRegistro { get; set; }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            ObterDadosDaTela();

            var resultadoValidacao = GravarRegistro(Taxa);

            if (resultadoValidacao.IsFailed)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(resultadoValidacao.Errors[0].Message, CorParaRodape.Red);
                DialogResult = DialogResult.None;
            }
        }

        private void ConfigurarTelaEditar()
        {
            textBoxGuid.Text = _taxa.Id.ToString();
            textBoxDescricao.Text = _taxa.Descricao;
            textBoxValor.Text = "R$ " + _taxa.Valor.ToString();
            _ = Taxa.EhDiaria ? radioButtonDiario.Checked = true : radioButtonFixo.Checked = true;
            _ = Taxa.EhAdicional ? checkBoxEhAdicional.Checked = true : false;
        }

        private void ObterDadosDaTela()
        {
            Taxa.Descricao = textBoxDescricao.Text;
            Taxa.Valor = Convert.ToDecimal(textBoxValor.Text.ToString().Replace("R$ ", ""));
            if (radioButtonDiario.Checked)
                Taxa.EhDiaria = true;
            else
                Taxa.EhDiaria = false;

            if (checkBoxEhAdicional.Checked)
                Taxa.EhAdicional = true;
            else
                Taxa.EhAdicional = false;
        }

        private void ConfigurarComponentes()
        {
            textBoxDescricao.AceitaSoLetras();
            textBoxDescricao.Focus();
        }

        private void labelDescricao_Click(object sender, EventArgs e)
        {
            textBoxDescricao.Focus();
        }

        private void labelValor_Click(object sender, EventArgs e)
        {
            textBoxValor.Focus();
        }
    }
}
