using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Servico.Compartilhado;
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

        #region variaveis
        TMapeamento mapeador;
        SqlConnection conexao;
        #endregion

        #region construtor
        public RepositorioBaseEmBancoDeDados(TValidador validationRules, TMapeamento mapeavel)
        {
            this.mapeador = mapeavel;
            conexao = new SqlConnection(enderecoBanco);
        }
        #endregion

        public void Inserir(T registro)
        {
            conexao.Open();

            SqlCommand cmdInserir = new SqlCommand(sqlInserir, conexao);

            mapeador.ConfigurarParametrosRegistro(registro, cmdInserir);

            var ID = cmdInserir.ExecuteScalar();

            registro.Id = Convert.ToInt32(ID);
            conexao.Close();
        }

        public bool VerificarDuplicidade(string sql)
        {
            conexao.Open();
            var sqlCommand = new SqlCommand(sql, conexao);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            bool haRegistro = reader.HasRows;


            reader.Close();
            reader.Dispose();
            conexao.Close();
            return haRegistro;
        }

        public void Editar(T registro)
        {
            conexao.Open();

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexao);

            mapeador.ConfigurarParametrosRegistro(registro, comandoEdicao);

            comandoEdicao.ExecuteNonQuery();
            conexao.Close();

        }

        public string Excluir(T registro)
        {
            SqlConnection conexao = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexao);

            comandoExclusao.Parameters.AddWithValue("ID", registro.Id);

            conexao.Open();
            int IDRegistrosExcluidos = 0;

            string mensagen = null;

            // essa gambiarra foi feita porcausa das foreign keys
            try
            {
                IDRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();
                if (IDRegistrosExcluidos == 0)
                    mensagen = "Não foi possível remover o registro";
            }
            catch (SqlException excecao)
            {
                mensagen = excecao.Message;
            }

            conexao.Close();

            return mensagen;
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

        public T SelecionarPorID(int ID)
        {
            SqlConnection conexao = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorID, conexao);

            comandoSelecao.Parameters.AddWithValue("ID", ID);

            conexao.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            T registro = null!;

            if (leitorRegistro.Read())
                registro = mapeador.ConverterParaRegistro(leitorRegistro);

            conexao.Close();

            return registro;
        }
    }
}
