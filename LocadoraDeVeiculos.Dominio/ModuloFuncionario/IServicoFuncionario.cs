using LocadoraDeVeiculos.Dominio.Compartilhado;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public interface IServicoFuncionario : IServico<Funcionario>
    {
        List<Funcionario> SelecionarDesativados();
    }
}
