﻿using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCondutor
{
    public class MapeadorCondutor : IMapeavel<Condutor>
    {

        MapeadorCliente  mapeadorCliente = new();
        Cliente cliente;
        public void ConfigurarParametrosRegistro(Condutor registro, SqlCommand cmdInserir)
        {
            cmdInserir.Parameters.AddWithValue("ID_CONDUTOR", registro.Id);
            cmdInserir.Parameters.AddWithValue("NOME", registro.Nome);
            cmdInserir.Parameters.AddWithValue("ENDERECO", registro.Endereco);
            cmdInserir.Parameters.AddWithValue("CNH", registro.CNH);
            cmdInserir.Parameters.AddWithValue("EMAIL", registro.Email);
            cmdInserir.Parameters.AddWithValue("TELEFONE", registro.Telefone);
            cmdInserir.Parameters.AddWithValue("CPF", registro.CPF);
            cmdInserir.Parameters.AddWithValue("CLIENTE_ID", registro.Cliente.Id);
            cmdInserir.Parameters.AddWithValue("DATA_VALIDADE_CNH", registro.DataValidadeCNH);

        }

        public Condutor ConverterParaRegistro(SqlDataReader leitorRegistro)
        {
            int idCondutor = Convert.ToInt32(leitorRegistro["ID_CONDUTOR"]);
            string nome = Convert.ToString(leitorRegistro["NOME_CONDUTOR"])!;
            string endereco = Convert.ToString(leitorRegistro["ENDERECO_CONDUTOR"])!;
            string cnh = Convert.ToString(leitorRegistro["CNH_CONDUTOR"])!;
            string email = Convert.ToString(leitorRegistro["EMAIL_CONDUTOR"])!;
            string telefone = Convert.ToString(leitorRegistro["TELEFONE_CONDUTOR"])!;
            string cpf = Convert.ToString(leitorRegistro["CPF_CONDUTOR"])!;
            cliente = mapeadorCliente.ConverterParaRegistro(leitorRegistro);
            DateTime dataValidadeCNH = Convert.ToDateTime(leitorRegistro["DATA_VALIDADE_CNH_CONDUTOR"])!;


            var condutor = new Condutor();
            condutor.Id = idCondutor;
            condutor.Nome = nome;
            condutor.Endereco = endereco;
            condutor.CNH = cnh;
            condutor.Email = email;
            condutor.Telefone = telefone;
            condutor.CPF = cpf!;
            condutor.Cliente = cliente;
            condutor.DataValidadeCNH = dataValidadeCNH;

            return condutor;
        }
    }
}
