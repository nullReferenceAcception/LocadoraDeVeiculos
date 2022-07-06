using Serilog;
using System;
using System.IO;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Log
{
    public static class LoggerExtensions
    {
        public static void ConfigurarLog(this ILogger log)
        {
            string caminho = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.Parent!.FullName + "\\log.txt";

            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(caminho)
                .CreateLogger();
        }
    }
}
