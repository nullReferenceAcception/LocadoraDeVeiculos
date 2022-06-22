using LocadoraDeVeiculosDeVeiculosDeVeiculos.Dominio;
using System.Data.SqlClient;

namespace ControleMedicamentos.Infra.BancoDados.Compartilhado
{
    public interface IMapeavel<T> where T : EntidadeBase<T>
    {
        abstract T ConverterParaRegistro(SqlDataReader leitorRegistro);

        abstract void ConfigurarParametrosRegistro(T registro, SqlCommand cmdInserir);

    }
}
