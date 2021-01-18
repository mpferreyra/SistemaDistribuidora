﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDistribuidora.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automotor",
                columns: table => new
                {
                    AutomotorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Modelo = table.Column<int>(nullable: false),
                    Marca = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automotor", x => x.AutomotorId);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    CategoriaPadreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                    table.ForeignKey(
                        name: "FK_Categoria_Categoria_CategoriaPadreId",
                        column: x => x.CategoriaPadreId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equivalencias",
                columns: table => new
                {
                    EquivalenciasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Producto1Id = table.Column<int>(nullable: false),
                    Producto2Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equivalencias", x => x.EquivalenciasId);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    MarcaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.MarcaId);
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    OfertaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    Activa = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.OfertaId);
                });

            migrationBuilder.CreateTable(
                name: "PersonaModel",
                columns: table => new
                {
                    PersonaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCliente = table.Column<int>(nullable: true),
                    DNI = table.Column<string>(nullable: true),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Telefono1 = table.Column<int>(nullable: false),
                    Telefono2 = table.Column<int>(nullable: false),
                    Celular = table.Column<int>(nullable: false),
                    CUIT = table.Column<int>(nullable: false),
                    Localidad = table.Column<string>(nullable: true),
                    Dirrecion = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Cargo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaModel", x => x.PersonaId);
                });

            migrationBuilder.CreateTable(
                name: "UnidadMedida",
                columns: table => new
                {
                    UnidadMedidaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<int>(nullable: false),
                    Imagen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadMedida", x => x.UnidadMedidaId);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    NombreFantasia = table.Column<string>(nullable: true),
                    Telefono = table.Column<int>(nullable: false),
                    Dirrecion = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    PersonaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.ProveedorId);
                    table.ForeignKey(
                        name: "FK_Proveedor_PersonaModel_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "PersonaModel",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    imagen = table.Column<string>(nullable: true),
                    disponibilidad = table.Column<bool>(nullable: false),
                    MarcaID = table.Column<int>(nullable: false),
                    UnidadMedidaId = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_Marca_MarcaID",
                        column: x => x.MarcaID,
                        principalTable: "Marca",
                        principalColumn: "MarcaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_UnidadMedida_UnidadMedidaId",
                        column: x => x.UnidadMedidaId,
                        principalTable: "UnidadMedida",
                        principalColumn: "UnidadMedidaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfertaDetalle",
                columns: table => new
                {
                    OfertaDetalleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescuentoPorcentaje = table.Column<float>(nullable: false),
                    CantidadValidadDescuento = table.Column<float>(nullable: false),
                    DescuentoCantidad = table.Column<float>(nullable: false),
                    OfertaId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaDetalle", x => x.OfertaDetalleId);
                    table.ForeignKey(
                        name: "FK_OfertaDetalle_Oferta_OfertaId",
                        column: x => x.OfertaId,
                        principalTable: "Oferta",
                        principalColumn: "OfertaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfertaDetalle_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Precio",
                columns: table => new
                {
                    PrecioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<float>(nullable: false),
                    FechaAlta = table.Column<DateTime>(nullable: false),
                    FechaBaja = table.Column<DateTime>(nullable: false),
                    ProductoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precio", x => x.PrecioId);
                    table.ForeignKey(
                        name: "FK_Precio_Producto_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoAutomotor",
                columns: table => new
                {
                    ProductoAutomotorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(nullable: false),
                    AutomotorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoAutomotor", x => x.ProductoAutomotorId);
                    table.ForeignKey(
                        name: "FK_ProductoAutomotor_Automotor_AutomotorId",
                        column: x => x.AutomotorId,
                        principalTable: "Automotor",
                        principalColumn: "AutomotorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoAutomotor_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoOferta",
                columns: table => new
                {
                    ProductoOfertaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(nullable: false),
                    OfertaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoOferta", x => x.ProductoOfertaId);
                    table.ForeignKey(
                        name: "FK_ProductoOferta_Oferta_OfertaId",
                        column: x => x.OfertaId,
                        principalTable: "Oferta",
                        principalColumn: "OfertaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoOferta_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoProveedor",
                columns: table => new
                {
                    ProductoProveedorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(nullable: false),
                    ProveedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoProveedor", x => x.ProductoProveedorId);
                    table.ForeignKey(
                        name: "FK_ProductoProveedor_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoProveedor_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_CategoriaPadreId",
                table: "Categoria",
                column: "CategoriaPadreId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaDetalle_OfertaId",
                table: "OfertaDetalle",
                column: "OfertaId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaDetalle_ProductoId",
                table: "OfertaDetalle",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Precio_ProductoID",
                table: "Precio",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_CategoriaId",
                table: "Producto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_MarcaID",
                table: "Producto",
                column: "MarcaID");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_UnidadMedidaId",
                table: "Producto",
                column: "UnidadMedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoAutomotor_AutomotorId",
                table: "ProductoAutomotor",
                column: "AutomotorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoAutomotor_ProductoId",
                table: "ProductoAutomotor",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoOferta_OfertaId",
                table: "ProductoOferta",
                column: "OfertaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoOferta_ProductoId",
                table: "ProductoOferta",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoProveedor_ProductoId",
                table: "ProductoProveedor",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoProveedor_ProveedorId",
                table: "ProductoProveedor",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_PersonaId",
                table: "Proveedor",
                column: "PersonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equivalencias");

            migrationBuilder.DropTable(
                name: "OfertaDetalle");

            migrationBuilder.DropTable(
                name: "Precio");

            migrationBuilder.DropTable(
                name: "ProductoAutomotor");

            migrationBuilder.DropTable(
                name: "ProductoOferta");

            migrationBuilder.DropTable(
                name: "ProductoProveedor");

            migrationBuilder.DropTable(
                name: "Automotor");

            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "UnidadMedida");

            migrationBuilder.DropTable(
                name: "PersonaModel");
        }
    }
}