using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioBaseEmBancoDeDados<Funcionario, ValidadorFuncionario, MapeadorFuncionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionario() : base( new MapeadorFuncionario())
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
                        EMAIL,
                        CIDADE,
                        ESTA_ATIVO
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
                        @EMAIL,
                        @CIDADE,
                        @ESTA_ATIVO
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
                            TELEFONE = @TELEFONE,
                            ENDERECO = @ENDERECO,
                            EMAIL = @EMAIL,
                            CIDADE = @CIDADE
                        WHERE
                            ID_FUNCIONARIO = @ID_FUNCIONARIO";
        }

        protected override string sqlExcluir
        {
            get =>
                @"UPDATE
                    TB_FUNCIONARIO
                SET
                    ESTA_ATIVO = 0
                WHERE
                    ID_FUNCIONARIO = @ID";
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
                    EH_ADMIN AS EH_ADMIN, 
                    TELEFONE AS TELEFONE, 
                    ENDERECO AS ENDERECO,
                    EMAIL AS EMAIL,
                    CIDADE AS CIDADE,
                    ESTA_ATIVO AS ESTA_ATIVO
                FROM            
                    TB_FUNCIONARIO
                WHERE
                    ESTA_ATIVO = 1";
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
                    EH_ADMIN AS EH_ADMIN, 
                    TELEFONE AS TELEFONE, 
                    ENDERECO AS ENDERECO,
                    EMAIL AS EMAIL,
                    CIDADE AS CIDADE,
                    ESTA_ATIVO AS ESTA_ATIVO
                FROM            
                    TB_FUNCIONARIO
                WHERE
                    ID_FUNCIONARIO = @ID";
        }

        #endregion

        public string SqlDuplicidade(Funcionario registro)
        {
            return  "SELECT * FROM TB_FUNCIONARIO WHERE ([LOGIN] = '" + registro.Login + "')" + $"AND [ID_FUNCIONARIO] != {registro.Id}";
        }
    }
}
