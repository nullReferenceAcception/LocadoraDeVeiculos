using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoVeiculos
{
    public class MapeadorGrupoVeiculos : IMapeavel<GrupoVeiculos>
    {
        public void ConfigurarParametrosRegistro(GrupoVeiculos registro, SqlCommand cmdInserir)
        {
            cmdInserir.Parameters.AddWithValue("ID_GRUPO_VEICULO", registro.Id);
            cmdInserir.Parameters.AddWithValue("NOME", registro.Nome);
        }

        public GrupoVeiculos ConverterParaRegistro(SqlDataReader leitorRegistro)
        {
            int idregistro = Convert.ToInt32(leitorRegistro["ID_GRUPO_VEICULO"]);
            string nome = Convert.ToString(leitorRegistro["NOME_GRUPO_VEICULO"]);

            var registro = new GrupoVeiculos();
            registro.Id = idregistro;
            registro.Nome = nome;

            return registro;
        }
    }
}
