using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;

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
                GUID_TAXA,
		        DESCRICAO, 
		        VALOR,
                EH_DIARIA
		        )
		        VALUES
		        (
                @GUID_TAXA,
		        @DESCRICAO,
		        @VALOR,
                @EH_DIARIA
		        );SELECT SCOPE_IDENTITY();";
        }
        protected override string sqlEditar
        {
            get =>
            @"UPDATE
	        TB_TAXA
		        SET
			DESCRICAO = @DESCRICAO,
			VALOR = @VALOR,
            EH_DIARIA = @EH_DIARIA
		        WHERE
			GUID_TAXA = @GUID_TAXA;";
        }

        protected override string sqlExcluir
        {
            get =>
            @"DELETE 
	            FROM
		            TB_TAXA
	            WHERE
		            GUID_TAXA = @GUID;";
        }

        protected override string sqlSelecionarTodos
        {
            get =>
            @"SELECT
                    GUID_TAXA AS GUID_TAXA,
	                DESCRICAO AS DESCRICAO_TAXA,
	                VALOR AS VALOR_TAXA,
                    EH_DIARIA AS EH_DIARIA_TAXA
                FROM
	                TB_TAXA";
        }

        protected override string sqlSelecionarPorID
        {
            get =>
           @"SELECT
                    GUID_TAXA AS GUID_TAXA,
	                DESCRICAO AS DESCRICAO_TAXA,
	                VALOR AS VALOR_TAXA,
                    EH_DIARIA AS EH_DIARIA_TAXA
                FROM
	                TB_TAXA
                WHERE
	                GUID_TAXA = @GUID;";
        }

        protected override string sqlQuantidade
        {
            get =>
                    @"SELECT COUNT(*) FROM TB_TAXA";
        }

        public bool VerificarDuplicidade(Taxa registro)
        {
            throw new System.NotImplementedException();
        }

        #endregion

     
    }
}
