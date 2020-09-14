using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDistribuidora.Migrations
{
    public partial class correcciocat2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Categoria_subCategoriaId",
                table: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Categoria_subCategoriaId",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "subCategoriaId",
                table: "Categoria");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaPadreId",
                table: "Categoria",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_CategoriaPadreId",
                table: "Categoria",
                column: "CategoriaPadreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Categoria_CategoriaPadreId",
                table: "Categoria",
                column: "CategoriaPadreId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Categoria_CategoriaPadreId",
                table: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Categoria_CategoriaPadreId",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "CategoriaPadreId",
                table: "Categoria");

            migrationBuilder.AddColumn<int>(
                name: "subCategoriaId",
                table: "Categoria",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_subCategoriaId",
                table: "Categoria",
                column: "subCategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Categoria_subCategoriaId",
                table: "Categoria",
                column: "subCategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
