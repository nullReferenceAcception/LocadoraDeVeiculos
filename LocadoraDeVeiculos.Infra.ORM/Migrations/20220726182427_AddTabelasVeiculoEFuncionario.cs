using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.ORM.Migrations
{
    public partial class AddTabelasVeiculoEFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_funcionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "date", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    EhAdmin = table.Column<bool>(type: "bit", nullable: false),
                    EstaAtivo = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Email = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Telefone = table.Column<string>(type: "char(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_veiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Placa = table.Column<string>(type: "char(7)", nullable: false),
                    Marca = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    CapacidadeTanque = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    KmPercorrido = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Combustivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrupoVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_veiculo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_funcionario");

            migrationBuilder.DropTable(
                name: "tb_veiculo");
        }
    }
}
