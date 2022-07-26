using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Infra.ORM.ModuloCliente;
using LocadoraDeVeiculos.Infra.ORM.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ORM.ModuloGrupoVeiculo;
using LocadoraDeVeiculos.Infra.ORM.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ORM.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ORM.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ORM.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LocadoraDeVeiculos.Infra.ORM.Compartilhado
{
    public class LocadoraDbContext : DbContext, IContextoPersistencia
    {
        private string enderecoConexaoComBanco;

        public LocadoraDbContext(string enderecoBanco)
        {
            enderecoConexaoComBanco = enderecoBanco;
        }

        public void GravarDados()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(enderecoConexaoComBanco);

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


            //  EXEMPLOS

            //   modelBuilder.ApplyConfiguration(new MapeadorDisciplinaOrm());

            //modelBuilder.Entity<Teste>(entidade =>
            //{
            //    entidade.ToTable("TBTeste");
            //    entidade.Property(x => x.Id).ValueGeneratedNever();
            //    entidade.Property(x => x.Titulo).IsRequired().HasColumnType("varchar(250)");
            //    entidade.Property(x => x.QuantidadeQuestoes).IsRequired();
            //    entidade.Property(x => x.DataGeracao).IsRequired();
            //    entidade.Property(x => x.Provao).IsRequired();
            //    entidade.HasMany(x => x.Questoes);

            //    entidade.HasOne(x => x.T)
            //        .WithMany().OnDelete(DeleteBehavior.NoAction);

            //    entidade.HasOne(x => x.Materia)
            //        .WithMany().OnDelete(DeleteBehavior.NoAction);
            //});
        }
    }
}
