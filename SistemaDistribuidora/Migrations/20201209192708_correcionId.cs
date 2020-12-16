using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDistribuidora.Migrations
{
    public partial class correcionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SolicitudUsuarioCliente",
                columns: table => new
                {
                    SolicitudUsuarioClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRevision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AprovacionUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazonSocialCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoCliente = table.Column<int>(type: "int", nullable: false),
                    DirrecionCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPostalCliente = table.Column<int>(type: "int", nullable: false),
                    ActividadComercialCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AntiguedadEnEmpresaCliente = table.Column<int>(type: "int", nullable: false),
                    CargoCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUITCliente = table.Column<int>(type: "int", nullable: false),
                    DNIPersona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombresPersona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidosPersona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoPersona = table.Column<int>(type: "int", nullable: false),
                    CelularPersona = table.Column<int>(type: "int", nullable: false),
                    MailPersona = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudUsuarioCliente", x => x.SolicitudUsuarioClienteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolicitudUsuarioCliente");
        }
    }
}
