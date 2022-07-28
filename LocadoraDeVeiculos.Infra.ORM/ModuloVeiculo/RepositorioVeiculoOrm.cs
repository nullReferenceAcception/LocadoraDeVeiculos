using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloVeiculo
{
    public class RepositorioVeiculoOrm : RepositorioBase<Veiculo>, IRepositorioVeiculo
    {
        public RepositorioVeiculoOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
        }

        public List<Veiculo> SelecionarTodosDoGrupo(GrupoVeiculos grupo)
        {
           return registros.Where(x => x.GrupoVeiculos == grupo).ToList();
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
