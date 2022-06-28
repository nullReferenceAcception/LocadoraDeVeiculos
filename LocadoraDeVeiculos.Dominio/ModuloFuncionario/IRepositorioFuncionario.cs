namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public interface IRepositorioFuncionario : IRepositorio<Funcionario>
    {
        string SqlDuplicidadeNome(Funcionario registro);

        string SqlDuplicidadeLogin(Funcionario registro);
    }
}
