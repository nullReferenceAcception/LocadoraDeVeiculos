using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloLocacao
{
    public class MapeadorLocacaoOrm : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> locacao)
        {
            locacao.ToTable("tb_locacao");
            locacao.Property(x => x.Id).ValueGeneratedNever();

            locacao.Property(x => x.ClienteId).HasColumnType("uniqueidentifier").IsRequired();
            locacao.HasOne(x => x.Cliente).WithMany().HasForeignKey(x => x.ClienteId).OnDelete(DeleteBehavior.NoAction);

            locacao.Property(x => x.FuncionarioId).HasColumnType("uniqueidentifier").IsRequired();
            locacao.HasOne(x => x.Funcionario).WithMany().HasForeignKey(x => x.FuncionarioId).OnDelete(DeleteBehavior.NoAction);

            locacao.Property(x => x.CondutorId).HasColumnType("uniqueidentifier").IsRequired();
            locacao.HasOne(x => x.Condutor).WithMany().HasForeignKey(x => x.CondutorId).OnDelete(DeleteBehavior.NoAction);

            locacao.Property(x => x.VeiculoId).HasColumnType("uniqueidentifier").IsRequired();
            locacao.HasOne(x => x.Veiculo).WithMany().HasForeignKey(x => x.VeiculoId).OnDelete(DeleteBehavior.NoAction);

            locacao.Property(x => x.PlanoCobrancaId).HasColumnType("uniqueidentifier").IsRequired();
            locacao.HasOne(x => x.PlanoCobranca).WithMany().HasForeignKey(x => x.PlanoCobrancaId).OnDelete(DeleteBehavior.NoAction);

            locacao.HasMany(x => x.Taxas).WithMany(x => x.Locacoes);

            locacao.Property(x => x.Status).HasConversion<string>().IsRequired();

            locacao.Property(x => x.DataLocacao).HasColumnType("date").IsRequired();

            locacao.Property(x => x.DataDevolucaoPrevista).HasColumnType("date").IsRequired();

            locacao.Property(x => x.ValorTotalPrevisto).HasColumnType("decimal(11,2").IsRequired();
        }
    }
}
