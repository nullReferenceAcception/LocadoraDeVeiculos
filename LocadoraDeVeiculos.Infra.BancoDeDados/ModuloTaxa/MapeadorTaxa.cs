using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloTaxa
{
    public class MapeadorTaxa : IMapeavel<Taxa>
    {
        public void ConfigurarParametrosRegistro(Taxa registro, SqlCommand cmdInserir)
        {
            cmdInserir.Parameters.AddWithValue("GUID_TAXA", registro.Id);
            cmdInserir.Parameters.AddWithValue("DESCRICAO", registro.Descricao);
            cmdInserir.Parameters.AddWithValue("VALOR", registro.Valor);
            cmdInserir.Parameters.AddWithValue("EH_DIARIA", registro.EhDiaria);
        }

        public Taxa ConverterParaRegistro(SqlDataReader leitorRegistro)
        {
            Guid idTaxa = Guid.Parse(leitorRegistro["GUID_TAXA"].ToString());
            string descricao = Convert.ToString(leitorRegistro["DESCRICAO_TAXA"])!;
            decimal valor = Convert.ToDecimal(leitorRegistro["VALOR_TAXA"]);
            bool ehDiaria = Convert.ToBoolean(leitorRegistro["EH_DIARIA_TAXA"]);

            var taxa = new Taxa();
            taxa.Id = idTaxa;
            taxa.Descricao = descricao;
            taxa.Valor = valor;
            taxa.EhDiaria = ehDiaria;

            return taxa;
        }
    }
}
