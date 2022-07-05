using Serilog;
using System;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Log
{
    public static class LoggerExtensions
    {
        public static void ConfigurarLog(this ILogger log)
        {
            string caminho = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\log.txt";

            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(caminho)
                .CreateLogger();
        }
    }
}
