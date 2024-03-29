﻿using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.Compartilhado
{
    public class RepositorioBase<T> where T : EntidadeBase<T>
    {
        protected DbSet<T> registros;
        protected readonly LocadoraDbContext dbContext;

        public RepositorioBase(IContextoPersistencia contextoPersistencia)
        {
            this.dbContext = (LocadoraDbContext)contextoPersistencia;
            registros = dbContext.Set<T>();
        }

        public virtual void Inserir(T novoRegistro)
        {
            registros.Add(novoRegistro);
        }

        public virtual void Editar(T registro)
        {
            registros.Update(registro);
        }

        public virtual void Excluir(T registro)
        {
            registros.Remove(registro);
        }

        public virtual T SelecionarPorId(Guid id)
        {
            return registros.SingleOrDefault(x => x.Id == id);
        }

        public virtual List<T> SelecionarTodos()
        {
            return registros.ToList();
        }


        public virtual int QuantidadeRegistros()
        {
          return registros.Count();
        }
    }
}
