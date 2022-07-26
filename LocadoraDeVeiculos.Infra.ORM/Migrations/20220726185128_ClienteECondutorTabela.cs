using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.ORM.Migrations
{
    public partial class ClienteECondutorTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNH = table.Column<string>(type: "char(11)", nullable: false),
                    DataValidadeCNH = table.Column<DateTime>(type: "date", nullable: false),
                    PessoaFisica = table.Column<bool>(type: "bit", nullable: false),
                    CPF = table.Column<string>(type: "char(11)", nullable: true),
                    CNPJ = table.Column<string>(type: "char(14)", nullable: true),
                    Nome = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Email = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Telefone = table.Column<string>(type: "char(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_condutor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNH = table.Column<string>(type: "char(11)", nullable: false),
                    CPF = table.Column<string>(type: "char(11)", nullable: false),
                    DataValidadeCNH = table.Column<DateTime>(type: "date", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Email = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Telefone = table.Column<string>(type: "char(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_condutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_condutor_tb_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "tb_cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_condutor_ClienteId",
                table: "tb_condutor",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_condutor");

            migrationBuilder.DropTable(
                name: "tb_cliente");
        }
    }
}
