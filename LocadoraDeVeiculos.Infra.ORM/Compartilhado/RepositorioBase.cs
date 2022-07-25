using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.Compartilhado
{
    public class RepositorioBase<T> where T : EntidadeBase<T>
    {
        protected DbSet<T> registros;
        protected readonly LocadoraDbContext dbContext;

        public RepositorioBase(LocadoraDbContext dbContext)
        {
            registros = dbContext.Set<T>();
            this.dbContext = dbContext;
        }

        public void Inserir(T novoRegistro)
        {
            registros.Add(novoRegistro);
        }

        public void Editar(T registro)
        {
            registros.Update(registro);
        }

        public void Excluir(T registro)
        {
            registros.Remove(registro);
        }

        public T SelecionarPorId(Guid id)
        {
            return registros.SingleOrDefault(x => x.Id == id);
        }

        public List<T> SelecionarTodos()
        {
            return registros.ToList();
        }


        public int QuantidadeRegistros()
        {
          return registros.Count();
        }


    }
}
