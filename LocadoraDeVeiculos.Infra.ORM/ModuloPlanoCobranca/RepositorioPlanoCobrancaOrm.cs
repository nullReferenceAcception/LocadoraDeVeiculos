using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobrancaOrm : RepositorioBase<PlanoCobranca>, IRepositorioPlanoCobranca
    {
        public RepositorioPlanoCobrancaOrm(IContextoPersistencia dbContext) : base(dbContext)
        {
        }


        public bool VerificarDuplicidade(PlanoCobranca registro)
        {
            var x = registros.Where(x => x.Nome == registro.Nome && x.Id != registro.Id);

            if (x.Any())
                return true;

            return false;
        }

        public override List<PlanoCobranca> SelecionarTodos()
        {
            return registros.Include(x => x.GrupoVeiculos).ToList();
        }

        public bool VerificarDuplicidadePlano(PlanoCobranca registro)
        {
            var x = registros.Where(x =>x.GrupoVeiculos == registro.GrupoVeiculos && x.Plano == registro.Plano && x.Id != registro.Id);

            if (x.Any())
                return true;

            return false;
        }
    }
}
