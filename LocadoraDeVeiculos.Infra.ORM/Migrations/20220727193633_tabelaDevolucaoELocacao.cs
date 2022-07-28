using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.ORM.Migrations
{
    public partial class tabelaDevolucaoELocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_locacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoCobrancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataLocacao = table.Column<DateTime>(type: "date", nullable: false),
                    DataDevolucaoPrevista = table.Column<DateTime>(type: "date", nullable: false),
                    EstaAtivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_locacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_locacao_tb_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "tb_cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_locacao_tb_condutor_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "tb_condutor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_locacao_tb_funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "tb_funcionario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_locacao_tb_plano_cobranca_PlanoCobrancaId",
                        column: x => x.PlanoCobrancaId,
                        principalTable: "tb_plano_cobranca",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_locacao_tb_veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "tb_veiculo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_devolucao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataDevolucaoReal = table.Column<DateTime>(type: "date", nullable: false),
                    Tanque = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_devolucao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_devolucao_tb_locacao_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "tb_locacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_devolucao_LocacaoId",
                table: "tb_devolucao",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_locacao_ClienteId",
                table: "tb_locacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_locacao_CondutorId",
                table: "tb_locacao",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_locacao_FuncionarioId",
                table: "tb_locacao",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_locacao_PlanoCobrancaId",
                table: "tb_locacao",
                column: "PlanoCobrancaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_locacao_VeiculoId",
                table: "tb_locacao",
                column: "VeiculoId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_taxa_tb_devolucao_Id",
                table: "tb_taxa");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_taxa_tb_locacao_Id",
                table: "tb_taxa");

            migrationBuilder.DropTable(
                name: "tb_devolucao");

            migrationBuilder.DropTable(
                name: "tb_locacao");
        }
    }
}
