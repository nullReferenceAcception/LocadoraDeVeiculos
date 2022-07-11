using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoVeiculos
{
    public class RepositorioGrupoVeiculos : RepositorioBaseEmBancoDeDados<GrupoVeiculos, ValidadorGrupoVeiculos, MapeadorGrupoVeiculos>, IRepositorioGrupoVeiculos
    {
        public RepositorioGrupoVeiculos() : base( new MapeadorGrupoVeiculos())
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
                GUID_GRUPO_VEICULO,
		        NOME
		        )
		        VALUES
		        (
                @GUID_GRUPO_VEICULO,
		        @NOME
		        );SELECT SCOPE_IDENTITY();";
        }
        protected override string sqlEditar
        {
            get =>
            @"UPDATE
	       TB_GRUPO_VEICULO
		        SET
            GUID_GRUPO_VEICULO = @GUID_GRUPO_VEICULO,
			NOME = @NOME
		        WHERE
			GUID_GRUPO_VEICULO = @GUID_GRUPO_VEICULO;";
        }

        protected override string sqlExcluir
        {
            get =>
            @"DELETE 
	            FROM
		           TB_GRUPO_VEICULO
	            WHERE
		            GUID_GRUPO_VEICULO = @guid;";
        }

        protected override string sqlSelecionarTodos
        {
            get =>
            @"SELECT
                    GUID_GRUPO_VEICULO AS GUID_GRUPO_VEICULO,
	                NOME AS NOME_GRUPO_VEICULO
                FROM
	               TB_GRUPO_VEICULO
";
        }

        protected override string sqlSelecionarPorID
        {
            get =>
           @"SELECT
                GUID_GRUPO_VEICULO AS GUID_GRUPO_VEICULO,
	                NOME AS NOME_GRUPO_VEICULO
                FROM
	               TB_GRUPO_VEICULO
                WHERE
	            GUID_GRUPO_VEICULO = @guid;";
        }

        protected override string sqlQuantidade
        {
            get =>
                    @"SELECT COUNT(*) from TB_GRUPO_VEICULO";
        }


        #endregion

        public string SqlDuplicidade(GrupoVeiculos registro)
        {
            return "SELECT * FROM TB_GRUPO_VEICULO WHERE ([NOME] = '" + registro.Nome + "')" + "AND [GUID_GRUPO_VEICULO] != '" + registro.guid + "'";
        }

    }
}
