﻿

using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;

namespace LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado
{
    public class BaseTestRepositorio
    {
        public BaseTestRepositorio()
        {
            //colocar aqui sua tabela de acrodo com os exemplos

            //Db.ExecutarSql("DELETE FROM TBFUNCIONARIO; DBCC CHECKIDENT (TBFUNCIONARIO, RESEED, 0)");

            Db.ExecutarSql("DELETE FROM TB_CLIENTE; DBCC CHECKIDENT (TB_CLIENTE, RESEED, 0)");

            Db.ExecutarSql("DELETE FROM TB_TAXA; DBCC CHECKIDENT (TB_TAXA, RESEED, 0)");
        }
    }
}
