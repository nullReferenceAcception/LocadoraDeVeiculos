using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDados.Compartilhado
{
    public static class Db
    {
        private static string enderecoBanco =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=locadora_db;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static void ExecutarSql(string sql)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comando = new SqlCommand(sql, conexaoComBanco);

            conexaoComBanco.Open();
            comando.ExecuteNonQuery();
            conexaoComBanco.Close();
        }
    }
}