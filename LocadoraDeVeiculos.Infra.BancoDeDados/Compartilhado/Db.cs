using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace LocadoraDeVeiculos.Infra.BancoDados.Compartilhado
{
    public static class Db
    {
       static IConfigurationRoot configuracao = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("ConfiguracaoAplicacao.json")
           .Build();

        static SqlConnection ConexcaoComBanco = new SqlConnection(configuracao.GetConnectionString("SqlServer"));

        public static void ExecutarSql(string sql)
        {
            SqlCommand comando = new SqlCommand(sql, ConexcaoComBanco);

            ConexcaoComBanco.Open();
            comando.ExecuteNonQuery();
            ConexcaoComBanco.Close();
        }
    }
}