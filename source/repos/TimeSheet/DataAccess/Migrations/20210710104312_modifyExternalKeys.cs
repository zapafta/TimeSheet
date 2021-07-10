using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class modifyExternalKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evento_Cliente_ClienteId",
                table: "Evento");

            migrationBuilder.DropForeignKey(
                name: "FK_Evento_Colaborador_ColaboradorId",
                table: "Evento");

            migrationBuilder.DropForeignKey(
                name: "FK_Evento_Localizacao_LocalizacaoId",
                table: "Evento");

            migrationBuilder.DropForeignKey(
                name: "FK_Evento_TipoServico_TipoServicoId",
                table: "Evento");

            migrationBuilder.DropIndex(
                name: "IX_Evento_ClienteId",
                table: "Evento");

            migrationBuilder.DropIndex(
                name: "IX_Evento_ColaboradorId",
                table: "Evento");

            migrationBuilder.DropIndex(
                name: "IX_Evento_LocalizacaoId",
                table: "Evento");

            migrationBuilder.DropIndex(
                name: "IX_Evento_TipoServicoId",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "ColaboradorId",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "LocalizacaoId",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "TipoServicoId",
                table: "Evento");

            migrationBuilder.AddColumn<Guid>(
                name: "IdCliente",
                table: "Evento",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "IdColaborador",
                table: "Evento",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "IdLocalizacao",
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
                name: "IX_Evento_IdColaborador",
                table: "Evento",
                column: "IdColaborador");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_IdLocalizacao",
                table: "Evento",
                column: "IdLocalizacao");

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
                name: "FK_Evento_Colaborador_IdColaborador",
                table: "Evento",
                column: "IdColaborador",
                principalTable: "Colaborador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_Localizacao_IdLocalizacao",
                table: "Evento",
                column: "IdLocalizacao",
                principalTable: "Localizacao",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evento_Cliente_IdCliente",
                table: "Evento");

            migrationBuilder.DropForeignKey(
                name: "FK_Evento_Colaborador_IdColaborador",
                table: "Evento");

            migrationBuilder.DropForeignKey(
                name: "FK_Evento_Localizacao_IdLocalizacao",
                table: "Evento");

            migrationBuilder.DropForeignKey(
                name: "FK_Evento_TipoServico_IdTipoServico",
                table: "Evento");

            migrationBuilder.DropIndex(
                name: "IX_Evento_IdCliente",
                table: "Evento");

            migrationBuilder.DropIndex(
                name: "IX_Evento_IdColaborador",
                table: "Evento");

            migrationBuilder.DropIndex(
                name: "IX_Evento_IdLocalizacao",
                table: "Evento");

            migrationBuilder.DropIndex(
                name: "IX_Evento_IdTipoServico",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "IdColaborador",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "IdLocalizacao",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "IdTipoServico",
                table: "Evento");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "Evento",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ColaboradorId",
                table: "Evento",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "LocalizacaoId",
                table: "Evento",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TipoServicoId",
                table: "Evento",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_ClienteId",
                table: "Evento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_ColaboradorId",
                table: "Evento",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_LocalizacaoId",
                table: "Evento",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_TipoServicoId",
                table: "Evento",
                column: "TipoServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_Cliente_ClienteId",
                table: "Evento",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_Colaborador_ColaboradorId",
                table: "Evento",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_Localizacao_LocalizacaoId",
                table: "Evento",
                column: "LocalizacaoId",
                principalTable: "Localizacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_TipoServico_TipoServicoId",
                table: "Evento",
                column: "TipoServicoId",
                principalTable: "TipoServico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
