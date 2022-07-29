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

            this.configuracao = configuracao;

        }

        private void buttonProcurar_Click(object sender, EventArgs e)
        {
            string caminho = "C:\\Users\\marco\\source\\repos\\LocadoraDeVeiculos\\LocadoraDeVeiculos.WinApp\\ConfiguracaoAplicacao.json";

            var tudo = File.ReadAllText(caminho);

            dynamic emJson = JsonConvert.DeserializeObject(tudo);

            emJson["ConfiguracaoLogs:DiretorioSaida"] = "A";

            string saida = JsonConvert.SerializeObject(emJson, Formatting.Indented);

            File.WriteAllText(caminho, saida);

            StreamReader sr = new(caminho);

            var x = configuracao.ConfiguracaoLogs.DiretorioSaida;

            var texto = sr.ReadToEnd();

            var obj = JObject.Parse(texto);

            foreach (var item in obj.Properties())
            {
                if(item.Value.ToString() == "DiretorioSaida:")
                {
                    MessageBox.Show("ACHOU");
                }
            }

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();

            dialog.InitialDirectory = "C:\\Users";

            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textBoxDiretorioLog.Text = dialog.FileName;
                
            }
        }
    }
}
