using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloGrupoVeiculo
{
    public class RepositorioGrupoVeiculoOrm : RepositorioBase<GrupoVeiculos>, IRepositorioGrupoVeiculos
    {
        public RepositorioGrupoVeiculoOrm(LocadoraDbContext dbContext) : base(dbContext)
        {

        }

        public bool VerificarDuplicidade(GrupoVeiculos registro)
        {
            var x = registros.Where(x => x.Nome == registro.Nome && x.Id != registro.Id);

            if (x.Any())
                return true;


            return false;

        }


    }
}
