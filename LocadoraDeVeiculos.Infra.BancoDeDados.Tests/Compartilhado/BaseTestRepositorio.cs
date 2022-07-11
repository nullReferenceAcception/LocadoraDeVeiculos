using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado
{
    public class BaseTestRepositorio
    {
        public BaseTestRepositorio()
        {
            //colocar aqui sua tabela de acrodo com os exemplos

          
                var configuracao = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("ConfiguracaoAplicacao.json")
             .Build();

               SqlConnection enderecoBanco = new SqlConnection(configuracao.GetConnectionString("SqlServer"));


            Db.ExecutarSql("DELETE FROM TB_PLANO_COBRANCA", enderecoBanco);
            Db.ExecutarSql("DELETE FROM TB_CONDUTOR", enderecoBanco);
            Db.ExecutarSql("DELETE FROM TB_CLIENTE", enderecoBanco);
            Db.ExecutarSql("DELETE FROM TB_TAXA", enderecoBanco);
            Db.ExecutarSql("DELETE FROM TB_VEICULO", enderecoBanco);
            Db.ExecutarSql("DELETE FROM TB_GRUPO_VEICULO", enderecoBanco);
            Db.ExecutarSql("DELETE FROM TB_FUNCIONARIO", enderecoBanco);
        }
    }
}
