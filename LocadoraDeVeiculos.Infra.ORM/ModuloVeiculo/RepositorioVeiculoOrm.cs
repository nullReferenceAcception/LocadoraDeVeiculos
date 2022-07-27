using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloVeiculo
{
    public class RepositorioLocacaoOrm : RepositorioBase<Veiculo>, IRepositorioVeiculo
    {
        public RepositorioLocacaoOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
        }

        public bool VerificarDuplicidade(Veiculo registro)
        {
            var x = registros.Where(x => x.Placa == registro.Placa && x.Id != registro.Id);

            if (x.Any())
                return true;

            return false;
        }
    }
}
