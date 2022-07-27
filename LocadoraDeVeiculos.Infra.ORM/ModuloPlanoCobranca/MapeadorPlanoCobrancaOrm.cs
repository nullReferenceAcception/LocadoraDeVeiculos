using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobrancaOrm : IEntityTypeConfiguration<PlanoCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoCobranca> builder)
        {
            builder.ToTable("tb_plano_cobranca");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.ValorDia).HasColumnType("decimal").IsRequired();
            builder.Property(x => x.ValorPorKm).HasColumnType("decimal").IsRequired();
            builder.Property(x => x.KmLivreIncluso).IsRequired();
            builder.Property(x => x.GrupoVeiculosId).HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.Plano).HasColumnType("varchar(25)").IsRequired();

            builder.HasOne(x => x.GrupoVeiculos).WithMany().HasForeignKey(x => x.GrupoVeiculosId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}