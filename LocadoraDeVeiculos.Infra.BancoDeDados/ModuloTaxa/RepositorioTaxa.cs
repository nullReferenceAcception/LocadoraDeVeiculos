using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloTaxa
{
    public class RepositorioTaxa : RepositorioBaseEmBancoDeDados<Taxa,ValidadorTaxa,MapeadorTaxa>
    {


        public RepositorioTaxa() : base(new ValidadorTaxa(), new MapeadorTaxa())
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
		        );";
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
		            ID_TAXA = @ID_TAXA;";
        }

        protected override string sqlSelecionarTodos
        {
            get =>
            @"SELECT
                    ID_TAXA AS ID_TAXA
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
                ID_TAXA AS ID_TAXA
	                DESCRICAO AS DESCRICAO_TAXA,
	                VALOR AS VALOR_TAXA
                FROM
	                TB_TAXA
                WHERE
	            ID_TAXA = @ID_TAXA;";
        }

        #endregion

    }
}
