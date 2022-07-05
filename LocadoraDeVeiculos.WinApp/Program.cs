using System;
using Serilog;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using LocadoraDeVeiculos.Infra.BancoDeDados.Log;

namespace LocadoraDeVeiculos.WinApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger.ConfigurarLog();

            CultureInfo newCulture = CultureInfo.CreateSpecificCulture("pt-BR");
            Thread.CurrentThread.CurrentUICulture = newCulture;
            Thread.CurrentThread.CurrentCulture = newCulture;

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Log.Logger.Information("Ué");

            Application.Run(new TelaPrincipalForm());
        }
    }
}
