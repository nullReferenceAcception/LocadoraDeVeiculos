using Microsoft.Extensions.Configuration;
using System.IO;

namespace Locadora.Infra.Configs
{
    public class ConfiguracaoAplicacaoLocadora
    {
        public string VersaoSistema { get; set; }
        public ConfiguracaoLogs ConfiguracaoLogs { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public PrecoCombustiveis PrecoCombustiveis { get; set; }

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

            PrecoCombustiveis = new PrecoCombustiveis {
                Gasolina = gasolina,
                Alcool = alcool,
                Diesel = diesel,
                Etanol = etanol,
                GNV = gnv
            };
        }
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
        public string Gasolina { get; set; }
        public string Alcool { get; set; }
        public string Diesel { get; set; }
        public string Etanol { get; set; }
        public string GNV { get; set; }
    }
}
