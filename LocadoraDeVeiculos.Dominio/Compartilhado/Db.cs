using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{ 
    public static class Db
    {
       static IConfigurationRoot configuracao = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("ConfiguracaoAplicacao.json")
           .Build();


        public static SqlConnection conexaoComBanco = new SqlConnection(configuracao.GetConnectionString("SqlServer"));

        public static void ExecutarSql(string sql)
        {
            SqlCommand comando = new SqlCommand(sql, conexaoComBanco);

            conexaoComBanco.Open();
            comando.ExecuteNonQuery();
            conexaoComBanco.Close();
        }
    }
}