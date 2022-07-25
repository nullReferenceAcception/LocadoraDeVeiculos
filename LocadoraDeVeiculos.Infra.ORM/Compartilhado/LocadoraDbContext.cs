﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Infra.ORM.ModuloTaxa;
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