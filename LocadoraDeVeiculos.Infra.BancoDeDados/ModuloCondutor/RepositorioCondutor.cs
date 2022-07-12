using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCondutor
{
    public class RepositorioCondutor : RepositorioBaseEmBancoDeDados<Condutor, ValidadorCondutor, MapeadorCondutor>, IRepositorioCondutor
    {
        public RepositorioCondutor() : base(new MapeadorCondutor())
        {
        }

        #region SQLs
        protected override string sqlInserir
        {
            get =>
                @"INSERT INTO TB_CONDUTOR
                (
                    GUID_CONDUTOR,
                    NOME,
                    ENDERECO,
                    CNH,
                    EMAIL,
                    TELEFONE,
                    CPF,
                    CLIENTE_GUID,
                    DATA_VALIDADE_CNH
                )
                VALUES
                (
                    @GUID_CONDUTOR,
                    @NOME,
                    @ENDERECO,
                    @CNH,
                    @EMAIL,
                    @TELEFONE,
                    @CPF,
                    @CLIENTE_GUID,
                    @DATA_VALIDADE_CNH
                        
                ); SELECT SCOPE_IDENTITY();";
        }

        protected override string sqlEditar
        {
            get =>
            @"UPDATE
	                TB_CONDUTOR
		                SET
			            NOME = @NOME,
			            ENDERECO = @ENDERECO,
                        CNH = @CNH,
                        EMAIL = @EMAIL,
                        TELEFONE = @TELEFONE,
                        CPF = @CPF,
                        CLIENTE_GUID = @CLIENTE_GUID,
                        DATA_VALIDADE_CNH = @DATA_VALIDADE_CNH
		            WHERE
			            GUID_CONDUTOR = @GUID_CONDUTOR;";
        }
        protected override string sqlExcluir
        {
            get =>
            @"DELETE 
	            FROM
		            TB_CONDUTOR
	            WHERE
		            GUID_CONDUTOR = @guid;";
        }

        protected override string sqlSelecionarTodos
        {
            get =>
            @"SELECT
                    CON.GUID_CONDUTOR AS GUID_CONDUTOR,
	                CON.NOME AS NOME_CONDUTOR,
	                CON.ENDERECO AS ENDERECO_CONDUTOR,
                    CON.CNH AS CNH_CONDUTOR,
                    CON.EMAIL AS EMAIL_CONDUTOR,
                    CON.TELEFONE AS TELEFONE_CONDUTOR,
                    CON.CPF AS CPF_CONDUTOR,
                    CON.DATA_VALIDADE_CNH AS DATA_VALIDADE_CNH_CONDUTOR,

                    CLI.GUID_CLIENTE AS GUID_CLIENTE,
	                CLI.NOME AS NOME_CLIENTE,
	                CLI.ENDERECO AS ENDERECO_CLIENTE,
                    CLI.CNH AS CNH_CLIENTE,
                    CLI.EMAIL AS EMAIL_CLIENTE,
                    CLI.TELEFONE AS TELEFONE_CLIENTE,
                    CLI.TIPO_CLIENTE AS TIPO_CLIENTE_CLIENTE,
                    CLI.CPF AS CPF_CLIENTE,
                    CLI.CNPJ AS CNPJ_CLIENTE,
                    CLI.DATA_VALIDADE_CNH AS DATA_VALIDADE_CNH_CLIENTE     
                FROM
	                TB_CONDUTOR AS CON INNER JOIN
                        TB_CLIENTE AS CLI ON CON.CLIENTE_GUID = CLI.GUID_CLIENTE";
        }

        protected override string sqlSelecionarPorID
        {
            get => @"SELECT
                    CON.GUID_CONDUTOR AS GUID_CONDUTOR,
	                CON.NOME AS NOME_CONDUTOR,
	                CON.ENDERECO AS ENDERECO_CONDUTOR,
                    CON.CNH AS CNH_CONDUTOR,
                    CON.EMAIL AS EMAIL_CONDUTOR,
                    CON.TELEFONE AS TELEFONE_CONDUTOR,
                    CON.CPF AS CPF_CONDUTOR,
                    CON.DATA_VALIDADE_CNH AS DATA_VALIDADE_CNH_CONDUTOR,

                    CLI.GUID_CLIENTE AS GUID_CLIENTE,
	                CLI.NOME AS NOME_CLIENTE,
	                CLI.ENDERECO AS ENDERECO_CLIENTE,
                    CLI.CNH AS CNH_CLIENTE,
                    CLI.EMAIL AS EMAIL_CLIENTE,
                    CLI.TELEFONE AS TELEFONE_CLIENTE,
                    CLI.TIPO_CLIENTE AS TIPO_CLIENTE_CLIENTE,
                    CLI.CPF AS CPF_CLIENTE,
                    CLI.CNPJ AS CNPJ_CLIENTE,
                    CLI.DATA_VALIDADE_CNH AS DATA_VALIDADE_CNH_CLIENTE  
                FROM
	                TB_CONDUTOR AS CON INNER JOIN
                        TB_CLIENTE AS CLI ON CON.CLIENTE_GUID = CLI.GUID_CLIENTE   
                WHERE
                    CON.GUID_CONDUTOR = @GUID";
        }

        protected override string sqlQuantidade
        {
            get =>
                    @"SELECT COUNT(*) from TB_CONDUTOR";
        }

        #endregion

        public string SqlDuplicidade(Condutor registro)
        {
            return "SELECT * FROM TB_CONDUTOR WHERE ([NOME] = '" + registro.Nome + "')" + "AND [GUID_CONDUTOR] != '" + registro.Guid + "'";
        }
    }
}
