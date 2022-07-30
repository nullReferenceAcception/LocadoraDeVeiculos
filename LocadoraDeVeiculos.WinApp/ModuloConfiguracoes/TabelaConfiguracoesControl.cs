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

        public TabelaConfiguracoesControl(ConfiguracaoAplicacaoLocadora configuracao)
        {
            InitializeComponent();

            ConfigurarNumericUpDowns();

            textBoxConnectionString.Text = configuracao.ConnectionStrings.SqlServer;

            textBoxDiretorioLog.Text = configuracao.ConfiguracaoLogs.DiretorioSaida;

            textBoxUrlSeq.Text = "http://localhost:5341/";

            textBoxUrlSeq.Enabled = false;

            numericUpDownDiesel.Text = configuracao.PrecoCombustiveis.Diesel;

            numericUpDownAlcool.Text = configuracao.PrecoCombustiveis.Alcool;

            numericUpDownEtanol.Text = configuracao.PrecoCombustiveis.Etanol;

            numericUpDownGasolina.Text = configuracao.PrecoCombustiveis.Gasolina;

            numericUpDownGNV.Text = configuracao.PrecoCombustiveis.GNV;

            this.configuracao = configuracao;
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            configuracao.PrecoCombustiveis.Gasolina = numericUpDownGasolina.Text;

            configuracao.PrecoCombustiveis.Etanol = numericUpDownEtanol.Text;

            configuracao.PrecoCombustiveis.Alcool = numericUpDownAlcool.Text;

            configuracao.PrecoCombustiveis.GNV = numericUpDownGNV.Text;

            configuracao.PrecoCombustiveis.Diesel = numericUpDownDiesel.Text;

            string caminho = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caminhoJson = Path.Combine(caminho, "ConfiguracaoAplicacao.json");

            string json = JsonConvert.SerializeObject(configuracao, Formatting.Indented);
            File.WriteAllText(caminhoJson, json);

            MessageBox.Show("Informações gravadas");
        }

        private void ConfigurarNumericUpDowns()
        {
            numericUpDownAlcool.Increment = 0.01m;
            numericUpDownDiesel.Increment = 0.01m;
            numericUpDownEtanol.Increment = 0.01m;
            numericUpDownGasolina.Increment = 0.01m;
            numericUpDownGNV.Increment = 0.01m;
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
    }
}
