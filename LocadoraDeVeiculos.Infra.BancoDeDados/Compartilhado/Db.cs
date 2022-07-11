using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDados.Compartilhado
{
    public static class Db
    {
        public static void ExecutarSql(string sql, SqlConnection conexaoComBanco)
        {

            SqlCommand comando = new SqlCommand(sql, conexaoComBanco);

            conexaoComBanco.Open();
            comando.ExecuteNonQuery();
            conexaoComBanco.Close();
        }
    }
}