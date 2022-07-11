using System;
using Serilog;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using LocadoraDeVeiculos.Infra.Logging.Log;
using System.Configuration;

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

            string Linguagem = ConfigurationManager.AppSettings.Get("Idioma");

            Thread.CurrentThread.CurrentUICulture = new(Linguagem);

            Thread.CurrentThread.CurrentCulture = new(Linguagem);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Log.Logger.Information("Programa inicializado");

            Application.Run(new TelaPrincipalForm());

            Log.Logger.Information("Programa finalizado");
        }
    }
}
