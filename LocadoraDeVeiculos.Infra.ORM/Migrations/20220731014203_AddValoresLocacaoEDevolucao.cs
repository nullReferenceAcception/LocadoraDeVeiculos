using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.ORM.Migrations
{
    public partial class AddValoresLocacaoEDevolucao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotalPrevisto",
                table: "tb_locacao",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotalReal",
                table: "tb_devolucao",
                type: "decimal(11,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTotalPrevisto",
                table: "tb_locacao");

            migrationBuilder.DropColumn(
                name: "ValorTotalReal",
                table: "tb_devolucao");
        }
    }
}
