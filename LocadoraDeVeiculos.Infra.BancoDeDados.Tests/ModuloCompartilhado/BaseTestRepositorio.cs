using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;

namespace LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado
{
    public class BaseTestRepositorio
    {
        public BaseTestRepositorio()
        {
            //colocar aqui sua tabela de acrodo com os exemplos

          // Db.ExecutarSql("DELETE FROM TBREQUISICAO; DBCC CHECKIDENT (TBREQUISICAO, RESEED, 0)");

            //Db.ExecutarSql("DELETE FROM TBMEDICAMENTO; DBCC CHECKIDENT (TBMEDICAMENTO, RESEED, 0)");

            //Db.ExecutarSql("DELETE FROM TBFORNECEDOR; DBCC CHECKIDENT (TBFORNECEDOR, RESEED, 0)");

            //Db.ExecutarSql("DELETE FROM TBPACIENTE; DBCC CHECKIDENT (TBPACIENTE, RESEED, 0)");

            //Db.ExecutarSql("DELETE FROM TBFUNCIONARIO; DBCC CHECKIDENT (TBFUNCIONARIO, RESEED, 0)");
        }
    }
}
