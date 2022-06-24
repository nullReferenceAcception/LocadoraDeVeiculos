using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioBaseEmBancoDeDados<Funcionario, ValidadorFuncionario, MapeadorFuncionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionario() : base(new ValidadorFuncionario(), new MapeadorFuncionario())
        {

        }

        #region SQLQueries
        protected override string sqlInserir
        {
            get =>
                @"INSERT INTO
                    TB_FUNCIONARIO
                        (
                        NOME,
                        SALARIO,
                        DATA_ADMISSAO,
                        LOGIN,
                        SENHA,
                        EH_ADMIN,
                        TELEFONE,
                        ENDERECO,
                        EMAIL
                        )
                    VALUES
                        (
                        @NOME,
                        @SALARIO,
                        @DATA_ADMISSAO,
                        @LOGIN,
                        @SENHA,
                        @EH_ADMIN,
                        @TELEFONE,
                        @ENDERECO,
                        @EMAIL
                        ); SELECT SCOPE_IDENTITY();";
        }

        protected override string sqlEditar
        {
            get =>
                @"UPDATE
                    TB_FUNCIONARIO
                        SET
                            NOME = @NOME,
                            SALARIO = @SALARIO,
                            DATA_ADMISSAO = @DATA_ADMISSAO,
                            LOGIN = @LOGIN,
                            SENHA = @SENHA,
                            EH_ADMIN = @EH_ADMIN,
                            @TELEFONE = @TELEFONE,
                            ENDERECO = @ENDERECO,
                            EMAIL = @EMAIL
                        WHERE
                            ID_FUNCIONARIO = @ID";
        }

        protected override string sqlExcluir
        {
            get =>
                @"DELETE FROM
                    TB_FUNCIONARIO
                WHERE
                    ID_FUNCIONARIO = @ID";
        }

        protected override string sqlSelecionarTodos
        {
            get =>
                @"SELECT        
                    ID_FUNCIONARIO AS ID, 
                    NOME AS NOME, 
                    SALARIO AS SALARIO,
                    DATA_ADMISSAO AS DATA_ADMISSAO, 
                    LOGIN AS LOGIN,
                    SENHA AS SENHA,
                    EH_ADMIN AS EH_ADMIN, 
                    TELEFONE AS TELEFONE, 
                    ENDERECO AS ENDERECO,
                    EMAIL AS EMAIL
                FROM            
                    TB_FUNCIONARIO";
        }

        protected override string sqlSelecionarPorID
        {
            get =>
                @"SELECT        
                    ID_FUNCIONARIO AS ID, 
                    NOME AS NOME, 
                    SALARIO AS SALARIO,
                    DATA_ADMISSAO AS DATA_ADMISSAO, 
                    LOGIN AS LOGIN,
                    SENHA AS SENHA,
                    EH_ADMIN AS EH_ADMIN, 
                    TELEFONE AS TELEFONE, 
                    ENDERECO AS ENDERECO,
                    EMAIL AS EMAIL
                FROM            
                    TB_FUNCIONARIO
                WHERE
                    ID_FUNCIONARIO = @ID";
        }

        #endregion

        protected override ValidationResult MandarSQLParaValidador(Funcionario registro, SqlConnection conexaoComBanco)
        {
            return Validar("SELECT * FROM TB_FUNCIONARIO WHERE ([NOME] = '" + registro.Nome + "')", registro, conexaoComBanco);
        }
    }
}
