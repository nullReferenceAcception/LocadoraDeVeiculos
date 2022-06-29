using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente
{
    public class MapeadorCliente : IMapeavel<Cliente>
    {
        public void ConfigurarParametrosRegistro(Cliente registro, SqlCommand cmdInserir)
        {
            cmdInserir.Parameters.AddWithValue("ID_CLIENTE", registro.Id);
            cmdInserir.Parameters.AddWithValue("NOME", registro.Nome);
            cmdInserir.Parameters.AddWithValue("ENDERECO", registro.Endereco);
            cmdInserir.Parameters.AddWithValue("CNH", registro.CNH);
            cmdInserir.Parameters.AddWithValue("EMAIL", registro.Email);
            cmdInserir.Parameters.AddWithValue("TELEFONE", registro.Telefone);
            cmdInserir.Parameters.AddWithValue("TIPO_CLIENTE", registro.PessoaFisica);
            cmdInserir.Parameters.AddWithValue("CPF", registro.CPF == null? DBNull.Value: registro.CPF);
            cmdInserir.Parameters.AddWithValue("CNPJ", registro.CNPJ == null ? DBNull.Value : registro.CNPJ);
        }

        public Cliente ConverterParaRegistro(SqlDataReader leitorRegistro)
        {
            int idCliente = Convert.ToInt32(leitorRegistro["ID_CLIENTE"]);
            string nome = Convert.ToString(leitorRegistro["NOME_CLIENTE"])!;
            string endereco = Convert.ToString(leitorRegistro["ENDERECO_CLIENTE"])!;
            string cnh = Convert.ToString(leitorRegistro["CNH_CLIENTE"])!;
            string email = Convert.ToString(leitorRegistro["EMAIL_CLIENTE"])!;
            string telefone = Convert.ToString(leitorRegistro["TELEFONE_CLIENTE"])!;
            bool pessoaFisica = Convert.ToBoolean(leitorRegistro["TIPO_CLIENTE_CLIENTE"]);


            string cpf = null!;
            string cnpj = null!;

            if (! DBNull.Value.Equals(leitorRegistro["CPF_CLIENTE"]))
                 cpf =  Convert.ToString(leitorRegistro["CPF_CLIENTE"])!;
            else
             cnpj = Convert.ToString(leitorRegistro["CNPJ_CLIENTE"])!;

            var cliente = new Cliente();
            cliente.Id = idCliente;
            cliente.Nome = nome;
            cliente.Endereco = endereco;
            cliente.CNH = cnh;
            cliente.Email = email;
            cliente.Telefone = telefone;
            cliente.PessoaFisica = pessoaFisica; 
            cliente.CPF = cpf!;
            cliente.CNPJ = cnpj!;

            return cliente;
        }
    }
}
