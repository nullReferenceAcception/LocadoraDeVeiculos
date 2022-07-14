using System;
using System.Drawing;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp
{
    public static class FormExtensions
    {
        public static void ConfigurarTela(this Form tela)
        {
            tela.FormBorderStyle = FormBorderStyle.FixedDialog;
            tela.StartPosition = FormStartPosition.CenterScreen;
            tela.MaximizeBox = false;
            tela.MinimizeBox = false;
            tela.ShowIcon = false;
            tela.ShowInTaskbar = false;
        }

        public static void AjustarLabelsHover(this Form tela)
        {
            foreach (Control item in tela.Controls)
                if (item is GroupBox)
                    foreach (var x in item.Controls)
                        if (x is Label && ((Label)x).Text != "Guid:")
                        {
                            ((Label)x).MouseEnter += label_MouseEnter;
                            ((Label)x).MouseLeave += label_MouseLeave;
                        }
        }

        private static void label_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label label)
                label.ForeColor = Color.DodgerBlue;
        }
        private static void label_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Label label)
                label.ForeColor = Color.Black;
        }
    }

    public static class GuiExtensionMethods
    {
        public static void Habilitar(this Form con, bool enable)
        {
            if (con != null)
                foreach (Control c in con.Controls)
                    c.Enabled = enable;
        }
    }
}
