using FluentValidation;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace LocadoraDeVeiculos.Infra.BancoDados.Compartilhado
{
    public abstract class RepositorioBaseEmBancoDeDados<T, TValidador, TMapeamento>
        where T : EntidadeBase<T>
        where TValidador : AbstractValidator<T>
        where TMapeamento : IMapeavel<T>
    {
        #region abstract sqls

        private readonly string enderecoBanco;
        protected abstract string sqlInserir { get; }
        protected abstract string sqlEditar { get; }
        protected abstract string sqlExcluir { get; }
        protected abstract string sqlSelecionarTodos { get; }
        protected abstract string sqlSelecionarPorID { get; }
        protected abstract string sqlQuantidade { get; }


        #endregion

        #region variaveis
        TMapeamento mapeador;
        SqlConnection conexao;
        #endregion

        #region construtor
        public RepositorioBaseEmBancoDeDados(TMapeamento mapeavel)
        {
            this.mapeador = mapeavel;

            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            enderecoBanco = configuracao.GetConnectionString("SqlServer");

            conexao = new SqlConnection(enderecoBanco);
        }
        #endregion

        public void Inserir(T registro)
        {
            conexao.Open();

            SqlCommand cmdInserir = new SqlCommand(sqlInserir, conexao);

            mapeador.ConfigurarParametrosRegistro(registro, cmdInserir);

            cmdInserir.ExecuteNonQuery();

            conexao.Close();
        }

        public void Editar(T registro)
        {
            conexao.Open();

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexao);

            mapeador.ConfigurarParametrosRegistro(registro, comandoEdicao);

            comandoEdicao.ExecuteNonQuery();
            conexao.Close();
        }

        public void Excluir(T registro)
        {
            SqlConnection conexao = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexao);

            comandoExclusao.Parameters.AddWithValue("guid", registro.Id);

            try
            {
                conexao.Open();

                comandoExclusao.ExecuteNonQuery();

                conexao.Close();
            }
            catch (Exception ex)
            {
                conexao.Close();
                if (ex != null && ex.Message.Contains("the Delete statement conflicted with the REFRENCE costraint"))
                    throw new NaoPodeExcluirEsteRegistroException(ex);

                throw;
            }
        }

        public List<T> SelecionarTodos()
        {
            SqlConnection conexao = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexao);

            conexao.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            List<T> registros = new List<T>();

            while (leitorRegistro.Read())
            {
                T registro = mapeador.ConverterParaRegistro(leitorRegistro);
                registros.Add(registro);
            }

            conexao.Close();

            return registros;
        }

        protected List<T> SelecionarTodosPersonalizado(string sql)
        {
            SqlConnection conexao = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sql, conexao);

            conexao.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            List<T> registros = new List<T>();

            while (leitorRegistro.Read())
            {
                T registro = mapeador.ConverterParaRegistro(leitorRegistro);
                registros.Add(registro);
            }

            conexao.Close();

            return registros;
        }

        public T SelecionarPorId(Guid guid)
        {
            SqlConnection conexao = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorID, conexao);

            comandoSelecao.Parameters.AddWithValue("guid", guid);

            conexao.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            T registro = null!;

            if (leitorRegistro.Read())
                registro = mapeador.ConverterParaRegistro(leitorRegistro);

            conexao.Close();

            return registro;
        }

        public bool VerificarDuplicidade(string sql)
        {
            conexao.Open();
            var sqlCommand = new SqlCommand(sql, conexao);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            bool haRegistro = reader.HasRows;
            conexao.Close();
            return haRegistro;
        }

        public int QuantidadeRegistros()
        {
            conexao.Open();
            var sqlCommand = new SqlCommand(sqlQuantidade, conexao);

            int quantidade = (int)sqlCommand.ExecuteScalar();

            conexao.Close();
            return quantidade;
        }

        //gambiarra feita apos implementacao do ORM
        public bool VerificarDuplicidade(T registro)
        {
            throw new System.NotImplementedException();
        }


    }
}
