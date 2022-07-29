
using Locadora.Infra.Configs;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LocadoraDeVeiculos.Infra.ORM.Compartilhado
{
    public class LocadoraDbContextFactory : IDesignTimeDbContextFactory<LocadoraDbContext>
    {
        public LocadoraDbContext CreateDbContext(string[] args)
        {
            var config = new ConfiguracaoAplicacaoLocadora();
            return new LocadoraDbContext(config.ConnectionStrings);
        }



    }
}
