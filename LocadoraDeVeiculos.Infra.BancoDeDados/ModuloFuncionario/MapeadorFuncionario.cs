﻿using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloFuncionario
{
    public class MapeadorFuncionario : IMapeavel<Funcionario>
    {
        public void ConfigurarParametrosRegistro(Funcionario registro, SqlCommand cmdInserir)
        {
            cmdInserir.Parameters.AddWithValue("GUID_FUNCIONARIO", registro.Id);
            cmdInserir.Parameters.AddWithValue("NOME", registro.Nome);
            cmdInserir.Parameters.AddWithValue("ENDERECO", registro.Endereco == null ? DBNull.Value : registro.Endereco);
            cmdInserir.Parameters.AddWithValue("EMAIL", registro.Email == null ? DBNull.Value : registro.Email);
            cmdInserir.Parameters.AddWithValue("TELEFONE", registro.Telefone == null ? DBNull.Value : registro.Telefone);
            cmdInserir.Parameters.AddWithValue("LOGIN", registro.Login);
            cmdInserir.Parameters.AddWithValue("EH_ADMIN", registro.EhAdmin);
            cmdInserir.Parameters.AddWithValue("SENHA", registro.Senha);
            cmdInserir.Parameters.AddWithValue("DATA_ADMISSAO", registro.DataAdmissao);
            cmdInserir.Parameters.AddWithValue("SALARIO", registro.Salario);
            cmdInserir.Parameters.AddWithValue("CIDADE", registro.Cidade);
            cmdInserir.Parameters.AddWithValue("ESTA_ATIVO", registro.EstaAtivo);
        }

        public Funcionario ConverterParaRegistro(SqlDataReader leitorRegistro)
        {
            Guid idFuncionario = Guid.Parse(leitorRegistro["GUID_FUNCIONARIO"].ToString());
            string nome = leitorRegistro["NOME"].ToString()!;
            string endereco = leitorRegistro["ENDERECO"].ToString()!;
            string email = leitorRegistro["EMAIL"].ToString()!;
            string telefone = leitorRegistro["TELEFONE"].ToString()!;
            string login = leitorRegistro["LOGIN"].ToString()!;
            string senha = leitorRegistro["SENHA"].ToString()!;
            bool ehAdmin = Convert.ToBoolean(leitorRegistro["EH_ADMIN"]);
            DateTime dataAdmissao = Convert.ToDateTime(leitorRegistro["DATA_ADMISSAO"]);
            Decimal salario = Convert.ToDecimal(leitorRegistro["SALARIO"]);
            string cidade = leitorRegistro["CIDADE"].ToString()!;
            bool estaAtivo = Convert.ToBoolean(leitorRegistro["ESTA_ATIVO"]);

            var funcionario = new Funcionario();

            funcionario.Id = idFuncionario;
            funcionario.Nome = nome;
            funcionario.Endereco = endereco;
            funcionario.Email = email;
            funcionario.Telefone = telefone;
            funcionario.Login = login;
            funcionario.Senha = senha;
            funcionario.DataAdmissao = dataAdmissao;
            funcionario.Salario = salario;
            funcionario.EhAdmin = ehAdmin;
            funcionario.Cidade = cidade;
            funcionario.EstaAtivo = estaAtivo;

            return funcionario;
        }
    }
}
