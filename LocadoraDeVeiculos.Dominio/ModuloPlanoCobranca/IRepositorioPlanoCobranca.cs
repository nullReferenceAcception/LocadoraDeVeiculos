namespace LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca
{
    public interface IRepositorioPlanoCobranca : IRepositorio<PlanoCobranca>
    {

        bool VerificarDuplicidadePlano(PlanoCobranca registro);

    }
}
