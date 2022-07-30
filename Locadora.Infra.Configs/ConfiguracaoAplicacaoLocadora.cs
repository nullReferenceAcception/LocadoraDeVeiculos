using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Locadora.Infra.Configs
{
    public class ConfiguracaoAplicacaoLocadora
    {
        public ConfiguracaoAplicacaoLocadora()
        {
            IConfiguration configuracao = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("ConfiguracaoAplicacao.json")
              .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            ConnectionStrings = new ConnectionStrings { SqlServer = connectionString };

            var diretorioSaida = configuracao
                .GetSection("ConfiguracaoLogs")
                .GetSection("DiretorioSaida")
                .Value;

            VersaoSistema = configuracao.GetSection("VersaoSistema").Value;

            ConfiguracaoLogs = new ConfiguracaoLogs { DiretorioSaida = diretorioSaida };

            var gasolina = configuracao
                  .GetSection("PrecoCombustiveis")
                  .GetSection("Gasolina")
                  .Value;

            var alcool = configuracao
                 .GetSection("PrecoCombustiveis")
                 .GetSection("Alcool")
                 .Value;

            var diesel = configuracao
                .GetSection("PrecoCombustiveis")
                .GetSection("Diesel")
                .Value;

            var etanol = configuracao
                .GetSection("PrecoCombustiveis")
                .GetSection("Etanol")
                .Value;

            var gnv = configuracao
               .GetSection("PrecoCombustiveis")
               .GetSection("Etanol")
               .Value;

            PrecoCombustiveis = new PrecoCombustiveis
            {
                Gasolina = Math.Round(decimal.Parse(gasolina), 2),
                Alcool = Math.Round(decimal.Parse(alcool), 2),
                Diesel = Math.Round(decimal.Parse(diesel), 2),
                Etanol = Math.Round(decimal.Parse(etanol), 2),
                GNV = Math.Round(decimal.Parse(gnv), 2)
            };
        }

        public string VersaoSistema { get; set; }

        public ConfiguracaoLogs ConfiguracaoLogs { get; set; }

        public ConnectionStrings ConnectionStrings { get; set; }

        public PrecoCombustiveis PrecoCombustiveis { get; set; }
    }

    public class ConfiguracaoLogs
    {
        public string DiretorioSaida { get; set; }
    }

    public class ConnectionStrings
    {
        public string SqlServer { get; set; }
    }

    public class PrecoCombustiveis
    {
        public decimal Gasolina { get; set; }
        public decimal Alcool { get; set; }
        public decimal Diesel { get; set; }
        public decimal Etanol { get; set; }
        public decimal GNV { get; set; }
    }

}
