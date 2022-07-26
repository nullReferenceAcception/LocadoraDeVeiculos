using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloTaxa
{
    public class RepositorioTaxaOrm : RepositorioBase<Taxa>, IRepositorioTaxa
    {
        public RepositorioTaxaOrm(LocadoraDbContext dbContext) : base(dbContext)
        {

        }

        public bool VerificarDuplicidade(Taxa registro)
        {
          var x =  registros.Where(x => x.Descricao == registro.Descricao && x.Id != registro.Id);

            if (x.Any())
                return true;


            return false;

        }


    }
}
