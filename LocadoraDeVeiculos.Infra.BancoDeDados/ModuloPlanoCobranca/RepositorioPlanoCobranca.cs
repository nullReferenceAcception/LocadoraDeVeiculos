using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		        [TB_PLANO_COBRANCA]
		        (
		        NOME,
                KM_LIVRE_INCLUSO,
                VALOR_DIA,
                VALOR_POR_KM,
                GRUPO_VEICULO_ID
		        )
		        VALUES
		        (
		        @NOME,
		        @KM_LIVRE_INCLUSO,
                @VALOR_DIA,
                @VALOR_POR_KM,
                @GRUPO_VEICULO_ID
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
            GRUPO_VEICULO_ID = @GRUPO_VEICULO_ID
		        WHERE
			ID_PLANO_COBRANCA = @ID_PLANO_COBRANCA;";
        }

        protected override string sqlExcluir
        {
            get =>
            @"DELETE 
	            FROM
		            TB_PLANO_COBRANCA
	            WHERE
		            ID_PLANO_COBRANCA = @ID;";
        }

        protected override string sqlSelecionarTodos
        {
            get =>
            @"SELECT
                    P.ID_PLANO_COBRANCA,
	                P.NOME AS NOME_PLANO_COBRANCA,
	                P.KM_LIVRE_INCLUSO AS KM_LIVRE_INCLUSO_PLANO_COBRANCA,
                    P.VALOR_DIA AS VALOR_DIA_PLANO_COBRANCA,
                    P.VALOR_POR_KM AS VALOR_POR_KM_PLANO_COBRANCA,
                    G.ID_GRUPO_VEICULO AS ID_GRUPO_VEICULO,
	                G.NOME AS NOME_GRUPO_VEICULO
                FROM
                   TB_PLANO_COBRANCA AS P INNER JOIN
	               TB_GRUPO_VEICULO AS G
                ON
	               P.GRUPO_VEICULO_ID = G.ID_GRUPO_VEICULO
";
        }

        protected override string sqlSelecionarPorID
        {
            get =>
          @"SELECT
                    P.ID_PLANO_COBRANCA,
	                P.NOME AS NOME_PLANO_COBRANCA,
	                P.KM_LIVRE_INCLUSO AS KM_LIVRE_INCLUSO_PLANO_COBRANCA,
                    P.VALOR_DIA AS VALOR_DIA_PLANO_COBRANCA,
                    P.VALOR_POR_KM AS VALOR_POR_KM_PLANO_COBRANCA,
                    G.ID_GRUPO_VEICULO AS ID_GRUPO_VEICULO,
	                G.NOME AS NOME_GRUPO_VEICULO
                FROM
                   TB_PLANO_COBRANCA AS P INNER JOIN
	               TB_GRUPO_VEICULO AS G
                ON
	               P.GRUPO_VEICULO_ID = G.ID_GRUPO_VEICULO
                WHERE
	            ID_PLANO_COBRANCA = @ID;";
        }




        #endregion
        public string SqlDuplicidade(PlanoCobranca registro)
        {
            return "SELECT * FROM [TB_PLANO_COBRANCA] WHERE ([NOME] = '" + registro.Nome + "')" + $"AND [ID_PLANO_COBRANCA] != {registro.Id}";
        }
    }
}
