using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDistribuidora.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SolicitudUsuarioCliente_TipoUsuarioId",
                table: "SolicitudUsuarioCliente",
                column: "TipoUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudUsuarioCliente_TipoUsuario_TipoUsuarioId",
                table: "SolicitudUsuarioCliente",
                column: "TipoUsuarioId",
                principalTable: "TipoUsuario",
                principalColumn: "TipoUsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudUsuarioCliente_TipoUsuario_TipoUsuarioId",
                table: "SolicitudUsuarioCliente");

            migrationBuilder.DropIndex(
                name: "IX_SolicitudUsuarioCliente_TipoUsuarioId",
                table: "SolicitudUsuarioCliente");
        }
    }
}
