using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.ORM.Migrations
{
    public partial class TabelasGrupoVeiculoEPlanoCobranca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_grupo_veiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_grupo_veiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_plano_cobranca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    KmLivreIncluso = table.Column<int>(type: "int", nullable: false),
                    ValorDia = table.Column<decimal>(type: "decimal", nullable: false),
                    ValorPorKm = table.Column<decimal>(type: "decimal", nullable: false),
                    GrupoVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Plano = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_plano_cobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_plano_cobranca_tb_grupo_veiculo_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "tb_grupo_veiculo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_plano_cobranca_GrupoVeiculosId",
                table: "tb_plano_cobranca",
                column: "GrupoVeiculosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_plano_cobranca");

            migrationBuilder.DropTable(
                name: "tb_grupo_veiculo");
        }
    }
}
