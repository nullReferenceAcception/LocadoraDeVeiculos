using Locadora.Infra.Configs;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloConfiguracoes
{
    public partial class TabelaConfiguracoesControl : UserControl
    {
        ConfiguracaoAplicacaoLocadora configuracao;
        ValidadorConfiguracao _validador;

        public TabelaConfiguracoesControl(ConfiguracaoAplicacaoLocadora configuracao)
        {
            InitializeComponent();

            _validador = new();

            ConfigurarNumericUpDowns();

            this.configuracao = configuracao;
            AtualizarCampos(configuracao);
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            ObterConnectionString();
            ObterPrecosCombustiveis();
            ObterConnectionStringSqlServer();

            var res = _validador.Validate(configuracao);

            if (!res.IsValid)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(res.Errors[0].ErrorMessage, CorParaRodape.Red);
                return;
            }

            string caminho = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            string caminhoJson = Path.Combine(caminho, "ConfiguracaoAplicacao.json");

            string json = JsonConvert.SerializeObject(configuracao, Formatting.Indented);

            File.WriteAllText(caminhoJson, json);

            MessageBox.Show("Informações gravadas");

            AtualizarCampos(configuracao);
        }

        private void ObterConnectionStringSqlServer()
        {
            configuracao.ConfiguracaoLogs.DiretorioSaida = textBoxDiretorioLog.Text;
        }

        private void ObterConnectionString()
        {
            configuracao.ConnectionStrings.SqlServer = textBoxConnectionString.Text;
        }

        private void buttonCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxConnectionString.Text);
        }

        private void buttonAbrirSeq_Click(object sender, EventArgs e)
        {
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(textBoxUrlSeq.Text)
            {
                UseShellExecute = true
            };
            p.Start();
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new();
            fbd.Description = "Selecionar pasta para salvar os logs";

            string pastaSelecionada = "";

            if (fbd.ShowDialog() == DialogResult.OK)
                textBoxDiretorioLog.Text = pastaSelecionada;

        }

        private void ObterPrecosCombustiveis()
        {
            configuracao.PrecoCombustiveis.Gasolina = numericUpDownGasolina.Text;

            configuracao.PrecoCombustiveis.Etanol = numericUpDownEtanol.Text;

            configuracao.PrecoCombustiveis.Alcool = numericUpDownAlcool.Text;

            configuracao.PrecoCombustiveis.GNV = numericUpDownGNV.Text;

            configuracao.PrecoCombustiveis.Diesel = numericUpDownDiesel.Text;
        }

        private void ConfigurarNumericUpDowns()
        {
            numericUpDownAlcool.Increment = 0.01m;
            numericUpDownDiesel.Increment = 0.01m;
            numericUpDownEtanol.Increment = 0.01m;
            numericUpDownGasolina.Increment = 0.01m;
            numericUpDownGNV.Increment = 0.01m;
        }

        private void AtualizarCampos(ConfiguracaoAplicacaoLocadora configuracao)
        {
            textBoxConnectionString.Text = configuracao.ConnectionStrings.SqlServer;

            textBoxDiretorioLog.Text = configuracao.ConfiguracaoLogs.DiretorioSaida;

            textBoxUrlSeq.Text = "http://localhost:5341/";

            textBoxUrlSeq.Enabled = false;

            numericUpDownDiesel.Text = configuracao.PrecoCombustiveis.Diesel;

            numericUpDownAlcool.Text = configuracao.PrecoCombustiveis.Alcool;

            numericUpDownEtanol.Text = configuracao.PrecoCombustiveis.Etanol;

            numericUpDownGasolina.Text = configuracao.PrecoCombustiveis.Gasolina;

            numericUpDownGNV.Text = configuracao.PrecoCombustiveis.GNV;
        }
    }
}
