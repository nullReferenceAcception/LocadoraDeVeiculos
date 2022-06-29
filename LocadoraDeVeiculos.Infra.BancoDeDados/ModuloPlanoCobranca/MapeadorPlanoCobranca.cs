using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobranca : IMapeavel<PlanoCobranca>
    {
        public void ConfigurarParametrosRegistro(PlanoCobranca registro, SqlCommand cmdInserir)
        {
            cmdInserir.Parameters.AddWithValue("ID_PLANO_COBRANCA", registro.Id);
            cmdInserir.Parameters.AddWithValue("NOME", registro.Nome);
            cmdInserir.Parameters.AddWithValue("KM_LIVRE_INCLUSO", registro.KmLivreIncluso);
            cmdInserir.Parameters.AddWithValue("VALOR_DIA", registro.ValorDia);
            cmdInserir.Parameters.AddWithValue("VALOR_POR_KM", registro.ValorPorKm);
            cmdInserir.Parameters.AddWithValue("GRUPO_VEICULO_ID", registro.GrupoVeiculos.Id);
        }

        public PlanoCobranca ConverterParaRegistro(SqlDataReader leitorRegistro)
        {

            int idTaxa = Convert.ToInt32(leitorRegistro["ID_PLANO_COBRANCA"]);
            string nome = Convert.ToString(leitorRegistro["NOME_PLANO_COBRANCA"])!;
            int kmLivre = Convert.ToInt32(leitorRegistro["KM_LIVRE_INCLUSO_PLANO_COBRANCA"]);
            decimal valorDia = Convert.ToDecimal(leitorRegistro["VALOR_DIA_PLANO_COBRANCA"]);
            decimal valorPorKm = Convert.ToDecimal(leitorRegistro["VALOR_POR_KM_PLANO_COBRANCA"]);


            MapeadorGrupoVeiculos mapeadorGrupoVeiculos = new();

            GrupoVeiculos grupoVeiculos = mapeadorGrupoVeiculos.ConverterParaRegistro(leitorRegistro);

            var plano = new PlanoCobranca(nome, kmLivre, valorDia, valorPorKm, grupoVeiculos);
            plano.Id = idTaxa;

            return plano;
        }
    }
}
