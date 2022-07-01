using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public interface IRepositorioFuncionario : IRepositorio<Funcionario>
    {
        abstract List<Funcionario> SelecionarDesativados();
    }
}
