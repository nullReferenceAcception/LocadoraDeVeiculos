using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloCondutor
{
    public class MapeadorCondutorOrm : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.ToTable("tb_condutor");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(MAX)").IsRequired();
            builder.Property(x => x.Endereco).HasColumnType("varchar(MAX)").IsRequired();
            builder.Property(x => x.CNH).HasColumnType("char(11)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(MAX)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("char(11)").IsRequired();
            builder.Property(x => x.CPF).HasColumnType("char(11)").IsRequired();
            builder.Property(x => x.DataValidadeCNH).HasColumnType("date").IsRequired();
            builder.Property(x => x.ClienteId).HasColumnType("uniqueidentifier").IsRequired();

            builder.HasOne(x => x.Cliente).WithMany().HasForeignKey(x => x.ClienteId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
