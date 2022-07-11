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
            cmdInserir.Parameters.AddWithValue("GUID_CLIENTE", registro.guid);
            cmdInserir.Parameters.AddWithValue("NOME", registro.Nome);
            cmdInserir.Parameters.AddWithValue("ENDERECO", registro.Endereco);
            cmdInserir.Parameters.AddWithValue("CNH", registro.CNH);
            cmdInserir.Parameters.AddWithValue("EMAIL", registro.Email);
            cmdInserir.Parameters.AddWithValue("TELEFONE", registro.Telefone);
            cmdInserir.Parameters.AddWithValue("TIPO_CLIENTE", registro.PessoaFisica);
            cmdInserir.Parameters.AddWithValue("CPF", registro.CPF == null ? DBNull.Value : registro.CPF);
            cmdInserir.Parameters.AddWithValue("CNPJ", registro.CNPJ == null ? DBNull.Value : registro.CNPJ);
            cmdInserir.Parameters.AddWithValue("DATA_VALIDADE_CNH", registro.DataValidadeCNH == DateTime.MinValue ? DBNull.Value : registro.DataValidadeCNH);
        }

        public Cliente ConverterParaRegistro(SqlDataReader leitorRegistro)
        {
            Guid GuidCliente = Guid.Parse(leitorRegistro["GUID_CLIENTE"].ToString());
            string nome = Convert.ToString(leitorRegistro["NOME_CLIENTE"])!;
            string endereco = Convert.ToString(leitorRegistro["ENDERECO_CLIENTE"])!;
            string cnh = Convert.ToString(leitorRegistro["CNH_CLIENTE"])!;
            string email = Convert.ToString(leitorRegistro["EMAIL_CLIENTE"])!;
            string telefone = Convert.ToString(leitorRegistro["TELEFONE_CLIENTE"])!;
            bool pessoaFisica = Convert.ToBoolean(leitorRegistro["TIPO_CLIENTE_CLIENTE"]);

            string cpf = null!;
            string cnpj = null!;
            DateTime data = DateTime.MinValue;

            if (!DBNull.Value.Equals(leitorRegistro["DATA_VALIDADE_CNH_CLIENTE"]))
                data = Convert.ToDateTime(leitorRegistro["DATA_VALIDADE_CNH_CLIENTE"])!;

            if (!DBNull.Value.Equals(leitorRegistro["CPF_CLIENTE"]))
                cpf = Convert.ToString(leitorRegistro["CPF_CLIENTE"])!;
            else
                cnpj = Convert.ToString(leitorRegistro["CNPJ_CLIENTE"])!;

            var cliente = new Cliente();
            cliente.guid = GuidCliente;
            cliente.Nome = nome;
            cliente.Endereco = endereco;
            cliente.CNH = cnh;
            cliente.Email = email;
            cliente.Telefone = telefone;
            cliente.PessoaFisica = pessoaFisica;
            cliente.CPF = cpf!;
            cliente.CNPJ = cnpj!;
            cliente.DataValidadeCNH = data;

            return cliente;
        }
    }
}
