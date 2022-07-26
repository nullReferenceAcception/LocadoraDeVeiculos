﻿using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloCondutor
{
    public class RepositorioCondutorOrm : RepositorioBase<Condutor>, IRepositorioCondutor
    {
        public RepositorioCondutorOrm(LocadoraDbContext dbContext) : base(dbContext)
    {

    }

    public bool VerificarDuplicidade(Condutor registro)
    {
        var x = registros.Where(x => x.CPF == registro.CPF && x.Id != registro.Id);

        if (x.Any())
            return true;


        return false;

    }


}
}
