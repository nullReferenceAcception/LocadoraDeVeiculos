using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoVeiculos;
using System;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloVeiculo
{
    public class MapeadorVeiculo : IMapeavel<Veiculo>
    {
        public void ConfigurarParametrosRegistro(Veiculo registro, SqlCommand cmdInserir)
        {
            cmdInserir.Parameters.AddWithValue("@GUID_VEICULO", registro.Guid);
            cmdInserir.Parameters.AddWithValue("@MODELO", registro.Modelo);
            cmdInserir.Parameters.AddWithValue("@MARCA", registro.Marca);
            cmdInserir.Parameters.AddWithValue("@PLACA", registro.Placa);
            cmdInserir.Parameters.AddWithValue("@ANO", registro.Ano);
            cmdInserir.Parameters.AddWithValue("@CAPACIDADE_TANQUE", registro.CapacidadeTanque);
            cmdInserir.Parameters.AddWithValue("@KM_PERCORRIDO", registro.KmPercorrido);
            cmdInserir.Parameters.AddWithValue("@COR", registro.Cor);
            cmdInserir.Parameters.AddWithValue("@COMBUSTIVEL", registro.Combustivel);
            cmdInserir.Parameters.AddWithValue("@GRUPO_DE_VEICULO_GUID", registro.GrupoVeiculos.Guid);
            cmdInserir.Parameters.AddWithValue("@FOTO", registro.Foto);
        }

        public Veiculo ConverterParaRegistro(SqlDataReader leitorRegistro)
        {
            Guid guid = Guid.Parse(leitorRegistro["GUID_VEICULO"].ToString());
            string modelo = leitorRegistro["MODELO"].ToString();
            string placa = leitorRegistro["PLACA"].ToString();
            string marca = leitorRegistro["MARCA"].ToString();
            int ano = Convert.ToInt32(leitorRegistro["ANO"]);
            decimal capacidadeTanque = Convert.ToDecimal(leitorRegistro["CAPACIDADE_TANQUE"]);
            decimal kmPercorrido = Convert.ToDecimal(leitorRegistro["KM_PERCORRIDO"]);
            CorEnum cor = (CorEnum)Enum.Parse(typeof(CorEnum), leitorRegistro["COR"].ToString());
            CombustivelEnum combustivel = (CombustivelEnum)Enum.Parse(typeof(CombustivelEnum), leitorRegistro["COMBUSTIVEL"].ToString());
            byte[] foto = (byte[])leitorRegistro["FOTO"];

            GrupoVeiculos grupo = new MapeadorGrupoVeiculos().ConverterParaRegistro(leitorRegistro);

            Veiculo veiculo = new();

            veiculo.Guid = guid;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            veiculo.Marca = marca;
            veiculo.Ano = ano;
            veiculo.CapacidadeTanque = capacidadeTanque;
            veiculo.KmPercorrido = kmPercorrido;
            veiculo.Cor = cor;
            veiculo.Combustivel = combustivel;
            veiculo.Foto = foto;
            veiculo.GrupoVeiculos = grupo;

            return veiculo;
        }
    }
}
