﻿using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoVeiculos;
using System;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloVeiculo
{
    public class MapeadorVeiculo : IMapeavel<Veiculo>
    {
        MapeadorGrupoVeiculos _mapeadorGrupoVeiculos;
        public void ConfigurarParametrosRegistro(Veiculo registro, SqlCommand cmdInserir)
        {
            cmdInserir.Parameters.AddWithValue("@ID", registro.Id);
            cmdInserir.Parameters.AddWithValue("@MODELO", registro.Modelo);
            cmdInserir.Parameters.AddWithValue("@PLACA", registro.Placa);
            cmdInserir.Parameters.AddWithValue("@ANO", registro.Ano);
            cmdInserir.Parameters.AddWithValue("@CAPACIDADE_TANQUE", registro.CapacidadeTanque);
            cmdInserir.Parameters.AddWithValue("@KM_PERCORRIDOS", registro.KmsPercorridos);
            cmdInserir.Parameters.AddWithValue("@COR", registro.Cor);
            cmdInserir.Parameters.AddWithValue("@COMBUSTIVEL", registro.Combustivel);
            cmdInserir.Parameters.AddWithValue("@GRUPO_DE_VEICULO_ID", registro.GrupoVeiculos.Id);
            cmdInserir.Parameters.AddWithValue("@FOTO", registro.Foto);
        }

        public Veiculo ConverterParaRegistro(SqlDataReader leitorRegistro)
        {
            int id = Convert.ToInt32(leitorRegistro["@ID"]);
            string modelo = leitorRegistro["@MODELO"].ToString();
            string placa = leitorRegistro["@PLACA"].ToString();
            int ano = Convert.ToInt32(leitorRegistro["@ANO"]);
            decimal capacidadeTanque = Convert.ToDecimal(leitorRegistro["@CAPACIDADE_TANQUE"]);
            decimal kmPercorridos = Convert.ToDecimal(leitorRegistro["@KM_PERCORRIDOS"]);
            CorEnum cor = (CorEnum)leitorRegistro["@COR"];
            CombustivelEnum combustivel = (CombustivelEnum)leitorRegistro["@COMBUSTIVEL"];
            byte[] foto = (byte[])leitorRegistro["@FOTO"];

            GrupoVeiculos grupo = _mapeadorGrupoVeiculos.ConverterParaRegistro(leitorRegistro);

            Veiculo veiculo = new();

            veiculo.Id = id;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            veiculo.Ano = ano;
            veiculo.CapacidadeTanque = capacidadeTanque;
            veiculo.KmsPercorridos = kmPercorridos;
            veiculo.Cor = cor;
            veiculo.Combustivel = combustivel;
            veiculo.Foto = foto;
            veiculo.GrupoVeiculos = grupo;

            return veiculo;
        }
    }
}
