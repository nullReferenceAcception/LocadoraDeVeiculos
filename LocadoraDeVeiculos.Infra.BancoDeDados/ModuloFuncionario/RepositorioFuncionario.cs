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
                        TIPO_PERFIL,
                        TELEFONE,
                        ENDERECO
                        )
                    VALUES
                        (
                        @NOME,
                        @SALARIO,
                        @DATA_ADMISSAO,
                        @LOGIN,
                        @SENHA,
                        @TIPO_PERFIL,
                        @TELEFONE,
                        @ENDERECO
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
                            TIPO_PERFIL = @TIPO_PERFIL,
                            @TELEFONE = @TELEFONE,
                            ENDERECO = @ENDERECO
                        WHERE
                            ID_FUNCIONARIO = @ID_FUNCIONARIO";
        }

        protected override string sqlExcluir
        {
            get =>
                @"DELETE FROM
                    TB_FUNCIONARIO
                WHERE
                    ID_FUNCIONARIO = @ID_FUNCIONARIO";
        }

        protected override string sqlSelecionarTodos
        {
            get =>
                @"SELECT        
                    ID_FUNCIONARIO AS ID_FUNCIONARIO, 
                    NOME AS NOME, 
                    SALARIO AS SALARIO,
                    DATA_ADMISSAO AS DATA_ADMISSAO, 
                    LOGIN AS LOGIN,
                    SENHA AS SENHA,
                    TIPO_PERFIL AS TIPO_PERFIL, 
                    TELEFONE AS TELEFONE, 
                    ENDERECO AS ENDERECO
                FROM            
                    TB_FUNCIONARIO";
        }

        protected override string sqlSelecionarPorID
        {
            get =>
                @"SELECT        
                    ID_FUNCIONARIO AS ID_FUNCIONARIO, 
                    NOME AS NOME, 
                    SALARIO AS SALARIO,
                    DATA_ADMISSAO AS DATA_ADMISSAO, 
                    LOGIN AS LOGIN,
                    SENHA AS SENHA,
                    TIPO_PERFIL AS TIPO_PERFIL, 
                    TELEFONE AS TELEFONE, 
                    ENDERECO AS ENDERECO
                FROM            
                    TB_FUNCIONARIO
                WHERE
                    ID_FUNCIONARIO = @ID_FUNCIONARIO";
        }

        #endregion

        protected override ValidationResult MandarSQLParaValidador(Funcionario registro, SqlConnection conexaoComBanco)
        {
            return Validar("SELECT * FROM TB_FUNCIONARIO WHERE ([NOME] = '" + registro.Nome + "')", registro, conexaoComBanco);
        }
    }
}
