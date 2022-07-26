using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;

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
                    GUID_CLIENTE,
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
                    @GUID_CLIENTE,
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
			            GUID_CLIENTE = @GUID_CLIENTE;";
        }
        protected override string sqlExcluir
        {
            get =>
            @"DELETE 
	            FROM
		            TB_CLIENTE
	            WHERE
		            GUID_CLIENTE = @GUID;";
        }

        protected override string sqlSelecionarTodos 
        {
            get =>
            @"SELECT
                    GUID_CLIENTE AS GUID_CLIENTE,
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
                    GUID_CLIENTE AS GUID_CLIENTE,
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
                    GUID_CLIENTE = @guid;";
        }

        private string sqlSelecionarTodosPessoasFisicas
        {
            get =>
            @"SELECT
                    GUID_CLIENTE AS GUID_CLIENTE,
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

        private string sqlSelecionarTodosPessoasJuridicas
        {
            get =>
            @"SELECT
                    GUID_CLIENTE AS GUID_CLIENTE,
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
                    TIPO_CLIENTE = 0;";
        }

        protected override string sqlQuantidade
        {
            get =>
                    @"SELECT COUNT(*) FROM TB_CLIENTE WHERE TIPO_CLIENTE = 0";
        }
        //sqlQuantidade so verifica quantidade de pessoas juridicas pq nao houve necessidade de ver quantidade de pessoas fisicas  ate agora caso precissa crie um metodo e de um override no outro ou crie um metodo no repositorio base que aceite um sql como parametro

        #endregion

        public string SqlDuplicidade(Cliente registro)
        {
           return "SELECT * FROM TB_CLIENTE WHERE ([NOME] = '" + registro.Nome + "')" + "AND [GUID_CLIENTE] != '" + registro.Id + "' ";
        }
        
        public List<Cliente> SelecionarTodosClientesQueSaoPessoaFisica()
        {
            return SelecionarTodosPersonalizado(sqlSelecionarTodosPessoasFisicas);
        }

        public List<Cliente> SelecionarTodosClientesQueSaoPessoaJuridica()
        {
            return SelecionarTodosPersonalizado(sqlSelecionarTodosPessoasJuridicas);
        }

        // gambiarra feita apos implementacao de Orm
        public bool VerificarDuplicidade(Cliente registro)
        {
            throw new NotImplementedException();
        }
        // gambiarra feita apos implementacao de Orm
        public bool VerificarDuplicidadeCNPJ(Cliente registro)
        {
            throw new NotImplementedException();
        }
    }
}
