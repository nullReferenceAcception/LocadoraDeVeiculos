using LocadoraDeVeiculos.Dominio.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloCliente
{
    public class MapeadorClienteOrm : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("tb_cliente");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(MAX)").IsRequired();
            builder.Property(x => x.Endereco).HasColumnType("varchar(MAX)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(MAX)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("char(11)").IsRequired();
            builder.Property(x => x.CPF).HasColumnType("char(11)").IsRequired(false);
            builder.Property(x => x.PessoaFisica).HasColumnType("bit").IsRequired();
            builder.Property(x => x.CNPJ).HasColumnType("char(14)").IsRequired(false);


        }
    }
}
