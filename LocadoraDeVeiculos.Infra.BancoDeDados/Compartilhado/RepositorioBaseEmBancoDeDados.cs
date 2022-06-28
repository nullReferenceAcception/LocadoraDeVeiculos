using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDados.Compartilhado
{
    public abstract class RepositorioBaseEmBancoDeDados<T, TValidador, TMapeamento>
        where T : EntidadeBase<T>
        where TValidador : AbstractValidator<T>
        where TMapeamento : IMapeavel<T>
    {
        #region abstract sqls

        protected const string enderecoBanco =
     "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=locadora_db;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        protected abstract string sqlInserir { get; }
        protected abstract string sqlEditar { get; }
        protected abstract string sqlExcluir { get; }
        protected abstract string sqlSelecionarTodos { get; }
        protected abstract string sqlSelecionarPorID { get; }
        #endregion

        protected abstract ValidationResult MandarSQLParaValidador(T registro, SqlConnection conexaoComBanco);

        #region variaveis
        TValidador validador;
        TMapeamento mapeador;
        #endregion

        #region construtor
        public RepositorioBaseEmBancoDeDados(AbstractValidator<T> validationRules, IMapeavel<T> mapeavel)
        {
            this.validador = (TValidador)validationRules;
            this.mapeador = (TMapeamento)mapeavel;
        }
        #endregion

        public ValidationResult Inserir(T registro)
        {
            SqlConnection conexao = new SqlConnection(enderecoBanco);
            conexao.Open();


            ValidationResult resultadoValidacao = MandarSQLParaValidador(registro,conexao);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlCommand cmdInserir = new SqlCommand(sqlInserir, conexao);

            mapeador.ConfigurarParametrosRegistro(registro, cmdInserir);

            var ID = cmdInserir.ExecuteScalar();

            registro.Id = Convert.ToInt32(ID);
            conexao.Close();
            return resultadoValidacao;
        }

        protected virtual ValidationResult Validar(string sql,T registro, SqlConnection conexaoComBanco)
        {
            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var sqlCommand = new SqlCommand(sql, conexaoComBanco);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Nome já está cadastrado"));

            reader.Close();
            reader.Dispose();

            return resultadoValidacao;
        }
       

        public ValidationResult Editar(T registro)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            ValidationResult resultadoValidacao = MandarSQLParaValidador(registro, conexaoComBanco);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            mapeador.ConfigurarParametrosRegistro(registro, comandoEdicao);

            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Excluir(T registro)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("ID", registro.Id);

            conexaoComBanco.Open();
            var resultadoValidacao = new ValidationResult();
            int IDRegistrosExcluidos = 0;

            // essa gambiarra foi feita porcausa das foreign keys
            try
            {
                IDRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                resultadoValidacao.Errors.Add(new ValidationFailure("", ex.Message));
            }

            if (IDRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public List<T> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            List<T> registros = new List<T>();

            while (leitorRegistro.Read())
            {
                T registro = mapeador.ConverterParaRegistro(leitorRegistro);
                registros.Add(registro);
            }

            conexaoComBanco.Close();

            return registros;
        }

        public T SelecionarPorID(int ID)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorID, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("ID", ID);

            conexaoComBanco.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            T registro = null!;

            if (leitorRegistro.Read())
                registro = mapeador.ConverterParaRegistro(leitorRegistro);

            conexaoComBanco.Close();

            return registro;
        }
    }
}
