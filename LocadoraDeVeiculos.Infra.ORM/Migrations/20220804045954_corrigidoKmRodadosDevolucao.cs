using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.ORM.Migrations
{
    public partial class corrigidoKmRodadosDevolucao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "kMRodados",
                table: "tb_devolucao",
                newName: "KmRodados");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KmRodados",
                table: "tb_devolucao",
                newName: "kMRodados");
        }
    }
}
