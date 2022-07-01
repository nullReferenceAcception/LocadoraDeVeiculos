using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente
{
    public class RepositorioCliente : RepositorioBaseEmBancoDeDados<Cliente, ValidadorCliente, MapeadorCliente>, IRepositorioCliente
    {
        MapeadorCliente mapeador;
        public RepositorioCliente() : base(new MapeadorCliente())
        {
            mapeador = new MapeadorCliente();
        }

        #region SQL Queries
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
                    CNPJ,
                    DATA_VALIDADE_CNH
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
                    @CNPJ,
                    @DATA_VALIDADE_CNH
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
                        CNPJ = @CNPJ,
                        DATA_VALIDADE_CNH = @DATA_VALIDADE_CNH
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
                    CNPJ AS CNPJ_CLIENTE,
                    DATA_VALIDADE_CNH AS  DATA_VALIDADE_CNH_CLIENTE
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
                    CNPJ AS CNPJ_CLIENTE,
                    DATA_VALIDADE_CNH AS DATA_VALIDADE_CNH_CLIENTE
                FROM
	                TB_CLIENTE
                WHERE 
                    ID_CLIENTE = @ID;";
        }


        private string sqlSelecionarTodosPessoasFisicas
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
                    CNPJ AS CNPJ_CLIENTE,
                    DATA_VALIDADE_CNH AS  DATA_VALIDADE_CNH_CLIENTE
                FROM
	                TB_CLIENTE
                WHERE 
                    TIPO_CLIENTE = 1;";

        }



        #endregion

        public string SqlDuplicidade(Cliente registro)
        {
           return "SELECT * FROM TB_CLIENTE WHERE ([NOME] = '" + registro.Nome + "')" + $"AND [ID_CLIENTE] != {registro.Id}";
        }


        public List<Cliente> SelecionarTodosClientesQueSaoPessoaFisica()
        {
            SqlConnection conexao = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodosPessoasFisicas, conexao);

            conexao.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            List<Cliente> registros = new List<Cliente>();

            while (leitorRegistro.Read())
            {
                Cliente registro = mapeador.ConverterParaRegistro(leitorRegistro);
                registros.Add(registro);
            }

            conexao.Close();

            return registros;
        }


    }
}
