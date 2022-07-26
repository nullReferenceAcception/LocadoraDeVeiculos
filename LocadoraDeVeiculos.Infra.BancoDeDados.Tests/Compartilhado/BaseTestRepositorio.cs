using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator;
using System;

namespace LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado
{
    public class BaseTestRepositorio
    {
        protected LocadoraDbContext DbContext;
        protected BaseTestRepositorio()
        {

            MigradorBancoDadosLocadora.AtualizarBancoDados();

            DbContext = new(Db.conexaoComBanco.ConnectionString);
            //colocar aqui sua tabela de acrodo com os exemplos

            Db.ExecutarSql("DELETE FROM TB_PLANO_COBRANCA");
            Db.ExecutarSql("DELETE FROM TB_CONDUTOR");
            Db.ExecutarSql("DELETE FROM TB_CLIENTE");
            Db.ExecutarSql("DELETE FROM TB_TAXA");
            Db.ExecutarSql("DELETE FROM TB_VEICULO");
            Db.ExecutarSql("DELETE FROM TB_GRUPO_VEICULO");
            Db.ExecutarSql("DELETE FROM TB_FUNCIONARIO");
        }

        protected string GerarNovaStringAleatoria()
        {
            const int qtdeLetras = 10;

            const string letras = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ";

            string stringAleatoria = "";
            Random random = new();

            for (int i = 0; i < qtdeLetras; i++)
                stringAleatoria += letras[random.Next(letras.Length)];

            return stringAleatoria;
        }
    }
}
