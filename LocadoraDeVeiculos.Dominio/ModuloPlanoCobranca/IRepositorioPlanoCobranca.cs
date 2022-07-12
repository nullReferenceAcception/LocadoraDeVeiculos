namespace LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca
{
    public interface IRepositorioPlanoCobranca : IRepositorio<PlanoCobranca>
    {

        string SqlDuplicidadePlano(PlanoCobranca registro);

    }
}
