﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaDistribuidora.Data;

namespace SistemaDistribuidora.Migrations
{
    [DbContext(typeof(DistribuidoraContext))]
    [Migration("20201030174327_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaDistribuidora.Models.AutomotorModel", b =>
                {
                    b.Property<int>("AutomotorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Modelo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AutomotorId");

                    b.ToTable("Automotor");
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.CategoriaModel", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoriaPadreId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaId");

                    b.HasIndex("CategoriaPadreId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.EquivalenciasModel", b =>
                {
                    b.Property<int>("EquivalenciasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Producto1Id")
                        .HasColumnType("int");

                    b.Property<int>("Producto2Id")
                        .HasColumnType("int");

                    b.HasKey("EquivalenciasId");

                    b.ToTable("Equivalencias");
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.MarcaModel", b =>
                {
                    b.Property<int>("MarcaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MarcaId");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.OfertaDetalleModel", b =>
                {
                    b.Property<int>("OfertaDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("CantidadValidadDescuento")
                        .HasColumnType("real");

                    b.Property<float>("DescuentoCantidad")
                        .HasColumnType("real");

                    b.Property<float>("DescuentoPorcentaje")
                        .HasColumnType("real");

                    b.Property<int>("OfertaId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("OfertaDetalleId");

                    b.HasIndex("OfertaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("OfertaDetalle");
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.OfertaModel", b =>
                {
                    b.Property<int>("OfertaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activa")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfertaId");

                    b.ToTable("Oferta");
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.PersonaModel", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CUIT")
                        .HasColumnType("int");

                    b.Property<string>("Cargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Celular")
                        .HasColumnType("int");

                    b.Property<string>("DNI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dirrecion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumeroCliente")
                        .HasColumnType("int");

                    b.Property<int>("Telefono1")
                        .HasColumnType("int");

                    b.Property<int>("Telefono2")
                        .HasColumnType("int");

                    b.HasKey("PersonaId");

                    b.ToTable("PersonaModel");
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.PrecioModel", b =>
                {
                    b.Property<int>("PrecioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaBaja")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductoID")
                        .HasColumnType("int");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("PrecioId");

                    b.HasIndex("ProductoID");

                    b.ToTable("Precio");
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.ProductoAutomotorModel", b =>
                {
                    b.Property<int>("ProductoAutomotorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutomotorId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("ProductoAutomotorId");

                    b.HasIndex("AutomotorId");

                    b.HasIndex("ProductoId");

                    b.ToTable("ProductoAutomotor");
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.ProductoModel", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MarcaID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnidadMedidaId")
                        .HasColumnType("int");

                    b.Property<bool>("disponibilidad")
                        .HasColumnType("bit");

                    b.Property<string>("imagen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("MarcaID");

                    b.HasIndex("UnidadMedidaId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.ProductoOfertaModel", b =>
                {
                    b.Property<int>("ProductoOfertaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OfertaId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("ProductoOfertaId");

                    b.HasIndex("OfertaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("ProductoOferta");
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.ProductoProveedorModel", b =>
                {
                    b.Property<int>("ProductoProveedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.HasKey("ProductoProveedorId");

                    b.HasIndex("ProductoId");

                    b.HasIndex("ProveedorId");

                    b.ToTable("ProductoProveedor");
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.ProveedorModel", b =>
                {
                    b.Property<int>("ProveedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dirrecion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreFantasia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("ProveedorId");

                    b.HasIndex("PersonaId");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.UnidadMedidaModel", b =>
                {
                    b.Property<int>("UnidadMedidaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nombre")
                        .HasColumnType("int");

                    b.HasKey("UnidadMedidaId");

                    b.ToTable("UnidadMedida");
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.CategoriaModel", b =>
                {
                    b.HasOne("SistemaDistribuidora.Models.CategoriaModel", "CategoriaPadre")
                        .WithMany()
                        .HasForeignKey("CategoriaPadreId");
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.OfertaDetalleModel", b =>
                {
                    b.HasOne("SistemaDistribuidora.Models.OfertaModel", "Oferta")
                        .WithMany()
                        .HasForeignKey("OfertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDistribuidora.Models.ProductoModel", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.PrecioModel", b =>
                {
                    b.HasOne("SistemaDistribuidora.Models.ProductoModel", "Producto")
                        .WithMany("Precios")
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.ProductoAutomotorModel", b =>
                {
                    b.HasOne("SistemaDistribuidora.Models.AutomotorModel", "Automotor")
                        .WithMany()
                        .HasForeignKey("AutomotorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDistribuidora.Models.ProductoModel", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.ProductoModel", b =>
                {
                    b.HasOne("SistemaDistribuidora.Models.CategoriaModel", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDistribuidora.Models.MarcaModel", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDistribuidora.Models.UnidadMedidaModel", "UnidadMedida")
                        .WithMany()
                        .HasForeignKey("UnidadMedidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.ProductoOfertaModel", b =>
                {
                    b.HasOne("SistemaDistribuidora.Models.OfertaModel", "Oferta")
                        .WithMany()
                        .HasForeignKey("OfertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDistribuidora.Models.ProductoModel", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.ProductoProveedorModel", b =>
                {
                    b.HasOne("SistemaDistribuidora.Models.ProductoModel", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDistribuidora.Models.ProveedorModel", "Proveedor")
                        .WithMany()
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDistribuidora.Models.ProveedorModel", b =>
                {
                    b.HasOne("SistemaDistribuidora.Models.PersonaModel", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
