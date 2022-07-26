using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloGrupoVeiculo
{
    public class MapeadorGrupoVeiculoOrm : IEntityTypeConfiguration<GrupoVeiculos>
    {
        public void Configure(EntityTypeBuilder<GrupoVeiculos> builder)
        {
            builder.ToTable("tb_grupo_veiculo");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(200)").IsRequired();
        }
    }
}