using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class fixEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evento_Cliente_IdCliente",
                table: "Evento");

            migrationBuilder.DropForeignKey(
                name: "FK_Evento_TipoServico_IdTipoServico",
                table: "Evento");

            migrationBuilder.DropIndex(
                name: "IX_Evento_IdCliente",
                table: "Evento");

            migrationBuilder.DropIndex(
                name: "IX_Evento_IdTipoServico",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "IdTipoServico",
                table: "Evento");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Evento",
                newName: "EventType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventType",
                table: "Evento",
                newName: "Rating");

            migrationBuilder.AddColumn<Guid>(
                name: "IdCliente",
                table: "Evento",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "IdTipoServico",
                table: "Evento",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_IdCliente",
                table: "Evento",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_IdTipoServico",
                table: "Evento",
                column: "IdTipoServico");

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_Cliente_IdCliente",
                table: "Evento",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_TipoServico_IdTipoServico",
                table: "Evento",
                column: "IdTipoServico",
                principalTable: "TipoServico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
