using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCondutor
{
    public class RepositorioCondutor : RepositorioBaseEmBancoDeDados<Condutor, ValidadorCondutor, MapeadorCondutor>, IRepositorioCondutor
    {

        public RepositorioCondutor() : base(new MapeadorCondutor())
        {

        }



        protected override string sqlInserir
        {
            get =>
                @"INSERT INTO TB_CONDUTOR
                (
                    NOME,
                    ENDERECO,
                    CNH,
                    EMAIL,
                    TELEFONE,
                    CPF,
                    CLIENTE_ID,
                    DATA_VALIDADE_CNH
                )
                VALUES
                (
                    @NOME,
                    @ENDERECO,
                    @CNH,
                    @EMAIL,
                    @TELEFONE,
                    @CPF,
                    @CLIENTE_ID,
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
                        CLIENTE_ID = @CLIENTE_ID,
                        DATA_VALIDADE_CNH = @DATA_VALIDADE_CNH
		            WHERE
			            ID_CONDUTOR = @ID_CONDUTOR;";
        }
        protected override string sqlExcluir
        {
            get =>
            @"DELETE 
	            FROM
		            TB_CONDUTOR
	            WHERE
		            ID_CONDUTOR = @ID;";
        }

        protected override string sqlSelecionarTodos
        {
            get =>
            @"SELECT
                    CON.ID_CONDUTOR AS ID_CONDUTOR,
	                CON.NOME AS NOME_CONDUTOR,
	                CON.ENDERECO AS ENDERECO_CONDUTOR,
                    CON.CNH AS CNH_CONDUTOR,
                    CON.EMAIL AS EMAIL_CONDUTOR,
                    CON.TELEFONE AS TELEFONE_CONDUTOR,
                    CON.CPF AS CPF_CONDUTOR,
                    CON.DATA_VALIDADE_CNH AS DATA_VALIDADE_CNH_CONDUTOR,

                                                CLI.ID_CLIENTE AS ID_CLIENTE,
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
                        TB_CLIENTE AS CLI ON CON.CLIENTE_ID = CLI.ID_CLIENTE";
        }

        protected override string sqlSelecionarPorID
        {
            get => @"SELECT
                    CON.ID_CONDUTOR AS ID_CONDUTOR,
	                CON.NOME AS NOME_CONDUTOR,
	                CON.ENDERECO AS ENDERECO_CONDUTOR,
                    CON.CNH AS CNH_CONDUTOR,
                    CON.EMAIL AS EMAIL_CONDUTOR,
                    CON.TELEFONE AS TELEFONE_CONDUTOR,
                    CON.CPF AS CPF_CONDUTOR,
                    CON.DATA_VALIDADE_CNH AS DATA_VALIDADE_CNH_CONDUTOR,

                                                CLI.ID_CLIENTE AS ID_CLIENTE,
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
                        TB_CLIENTE AS CLI ON CON.CLIENTE_ID = CLI.ID_CLIENTE   
                            WHERE
                            CLI.ID_CLIENTE = @ID";
        }

        public string SqlDuplicidade(Condutor registro)
        {
            return "SELECT * FROM TB_CONDUTOR WHERE ([NOME] = '" + registro.Nome + "')" + $"AND [ID_CONDUTOR] != {registro.Id}";
        }
    }
}
