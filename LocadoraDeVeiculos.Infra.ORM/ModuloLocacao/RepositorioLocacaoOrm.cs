using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloLocacao
{
    public class RepositorioLocacaoOrm : RepositorioBase<Locacao>, IRepositorioLocacao
    {
        public RepositorioLocacaoOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
        }

        public bool VerificarDuplicidade(Locacao registro)
        {
            var x = registros.Where(x => x.Veiculo == registro.Veiculo && x.EstaAtivo == true && x.Id != registro.Id);

            if (x.Any())
                return true;


            return false;
        }
    }
}
