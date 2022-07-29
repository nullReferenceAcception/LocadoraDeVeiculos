using Locadora.Infra.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.Compartilhado
{
    public static class MigradorBancoDadosLocadora
    {
        public static void AtualizarBancoDados()
        {
            var config = new ConfiguracaoAplicacaoLocadora();
            var db = new LocadoraDbContext(config.ConnectionStrings);
            
            var migracoesPendentes = db.Database.GetPendingMigrations();

            if (migracoesPendentes.Any())
                db.Database.Migrate();
        }
    }
}
