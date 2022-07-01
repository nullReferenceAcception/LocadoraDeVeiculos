namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public interface IRepositorioVeiculo : IRepositorio<Veiculo>
    {
        string SqlDuplicidadePlaca(Veiculo registro);
    }
}
