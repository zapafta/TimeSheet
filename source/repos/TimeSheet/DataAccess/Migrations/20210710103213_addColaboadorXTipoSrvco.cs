using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class addColaboadorXTipoSrvco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Evento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ColaboradorXTipoServico",
                columns: table => new
                {
                    IdColaborador = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdTipoServico = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradorXTipoServico", x => new { x.IdColaborador, x.IdTipoServico });
                    table.ForeignKey(
                        name: "FK_ColaboradorXTipoServico_Colaborador_IdColaborador",
                        column: x => x.IdColaborador,
                        principalTable: "Colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ColaboradorXTipoServico_TipoServico_IdTipoServico",
                        column: x => x.IdTipoServico,
                        principalTable: "TipoServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorXTipoServico_IdTipoServico",
                table: "ColaboradorXTipoServico",
                column: "IdTipoServico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColaboradorXTipoServico");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Evento");
        }
    }
}
