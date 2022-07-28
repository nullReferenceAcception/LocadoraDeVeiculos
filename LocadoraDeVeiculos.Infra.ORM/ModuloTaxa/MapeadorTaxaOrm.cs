using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloTaxa
{
    public class MapeadorTaxaOrm : IEntityTypeConfiguration<Taxa>
    {
        public void Configure(EntityTypeBuilder<Taxa> taxa)
        {
            taxa.ToTable("tb_taxa");
            taxa.Property(x => x.Id).ValueGeneratedNever();
            taxa.Property(x => x.Descricao).HasColumnType("varchar(200)").IsRequired();
            taxa.Property(x => x.Valor).HasColumnType("decimal").IsRequired();
            taxa.Property(x => x.EhDiaria).IsRequired();
            taxa.Property(x => x.EhAdicional).IsRequired();
            taxa.HasMany(x => x.Locacoes).WithMany(x => x.Taxas);
            taxa.HasMany(x => x.Devolucoes).WithMany(x => x.TaxasAdicionais);
        }
    }
}