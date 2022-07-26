using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloFuncionario
{
    public class MapeadorFuncionarioOrm : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> funcionario)
        {
            funcionario.ToTable("tb_funcionario");
            funcionario.Property(x => x.Id).ValueGeneratedNever();
            funcionario.Property(x => x.Nome).HasColumnType("varchar(MAX)").IsRequired();
            funcionario.Property(x => x.Endereco).HasColumnType("varchar(MAX)").IsRequired();
            funcionario.Property(x => x.Email).HasColumnType("varchar(MAX)").IsRequired();
            funcionario.Property(x => x.Telefone).HasColumnType("char(11)").IsRequired();
            funcionario.Property(x => x.Login).HasColumnType("varchar(MAX)").IsRequired();
            funcionario.Property(x => x.Senha).HasColumnType("varchar(MAX)").IsRequired();
            funcionario.Property(x => x.Cidade).HasColumnType("varchar(MAX)").IsRequired();
            funcionario.Property(x => x.DataAdmissao).HasColumnType("date").IsRequired();
            funcionario.Property(x => x.Salario).HasColumnType("decimal(11,2)").IsRequired();
            funcionario.Property(x => x.EhAdmin).IsRequired();
            funcionario.Property(x => x.EstaAtivo).IsRequired();
        }
    }
}
