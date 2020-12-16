using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDistribuidora.Migrations
{
    public partial class arregloChiquito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CUITCliente",
                table: "SolicitudUsuarioCliente",
                newName: "CUIT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CUIT",
                table: "SolicitudUsuarioCliente",
                newName: "CUITCliente");
        }
    }
}
