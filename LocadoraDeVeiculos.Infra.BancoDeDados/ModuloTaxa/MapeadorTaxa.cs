﻿using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloTaxa
{
    public class MapeadorTaxa : IMapeavel<Taxa>
    {
        public void ConfigurarParametrosRegistro(Taxa registro, SqlCommand cmdInserir)
        {
            cmdInserir.Parameters.AddWithValue("ID_TAXA", registro.Id);
            cmdInserir.Parameters.AddWithValue("DESCRICAO", registro.Descricao);
            cmdInserir.Parameters.AddWithValue("VALOR", registro.Valor);
        }

        public Taxa ConverterParaRegistro(SqlDataReader leitorRegistro)
        {
            int idTaxa = Convert.ToInt32(leitorRegistro["ID_TAXA"]);
            string descricao = Convert.ToString(leitorRegistro["DESCRICAO_TAXA"])!;
            decimal valor = Convert.ToDecimal(leitorRegistro["VALOR_TAXA"]);

            var taxa = new Taxa();
            taxa.Id = idTaxa;
            taxa.Descricao = descricao;
            taxa.Valor = valor;

            return taxa;
        }
    }
}
