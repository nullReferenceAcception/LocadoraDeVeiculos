using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.Compartilhado
{
    public static class FuncoesTextBox
    {
        public static void ApenasValorNumericoMoeda(object sender, KeyPressEventArgs e)
        {
            TextBoxBase txt = (TextBoxBase)sender;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                    e.Handled = txt.Text.Contains(',');
                else
                    e.Handled = true;
            }
        }

        public static void RetornarMascaraMoeda(object sender, EventArgs e)
        {
            TextBoxBase txt = (TextBoxBase)sender;
            txt.Text = double.Parse(txt.Text).ToString("C2");
        }

        public static void TirarMascaraMoeda(object sender, EventArgs e)
        {
            TextBoxBase txt = (TextBoxBase)sender;
            txt.Text = txt.Text.Replace("R$", "").Trim();
        }

        public static void AplicarMascaraMoeda(this TextBox textBox)
        {
            textBox.Enter += TirarMascaraMoeda!;
            textBox.Leave += RetornarMascaraMoeda!;
            textBox.KeyPress += ApenasValorNumericoMoeda!;
        }
    }
}
