using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloVeiculo
{
    public class RepositorioVeiculoOrm : RepositorioBase<Veiculo>, IRepositorioVeiculo
    {
        public RepositorioVeiculoOrm(LocadoraDbContext dbContext) : base(dbContext)
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
