using FluentValidation.Results;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public interface IServico<T> where T : EntidadeBase<T>
    {
        ValidationResult Inserir(T novoRegistro);
        ValidationResult Editar(T registro);
        ValidationResult Excluir(T registro);
        List<T> SelecionarTodos();
        T SelecionarPorID(int numero);
        int QuantidadeRegistro();
    }
}