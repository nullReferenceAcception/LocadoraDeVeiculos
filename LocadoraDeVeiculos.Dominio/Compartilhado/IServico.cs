using FluentResults;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public interface IServico<T> where T : EntidadeBase<T>
    {
        Result<T> Inserir(T novoRegistro);
        Result<T> Editar(T registro);
        Result Excluir(T registro);
        Result<List<T>> SelecionarTodos();
        Result<T> SelecionarPorGuid(Guid numero);
        Result<int> QuantidadeRegistro();
    }
}