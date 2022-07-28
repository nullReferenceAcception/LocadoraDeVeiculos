using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.ORM.Migrations
{
    public partial class MudadoTaxaMpaeador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_taxa_tb_devolucao_Id",
                table: "tb_taxa");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_taxa_tb_locacao_Id",
                table: "tb_taxa");

            migrationBuilder.CreateTable(
                name: "DevolucaoTaxa",
                columns: table => new
                {
                    DevolucoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxasAdicionaisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevolucaoTaxa", x => new { x.DevolucoesId, x.TaxasAdicionaisId });
                    table.ForeignKey(
                        name: "FK_DevolucaoTaxa_tb_devolucao_DevolucoesId",
                        column: x => x.DevolucoesId,
                        principalTable: "tb_devolucao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DevolucaoTaxa_tb_taxa_TaxasAdicionaisId",
                        column: x => x.TaxasAdicionaisId,
                        principalTable: "tb_taxa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocacaoTaxa",
                columns: table => new
                {
                    LocacoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocacaoTaxa", x => new { x.LocacoesId, x.TaxasId });
                    table.ForeignKey(
                        name: "FK_LocacaoTaxa_tb_locacao_LocacoesId",
                        column: x => x.LocacoesId,
                        principalTable: "tb_locacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocacaoTaxa_tb_taxa_TaxasId",
                        column: x => x.TaxasId,
                        principalTable: "tb_taxa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevolucaoTaxa_TaxasAdicionaisId",
                table: "DevolucaoTaxa",
                column: "TaxasAdicionaisId");

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoTaxa_TaxasId",
                table: "LocacaoTaxa",
                column: "TaxasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevolucaoTaxa");

            migrationBuilder.DropTable(
                name: "LocacaoTaxa");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_taxa_tb_devolucao_Id",
                table: "tb_taxa",
                column: "Id",
                principalTable: "tb_devolucao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_taxa_tb_locacao_Id",
                table: "tb_taxa",
                column: "Id",
                principalTable: "tb_locacao",
                principalColumn: "Id");
        }
    }
}
