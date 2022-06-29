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
                    CPF
                )
                VALUES
                (
                    @NOME,
                    @ENDERECO,
                    @CNH,
                    @EMAIL,
                    @TELEFONE,
                    @CPF
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
                        CPF = @CPF
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
                    ID_CONDUTOR AS ID_CONDUTOR,
	                NOME AS NOME_CLIENTE,
	                ENDERECO AS ENDERECO_CLIENTE,
                    CNH AS CNH_CLIENTE,
                    EMAIL AS EMAIL_CLIENTE,
                    TELEFONE AS TELEFONE_CLIENTE,
                    CPF AS CPF_CLIENTE
                FROM
	                TB_CONDUTOR";
        }

        protected override string sqlSelecionarPorID
        {
            get => @"SELECT
                    ID_CONDUTOR AS ID_CONDUTOR,
	                NOME AS NOME_CONDUTOR,
	                ENDERECO AS ENDERECO_CONDUTOR,
                    CNH AS CNH_CONDUTOR,
                    EMAIL AS EMAIL_CONDUTOR,
                    TELEFONE AS TELEFONE_CONDUTOR,
                    CPF AS CPF_CONDUTOR
                FROM
	                TB_CONDUTOR
                WHERE 
                    ID_CONDUTOR = @ID;";
        }

        public string SqlDuplicidade(Condutor registro)
        {
            return "SELECT * FROM TB_CONDUTOR WHERE ([NOME] = '" + registro.Nome + "')" + $"AND [ID_CONDUTOR] != {registro.Id}";
        }
    }
}
