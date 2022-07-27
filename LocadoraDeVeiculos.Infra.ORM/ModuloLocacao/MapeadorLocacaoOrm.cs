using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloLocacao
{
    public class MapeadorLocacaoOrm : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("tb_locacao");
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.ClienteId).HasColumnType("uniqueidentifier").IsRequired();
            builder.HasOne(x => x.Cliente).WithMany().HasForeignKey(x => x.ClienteId).OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.FuncionarioId).HasColumnType("uniqueidentifier").IsRequired();
            builder.HasOne(x => x.Funcionario).WithMany().HasForeignKey(x => x.FuncionarioId).OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.CondutorId).HasColumnType("uniqueidentifier").IsRequired();
            builder.HasOne(x => x.Condutor).WithMany().HasForeignKey(x => x.CondutorId).OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.VeiculoId).HasColumnType("uniqueidentifier").IsRequired();
            builder.HasOne(x => x.Veiculo).WithMany().HasForeignKey(x => x.VeiculoId).OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.PlanoCobrancaId).HasColumnType("uniqueidentifier").IsRequired();
            builder.HasOne(x => x.PlanoCobranca).WithMany().HasForeignKey(x => x.PlanoCobrancaId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Taxas).WithOne().HasForeignKey(x => x.Id).OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.DataLocacao).HasColumnType("date").IsRequired();
            builder.Property(x => x.DataDevolucaoPrevista).HasColumnType("date").IsRequired();
            builder.Property(x => x.EstaAtivo);
        }
    }
}
