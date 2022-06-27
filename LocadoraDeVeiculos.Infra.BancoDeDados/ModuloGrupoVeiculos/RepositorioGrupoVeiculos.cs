using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoVeiculos
{
    public class RepositorioGrupoVeiculos : RepositorioBaseEmBancoDeDados<GrupoVeiculos, ValidadorGrupoVeiculos, MapeadorGrupoVeiculos>, IRepositorioGrupoVeiculos
    {
        public RepositorioGrupoVeiculos() : base(new ValidadorGrupoVeiculos(), new MapeadorGrupoVeiculos())
        {

        }

        #region Sql Queries

        protected override string sqlInserir
        {

            get =>
            @"INSERT
	            INTO
		        TB_GRUPO_VEICULO
		        (
		        NOME
		        )
		        VALUES
		        (
		        @NOME
		        );SELECT SCOPE_IDENTITY();";
        }
        protected override string sqlEditar
        {
            get =>
            @"UPDATE
	       TB_GRUPO_VEICULO
		        SET
			NOME = @NOME
		        WHERE
			ID_GRUPO_VEICULO = @ID_GRUPO_VEICULO;";
        }

        protected override string sqlExcluir
        {
            get =>
            @"DELETE 
	            FROM
		           TB_GRUPO_VEICULO
	            WHERE
		            ID_GRUPO_VEICULO = @ID;";
        }

        protected override string sqlSelecionarTodos
        {
            get =>
            @"SELECT
                    ID_GRUPO_VEICULO AS ID_GRUPO_VEICULO,
	                NOME AS NOME_GRUPO_VEICULO
                FROM
	               TB_GRUPO_VEICULO
";
        }

        protected override string sqlSelecionarPorID
        {
            get =>
           @"SELECT
                ID_GRUPO_VEICULO AS ID_GRUPO_VEICULO,
	                NOME AS NOME_GRUPO_VEICULO
                FROM
	               TB_GRUPO_VEICULO
                WHERE
	            ID_GRUPO_VEICULO = @ID;";
        }


        #endregion

        protected override ValidationResult MandarSQLParaValidador(GrupoVeiculos registro, SqlConnection conexaoComBanco)
        {
            return Validar("SELECT * FROM TB_GRUPO_VEICULO WHERE ([NOME] = '" + registro.Nome + "')", registro, conexaoComBanco);
        }
    }
}
