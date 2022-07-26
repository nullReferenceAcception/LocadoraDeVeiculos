using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.ORM.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_taxa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal", nullable: false),
                    EhDiaria = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_taxa", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_taxa");
        }
    }
}
