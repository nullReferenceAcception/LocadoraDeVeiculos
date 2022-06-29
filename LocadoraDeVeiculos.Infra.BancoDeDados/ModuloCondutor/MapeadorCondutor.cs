using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
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
        public void ConfigurarParametrosRegistro(Condutor registro, SqlCommand cmdInserir)
        {
            cmdInserir.Parameters.AddWithValue("ID_CLIENTE", registro.Id);
            cmdInserir.Parameters.AddWithValue("NOME", registro.Nome);
            cmdInserir.Parameters.AddWithValue("ENDERECO", registro.Endereco);
            cmdInserir.Parameters.AddWithValue("CNH", registro.CNH);
            cmdInserir.Parameters.AddWithValue("EMAIL", registro.Email);
            cmdInserir.Parameters.AddWithValue("TELEFONE", registro.Telefone);
            cmdInserir.Parameters.AddWithValue("CPF", registro.CPF);
        }

        public Condutor ConverterParaRegistro(SqlDataReader leitorRegistro)
        {
            int idCliente = Convert.ToInt32(leitorRegistro["ID_CLIENTE"]);
            string nome = Convert.ToString(leitorRegistro["NOME_CLIENTE"])!;
            string endereco = Convert.ToString(leitorRegistro["ENDERECO_CLIENTE"])!;
            string cnh = Convert.ToString(leitorRegistro["CNH_CLIENTE"])!;
            string email = Convert.ToString(leitorRegistro["EMAIL_CLIENTE"])!;
            string telefone = Convert.ToString(leitorRegistro["TELEFONE_CLIENTE"])!;
            string cpf = Convert.ToString(leitorRegistro["CPF_CLIENTE"])!;

            var condutor = new Condutor();
            condutor.Id = idCliente;
            condutor.Nome = nome;
            condutor.Endereco = endereco;
            condutor.CNH = cnh;
            condutor.Email = email;
            condutor.Telefone = telefone;
            condutor.CPF = cpf!;

            return condutor;
        }
    }
}
