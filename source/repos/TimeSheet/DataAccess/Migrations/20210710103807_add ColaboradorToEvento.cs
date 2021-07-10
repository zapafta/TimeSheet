using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class addColaboradorToEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ColaboradorId",
                table: "Evento",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_ColaboradorId",
                table: "Evento",
                column: "ColaboradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_Colaborador_ColaboradorId",
                table: "Evento",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evento_Colaborador_ColaboradorId",
                table: "Evento");

            migrationBuilder.DropIndex(
                name: "IX_Evento_ColaboradorId",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "ColaboradorId",
                table: "Evento");
        }
    }
}
