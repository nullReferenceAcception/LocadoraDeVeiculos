using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloTaxa
{
    public class RepositorioTaxaOrm : RepositorioBase<Taxa>, IRepositorioTaxa
    {
        public RepositorioTaxaOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
        }

        public List<Taxa> SelecionarTodosAdicionais()
        {
            return registros.Where(x => x.EhAdicional).ToList();
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
