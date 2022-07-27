using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloDevolucao
{
    public class MapeadorDevolucaoOrm : IEntityTypeConfiguration<Devolucao>
    {
        public void Configure(EntityTypeBuilder<Devolucao> devolucao)
        {
            devolucao.ToTable("tb_devolucao");
            devolucao.Property(x => x.Id).ValueGeneratedNever();
            devolucao.Property(x => x.DataDevolucaoReal).IsRequired().HasColumnType("date");
            devolucao.Property(x => x.TaxasAdicionais); // todo
            devolucao.Property(x => x.Tanque).HasConversion<string>();
            devolucao.HasOne(x => x.Locacao).WithMany().HasForeignKey(x => x.LocacaoId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
