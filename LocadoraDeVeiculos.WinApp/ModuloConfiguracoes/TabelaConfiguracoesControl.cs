using Locadora.Infra.Configs;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
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

            textBoxConnectionString.Text = configuracao.ConnectionStrings.SqlServer;

            textBoxDiretorioLog.Text = configuracao.ConfiguracaoLogs.DiretorioSaida;

            textBoxUrlSeq.Text = "http://localhost:5341/";

            textBoxUrlSeq.Enabled = false;

            numericUpDownDiesel.Value = configuracao.PrecoCombustiveis.Diesel;

            numericUpDownAlcool.Value = configuracao.PrecoCombustiveis.Alcool;

            numericUpDownEtanol.Value = configuracao.PrecoCombustiveis.Etanol;

            numericUpDownGasolina.Value = configuracao.PrecoCombustiveis.Gasolina;

            numericUpDownGNV.Value = configuracao.PrecoCombustiveis.GNV;




            this.configuracao = configuracao;

        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            configuracao.PrecoCombustiveis.Gasolina = decimal.Parse(numericUpDownGasolina.Text);

            configuracao.PrecoCombustiveis.Etanol = decimal.Parse(numericUpDownEtanol.Text);

            configuracao.PrecoCombustiveis.Alcool = decimal.Parse(numericUpDownAlcool.Text);

            configuracao.PrecoCombustiveis.GNV = decimal.Parse(numericUpDownGNV.Text);

            configuracao.PrecoCombustiveis.Diesel = decimal.Parse(numericUpDownDiesel.Text);





            string caminho = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caminhoJson = Path.Combine(caminho, "ConfiguracaoAplicacao.json");

            string json = JsonConvert.SerializeObject(configuracao,Formatting.Indented);
            File.WriteAllText(caminhoJson, json);

            MessageBox.Show("Informações gravadas");

        }
    }
}
