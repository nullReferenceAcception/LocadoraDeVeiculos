using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraDeVeiculos.Servico.ModuloTaxa;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloTaxa
{
    public class RepositorioTaxa : RepositorioBaseEmBancoDeDados<Taxa, ValidadorTaxa, MapeadorTaxa>, IRepositorioTaxa
    {
        public RepositorioTaxa() : base(new MapeadorTaxa())
        {

        }

        #region Sql Queries

        protected override string sqlInserir
        {
            get =>
            @"INSERT
	            INTO
		        TB_TAXA
		        (
		        DESCRICAO, 
		        VALOR
		        )
		        VALUES
		        (
		        @DESCRICAO,
		        @VALOR
		        );SELECT SCOPE_IDENTITY();";
        }
        protected override string sqlEditar
        {
            get =>
            @"UPDATE
	        TB_TAXA
		        SET
			DESCRICAO = @DESCRICAO,
			VALOR = @VALOR
		        WHERE
			ID_TAXA = @ID_TAXA;";
        }

        protected override string sqlExcluir
        {
            get =>
            @"DELETE 
	            FROM
		            TB_TAXA
	            WHERE
		            ID_TAXA = @ID;";
        }

        protected override string sqlSelecionarTodos
        {
            get =>
            @"SELECT
                    ID_TAXA AS ID_TAXA,
	                DESCRICAO AS DESCRICAO_TAXA,
	                VALOR AS VALOR_TAXA
                FROM
	                TB_TAXA
";
        }

        protected override string sqlSelecionarPorID
        {
            get =>
           @"SELECT
                ID_TAXA AS ID_TAXA,
	                DESCRICAO AS DESCRICAO_TAXA,
	                VALOR AS VALOR_TAXA
                FROM
	                TB_TAXA
                WHERE
	            ID_TAXA = @ID;";
        }


        #endregion

        string IRepositorio<Taxa>.SqlDuplicidade(Taxa registro)
        {
            return "SELECT * FROM TB_TAXA WHERE ([DESCRICAO] = '" + registro.Descricao + "')" + $"AND [ID_TAXA] != {registro.Id}";
        }
    }
}
