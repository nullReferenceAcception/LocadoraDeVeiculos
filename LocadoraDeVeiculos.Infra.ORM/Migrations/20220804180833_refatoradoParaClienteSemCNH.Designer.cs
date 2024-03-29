﻿// <auto-generated />
using System;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocadoraDeVeiculos.Infra.ORM.Migrations
{
    [DbContext(typeof(LocadoraDbContext))]
    [Migration("20220804180833_refatoradoParaClienteSemCNH")]
    partial class refatoradoParaClienteSemCNH
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevolucaoTaxa", b =>
                {
                    b.Property<Guid>("DevolucoesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TaxasAdicionaisId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DevolucoesId", "TaxasAdicionaisId");

                    b.HasIndex("TaxasAdicionaisId");

                    b.ToTable("DevolucaoTaxa");
                });

            modelBuilder.Entity("LocacaoTaxa", b =>
                {
                    b.Property<Guid>("LocacoesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TaxasId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LocacoesId", "TaxasId");

                    b.HasIndex("TaxasId");

                    b.ToTable("LocacaoTaxa");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloCliente.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .HasColumnType("char(14)");

                    b.Property<string>("CPF")
                        .HasColumnType("char(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<bool>("PessoaFisica")
                        .HasColumnType("bit");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("char(11)");

                    b.HasKey("Id");

                    b.ToTable("tb_cliente");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloCondutor.Condutor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNH")
                        .IsRequired()
                        .HasColumnType("char(11)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("char(11)");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataValidadeCNH")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("char(11)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("tb_condutor");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloDevolucao.Devolucao", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDevolucaoReal")
                        .HasColumnType("date");

                    b.Property<decimal>("KmRodados")
                        .HasColumnType("decimal(11,2)");

                    b.Property<Guid>("LocacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tanque")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorTotalReal")
                        .HasColumnType("decimal(11,2)");

                    b.HasKey("Id");

                    b.HasIndex("LocacaoId");

                    b.ToTable("tb_devolucao");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloFuncionario.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("date");

                    b.Property<bool>("EhAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<bool>("EstaAtivo")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(11,2)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("char(11)");

                    b.HasKey("Id");

                    b.ToTable("tb_funcionario");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos.GrupoVeiculos", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("tb_grupo_veiculo");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CondutorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDevolucaoPrevista")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("date");

                    b.Property<Guid>("FuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlanoCobrancaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorTotalPrevisto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("VeiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("CondutorId");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("PlanoCobrancaId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("tb_locacao");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca.PlanoCobranca", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GrupoVeiculosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("KmLivreIncluso")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Plano")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<decimal>("ValorDia")
                        .HasColumnType("decimal");

                    b.Property<decimal>("ValorPorKm")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("GrupoVeiculosId");

                    b.ToTable("tb_plano_cobranca");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloTaxa.Taxa", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("EhAdicional")
                        .HasColumnType("bit");

                    b.Property<bool>("EhDiaria")
                        .HasColumnType("bit");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.ToTable("tb_taxa");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloVeiculo.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<decimal>("CapacidadeTanque")
                        .HasColumnType("decimal(11,2)");

                    b.Property<string>("Combustivel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Foto")
                        .IsRequired()
                        .HasColumnType("varbinary(MAX)");

                    b.Property<Guid>("GrupoVeiculosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("KmPercorrido")
                        .HasColumnType("decimal(11,2)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("char(7)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoVeiculosId");

                    b.ToTable("tb_veiculo");
                });

            modelBuilder.Entity("DevolucaoTaxa", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloDevolucao.Devolucao", null)
                        .WithMany()
                        .HasForeignKey("DevolucoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloTaxa.Taxa", null)
                        .WithMany()
                        .HasForeignKey("TaxasAdicionaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LocacaoTaxa", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloLocacao.Locacao", null)
                        .WithMany()
                        .HasForeignKey("LocacoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloTaxa.Taxa", null)
                        .WithMany()
                        .HasForeignKey("TaxasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloCondutor.Condutor", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloCliente.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloDevolucao.Devolucao", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloLocacao.Locacao", "Locacao")
                        .WithMany()
                        .HasForeignKey("LocacaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Locacao");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloCliente.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloCondutor.Condutor", "Condutor")
                        .WithMany()
                        .HasForeignKey("CondutorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloFuncionario.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca.PlanoCobranca", "PlanoCobranca")
                        .WithMany()
                        .HasForeignKey("PlanoCobrancaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloVeiculo.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Condutor");

                    b.Navigation("Funcionario");

                    b.Navigation("PlanoCobranca");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca.PlanoCobranca", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos.GrupoVeiculos", "GrupoVeiculos")
                        .WithMany()
                        .HasForeignKey("GrupoVeiculosId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("GrupoVeiculos");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloVeiculo.Veiculo", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos.GrupoVeiculos", "GrupoVeiculos")
                        .WithMany()
                        .HasForeignKey("GrupoVeiculosId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GrupoVeiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
