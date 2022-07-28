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
        public TabelaConfiguracoesControl()
        {
            InitializeComponent();
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

            var x = Db.configuracao["ConfiguracaoLogs:DiretorioSaida"];

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
