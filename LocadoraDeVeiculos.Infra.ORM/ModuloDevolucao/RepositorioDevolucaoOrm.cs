using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using System;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloDevolucao
{
    public class RepositorioDevolucaoOrm : RepositorioBase<Devolucao>, IRepositorioDevolucao
    {
        public RepositorioDevolucaoOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
        }

        public bool VerificarDuplicidade(Devolucao registro)
        {
            throw new NotImplementedException();
        }
    }
}
