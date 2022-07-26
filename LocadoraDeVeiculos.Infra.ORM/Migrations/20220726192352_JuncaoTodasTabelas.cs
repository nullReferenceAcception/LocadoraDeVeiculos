using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.ORM.Migrations
{
    public partial class JuncaoTodasTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_condutor_tb_cliente_ClienteId",
                table: "tb_condutor");

            migrationBuilder.CreateIndex(
                name: "IX_tb_veiculo_GrupoVeiculosId",
                table: "tb_veiculo",
                column: "GrupoVeiculosId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_condutor_tb_cliente_ClienteId",
                table: "tb_condutor",
                column: "ClienteId",
                principalTable: "tb_cliente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_veiculo_tb_grupo_veiculo_GrupoVeiculosId",
                table: "tb_veiculo",
                column: "GrupoVeiculosId",
                principalTable: "tb_grupo_veiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_condutor_tb_cliente_ClienteId",
                table: "tb_condutor");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_veiculo_tb_grupo_veiculo_GrupoVeiculosId",
                table: "tb_veiculo");

            migrationBuilder.DropIndex(
                name: "IX_tb_veiculo_GrupoVeiculosId",
                table: "tb_veiculo");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_condutor_tb_cliente_ClienteId",
                table: "tb_condutor",
                column: "ClienteId",
                principalTable: "tb_cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
