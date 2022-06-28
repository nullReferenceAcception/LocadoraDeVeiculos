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
    }

    public static class GuiExtensionMethods
    {
        public static void Enable(this Control con, bool enable)
        {
            if (con != null)
            {
                foreach (Control c in con.Controls)
                {
                    c.Enabled =enable;
                }

                try
                {
                    con.Invoke((MethodInvoker)(() => con.Enabled = enable));
                }
                catch
                {
                }
            }
        }
    }



}
