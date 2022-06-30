using LocadoraDeVeiculos.Dominio;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.BancoDados.Compartilhado
{
    public interface IMapeavel<T> where T : EntidadeBase<T>
    {
        abstract T ConverterParaRegistro(SqlDataReader leitorRegistro);
        abstract void ConfigurarParametrosRegistro(T registro, SqlCommand cmdInserir);

    }
}
