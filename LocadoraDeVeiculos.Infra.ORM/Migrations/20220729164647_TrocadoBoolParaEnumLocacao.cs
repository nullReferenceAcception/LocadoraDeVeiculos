using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.ORM.Migrations
{
    public partial class TrocadoBoolParaEnumLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaAtivo",
                table: "tb_locacao");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "tb_locacao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "tb_locacao");

            migrationBuilder.AddColumn<bool>(
                name: "EstaAtivo",
                table: "tb_locacao",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
