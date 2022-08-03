using Locadora.Infra.Configs;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Infra.ORM.ModuloCliente;
using LocadoraDeVeiculos.Infra.ORM.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ORM.ModuloGrupoVeiculo;
using LocadoraDeVeiculos.Infra.ORM.ModuloLocacao;
using LocadoraDeVeiculos.Infra.ORM.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.ORM.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.Compartilhado
{
    public class LocadoraDbContext : DbContext, IContextoPersistencia
    {
        private string connectionString;

        public LocadoraDbContext(ConnectionStrings connectionStrings)
        {
            this.connectionString = connectionStrings.SqlServer;
        }
        public void DesfazerAlteracoes()
        {
            var contexto = this;
            var changedEntries = contexto.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    default:
                        break;
                }
            }
        }

        public void GravarDados()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);

            ILoggerFactory loggerFactory = LoggerFactory.Create((x) =>
            {
                x.AddSerilog(Log.Logger);
            });

            optionsBuilder.UseLoggerFactory(loggerFactory);

            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dllComConfiguracoesOrm = typeof(LocadoraDbContext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(dllComConfiguracoesOrm);

            modelBuilder.ApplyConfiguration(new MapeadorTaxaOrm());

            modelBuilder.ApplyConfiguration(new MapeadorClienteOrm());

            modelBuilder.ApplyConfiguration(new MapeadorCondutorOrm());

            modelBuilder.ApplyConfiguration(new MapeadorPlanoCobrancaOrm());

            modelBuilder.ApplyConfiguration(new MapeadorGrupoVeiculoOrm());

            modelBuilder.ApplyConfiguration(new MapeadorLocacaoOrm());
        }
    }
}
