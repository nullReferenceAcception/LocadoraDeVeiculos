using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio
{
    public interface IRepositorio<T> where T : EntidadeBase<T>
    {
        void Inserir(T novoRegistro);
        void Editar(T registro);
        void Excluir(T registro);
        List<T> SelecionarTodos();
        T SelecionarPorGuid(Guid numero);
        public bool VerificarDuplicidade(string sql);
        string SqlDuplicidade(T registro);
        int QuantidadeRegistros();
    }
}
