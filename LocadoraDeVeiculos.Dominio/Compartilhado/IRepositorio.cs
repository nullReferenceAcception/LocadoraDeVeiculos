using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio
{
    public interface IRepositorio<T> where T : EntidadeBase<T>
    {
        void Inserir(T novoRegistro);
        void Editar(T registro);
        string Excluir(T registro);
        List<T> SelecionarTodos();
        T SelecionarPorID(int numero);
        public bool VerificarDuplicidade(string sql);
        string SqlDuplicidade(T registro) { throw new NotImplementedException(); }
    }
}
