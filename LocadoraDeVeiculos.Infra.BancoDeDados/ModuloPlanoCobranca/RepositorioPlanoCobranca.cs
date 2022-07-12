using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobranca : RepositorioBaseEmBancoDeDados<PlanoCobranca,ValidadorPlanoCobranca,MapeadorPlanoCobranca>,IRepositorioPlanoCobranca
    {
        public RepositorioPlanoCobranca() : base(new MapeadorPlanoCobranca())
        {
        }

        #region Sql Queries

        protected override string sqlInserir
        {
            get =>
            @"INSERT
	            INTO
		        TB_PLANO_COBRANCA
		        (
                GUID_PLANO_COBRANCA,
		        NOME,
                KM_LIVRE_INCLUSO,
                VALOR_DIA,
                VALOR_POR_KM,
                PLANO,
                GRUPO_VEICULO_GUID
		        )
		        VALUES
		        (
                @GUID_PLANO_COBRANCA,
		        @NOME,
		        @KM_LIVRE_INCLUSO,
                @VALOR_DIA,
                @VALOR_POR_KM,
                @PLANO,
                @GRUPO_VEICULO_GUID
		        );SELECT SCOPE_IDENTITY();";
        }

        protected override string sqlEditar
        {
            get =>
            @"UPDATE
	        TB_PLANO_COBRANCA
		        SET
			NOME = @NOME,
			KM_LIVRE_INCLUSO = @KM_LIVRE_INCLUSO,
            VALOR_DIA = @VALOR_DIA,
            VALOR_POR_KM = @VALOR_POR_KM,
            PLANO = @PLANO,
            GRUPO_VEICULO_GUID = @GRUPO_VEICULO_GUID
		        WHERE
			GUID_PLANO_COBRANCA = @GUID_PLANO_COBRANCA;";
        }

        protected override string sqlExcluir
        {
            get =>
            @"DELETE 
	            FROM
		            TB_PLANO_COBRANCA
	            WHERE
		            GUID_PLANO_COBRANCA = @GUID;";
        }

        protected override string sqlSelecionarTodos
        {
            get =>
            @"SELECT
                    P.GUID_PLANO_COBRANCA AS GUID_PLANO_COBRANCA,
	                P.NOME AS NOME_PLANO_COBRANCA,
	                P.KM_LIVRE_INCLUSO AS KM_LIVRE_INCLUSO_PLANO_COBRANCA,
                    P.VALOR_DIA AS VALOR_DIA_PLANO_COBRANCA,
                    P.VALOR_POR_KM AS VALOR_POR_KM_PLANO_COBRANCA,
                    P.PLANO AS PLANO_PLANO_COBRANCA,
                    G.GUID_GRUPO_VEICULO AS GUID_GRUPO_VEICULO,
	                G.NOME AS NOME_GRUPO_VEICULO
                FROM
                   TB_PLANO_COBRANCA AS P INNER JOIN
	               TB_GRUPO_VEICULO AS G
                ON
	               P.GRUPO_VEICULO_GUID = G.GUID_GRUPO_VEICULO
";
        }

        protected override string sqlSelecionarPorID
        {
            get =>
          @"SELECT
                    P.GUID_PLANO_COBRANCA AS GUID_PLANO_COBRANCA,
	                P.NOME AS NOME_PLANO_COBRANCA,
	                P.KM_LIVRE_INCLUSO AS KM_LIVRE_INCLUSO_PLANO_COBRANCA,
                    P.VALOR_DIA AS VALOR_DIA_PLANO_COBRANCA,
                    P.VALOR_POR_KM AS VALOR_POR_KM_PLANO_COBRANCA,
                    P.PLANO AS PLANO_PLANO_COBRANCA,
                    G.GUID_GRUPO_VEICULO AS GUID_GRUPO_VEICULO,
	                G.NOME AS NOME_GRUPO_VEICULO
                FROM
                   TB_PLANO_COBRANCA AS P INNER JOIN
	               TB_GRUPO_VEICULO AS G
                ON
	               P.GRUPO_VEICULO_GUID = G.GUID_GRUPO_VEICULO
                WHERE
	                GUID_PLANO_COBRANCA = @GUID;";
        }

        protected override string sqlQuantidade
        {
            get =>
                    @"SELECT COUNT(*) FROM TB_PLANO_COBRANCA";
        }

        #endregion

        public string SqlDuplicidade(PlanoCobranca registro)
        {
            return "SELECT * FROM [TB_PLANO_COBRANCA] WHERE ([NOME] = '" + registro.Nome + "')" + $"AND [GUID_PLANO_COBRANCA] != '" + registro.Guid + "'";
        }

        public string SqlDuplicidadePlano(PlanoCobranca registro)
        {
            return "SELECT * FROM [TB_PLANO_COBRANCA] WHERE ([PLANO] = '" + registro.Plano + "')" + $"AND [GUID_PLANO_COBRANCA] != '" + registro.Guid + "'";
        }

    }
}
