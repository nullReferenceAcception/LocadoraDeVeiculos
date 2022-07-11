using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoVeiculos
{
    public class MapeadorGrupoVeiculos : IMapeavel<GrupoVeiculos>
    {
        public void ConfigurarParametrosRegistro(GrupoVeiculos registro, SqlCommand cmdInserir)
        {
            cmdInserir.Parameters.AddWithValue("GUID_GRUPO_VEICULO", registro.guid);
            cmdInserir.Parameters.AddWithValue("NOME", registro.Nome);
        }

        public GrupoVeiculos ConverterParaRegistro(SqlDataReader leitorRegistro)
        {
            Guid idregistro = Guid.Parse(leitorRegistro["GUID_GRUPO_VEICULO"].ToString());
            string nome = Convert.ToString(leitorRegistro["NOME_GRUPO_VEICULO"])!;

            var registro = new GrupoVeiculos();
            registro.guid = idregistro;
            registro.Nome = nome;

            return registro;
        }
    }
}
