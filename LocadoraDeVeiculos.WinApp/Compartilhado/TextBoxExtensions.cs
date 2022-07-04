using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.Compartilhado
{
    public static class TextBoxExtensions
    {
        public static void AceitaNumeroEVirgulaPoeMascaraMoeda(this TextBoxBase txt)
        {
            txt.Enter += TirarMascaraMoeda!;
            txt.Leave += RetornarMascaraMoeda!;
            txt.KeyPress += ApenasValorNumericoMoeda!;
        }

        public static void AceitaSoLetras(this TextBoxBase txt)
        {
            txt.KeyPress += AceitarLetras!;
        }

        public static void AceitaSoNumeros(this TextBoxBase txt)
        {
            txt.KeyPress += AceitarNumeros!;
        }

        private static void ApenasValorNumericoMoeda(object sender, KeyPressEventArgs e)
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

        private static void RetornarMascaraMoeda(object sender, EventArgs e)
        {
            double valor = 0;
            TextBoxBase txt = (TextBoxBase)sender;
            double.TryParse(txt.Text, out valor);
            txt.Text = valor.ToString("C2");
        }

        private static void TirarMascaraMoeda(object sender, EventArgs e)
        {
            TextBoxBase txt = (TextBoxBase)sender;
            txt.Text = txt.Text.Replace("R$", "").Trim();
        }

        private static void AceitarLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private static void AceitarNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }
    }
}
