using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloVeiculo
{
    public class MapeadorVeiculoOrm : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> veiculo)
        {
            veiculo.ToTable("tb_veiculo");
            veiculo.Property(x => x.Id).ValueGeneratedNever();
            veiculo.Property(x => x.Modelo).HasColumnType("varchar(MAX)").IsRequired();
            veiculo.Property(x => x.Placa).HasColumnType("char(7)").IsRequired();
            veiculo.Property(x => x.Marca).HasColumnType("varchar(MAX)").IsRequired();
            veiculo.Property(x => x.Ano).IsRequired();
            veiculo.Property(x => x.CapacidadeTanque).HasColumnType("decimal(11,2)").IsRequired();
            veiculo.Property(x => x.KmPercorrido).HasColumnType("decimal(11,2)").IsRequired();
            veiculo.Property(x => x.Cor).HasConversion<string>();
            veiculo.Property(x => x.Combustivel).HasConversion<string>();
            veiculo.Property(x => x.GrupoVeiculosId).HasColumnType("uniqueidentifier").IsRequired();
            veiculo.Property(x => x.Foto).HasColumnType("varbinary(MAX)").IsRequired();

            veiculo.HasOne(x => x.GrupoVeiculos).WithMany().HasForeignKey(x => x.GrupoVeiculosId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
