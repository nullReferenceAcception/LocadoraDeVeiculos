using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente
{
    public class RepositorioCliente : RepositorioBaseEmBancoDeDados<Cliente, ValidadorCliente, MapeadorCliente>, IRepositorioCliente
    {
        public RepositorioCliente() : base(new ValidadorCliente(), new MapeadorCliente())
        {
        }

        protected override string sqlInserir
        {
            get =>
                @"INSERT INTO TB_CLIENTE
                (
                    NOME,
                    ENDERECO,
                    CNH,
                    EMAIL,
                    TELEFONE,
                    TIPO_CLIENTE,
                    CPF,
                    CNPJ
                )
                VALUES
                (
                    @NOME,
                    @ENDERECO,
                    @CNH,
                    @EMAIL,
                    @TELEFONE,
                    @TIPO_CLIENTE,
                    @CPF,
                    @CNPJ
                ); SELECT SCOPE_IDENTITY();";
        }

        protected override string sqlEditar
        {
                get => 
                @"UPDATE
	                TB_CLIENTE
		                SET
			            NOME = @NOME,
			            ENDERECO = @ENDERECO,
                        CNH = @CNH,
                        EMAIL = @EMAIL,
                        TELEFONE = @TELEFONE,
                        TIPO_CLIENTE = @TIPO_CLIENTE,
                        CPF = @CPF,
                        CNPJ = @CNPJ
		            WHERE
			            ID_CLIENTE = @ID_CLIENTE;";
        }
        protected override string sqlExcluir
        {
            get =>
            @"DELETE 
	            FROM
		            TB_CLIENTE
	            WHERE
		            ID_CLIENTE = @ID;";
        }

        protected override string sqlSelecionarTodos 
        {
            get =>
            @"SELECT
                    ID_CLIENTE AS ID_CLIENTE,
	                NOME AS NOME_CLIENTE,
	                ENDERECO AS ENDERECO_CLIENTE,
                    CNH AS CNH_CLIENTE,
                    EMAIL AS EMAIL_CLIENTE,
                    TELEFONE AS TELEFONE_CLIENTE,
                    TIPO_CLIENTE AS TIPO_CLIENTE_CLIENTE,
                    CPF AS CPF_CLIENTE,
                    CNPJ AS CNPJ_CLIENTE
                FROM
	                TB_CLIENTE";
        }

        protected override string sqlSelecionarPorID 
        { get => @"SELECT
                    ID_CLIENTE AS ID_CLIENTE,
	                NOME AS NOME_CLIENTE,
	                ENDERECO AS ENDERECO_CLIENTE,
                    CNH AS CNH_CLIENTE,
                    EMAIL AS EMAIL_CLIENTE,
                    TELEFONE AS TELEFONE_CLIENTE,
                    TIPO_CLIENTE AS TIPO_CLIENTE_CLIENTE,
                    CPF AS CPF_CLIENTE,
                    CNPJ AS CNPJ_CLIENTE
                FROM
	                TB_CLIENTE
                WHERE 
                    ID_CLIENTE = @ID;";
        }

        protected override ValidationResult MandarSQLParaValidador(Cliente registro, SqlConnection conexaoComBanco)
        {
            return Validar("SELECT * FROM TB_CLIENTE WHERE ([NOME] = '" + registro.Nome + "')" + $"AND [ID_CLIENTE] != {registro.Id}", registro, conexaoComBanco);
        }
    }
}
