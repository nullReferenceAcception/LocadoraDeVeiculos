using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloTaxa
{
    public class MapeadorTaxaOrm : IEntityTypeConfiguration<Taxa>
    {
        public void Configure(EntityTypeBuilder<Taxa> builder)
        {
            builder.ToTable("taxa_tb");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Descricao).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Valor).HasColumnType("decimal").IsRequired();
            builder.Property(x => x.Descricao).IsRequired();
        }
    }
}