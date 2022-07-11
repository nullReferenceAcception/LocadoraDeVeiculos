using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoVeiculos;
using System;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobranca : IMapeavel<PlanoCobranca>
    {
        public void ConfigurarParametrosRegistro(PlanoCobranca registro, SqlCommand cmdInserir)
        {
            cmdInserir.Parameters.AddWithValue("GUID_PLANO_COBRANCA", registro.Guid);
            cmdInserir.Parameters.AddWithValue("NOME", registro.Nome);
            cmdInserir.Parameters.AddWithValue("KM_LIVRE_INCLUSO", registro.KmLivreIncluso);
            cmdInserir.Parameters.AddWithValue("VALOR_DIA", registro.ValorDia);
            cmdInserir.Parameters.AddWithValue("VALOR_POR_KM", registro.ValorPorKm);
            cmdInserir.Parameters.AddWithValue("GRUPO_VEICULO_ID", registro.GrupoVeiculos.Guid);
            cmdInserir.Parameters.AddWithValue("PLANO", registro.Plano.ToString());
        }

        public PlanoCobranca ConverterParaRegistro(SqlDataReader leitorRegistro)
        {
            Guid idPlanoCobranca = Guid.Parse(leitorRegistro["GUID_PLANO_COBRANCA"].ToString());
            string nome = Convert.ToString(leitorRegistro["NOME_PLANO_COBRANCA"])!;
            int kmLivre = Convert.ToInt32(leitorRegistro["KM_LIVRE_INCLUSO_PLANO_COBRANCA"]);
            decimal valorDia = Convert.ToDecimal(leitorRegistro["VALOR_DIA_PLANO_COBRANCA"]);
            decimal valorPorKm = Convert.ToDecimal(leitorRegistro["VALOR_POR_KM_PLANO_COBRANCA"]);
            Enum.TryParse(leitorRegistro["PLANO_PLANO_COBRANCA"].ToString(),out PlanoEnum planoEnum);

            GrupoVeiculos grupoVeiculos = new MapeadorGrupoVeiculos().ConverterParaRegistro(leitorRegistro);

            var plano = new PlanoCobranca(nome, kmLivre, valorDia, valorPorKm, planoEnum, grupoVeiculos);
            plano.Guid = idPlanoCobranca;

            return plano;
        }
    }
}
