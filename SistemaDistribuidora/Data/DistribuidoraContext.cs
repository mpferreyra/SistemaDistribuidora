﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaDistribuidora.Models;

namespace SistemaDistribuidora.Data
{
    public class DistribuidoraContext : DbContext
    {
        public DistribuidoraContext (DbContextOptions<DistribuidoraContext> options)
            : base(options)
        {
        }

        public DbSet<AutomotorModel> Automotor { get; set; }
        public DbSet<CategoriaModel> Categoria { get; set; }
        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<EquivalenciasModel> Equivalencias { get; set; }
        public DbSet<MarcaModel> Marca { get; set; }
        public DbSet<OfertaDetalleModel> OfertaDetalle { get; set; }
        public DbSet<OfertaModel> Oferta { get; set; }
        public DbSet<PersonaModel> Persona { get; set; }
        public DbSet<PrecioModel> Precio { get; set; }
        public DbSet<ProductoAutomotorModel> ProductoAutomotor { get; set; }
        public DbSet<ProductoModel> Producto { get; set; }
        public DbSet<ProductoOfertaModel> ProductoOferta { get; set; }
        public DbSet<ProductoProveedorModel> ProductoProveedor { get; set; }
        public DbSet<ProveedorModel> Proveedor { get; set; }
        public DbSet<UnidadMedidaModel> UnidadMedida { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<SolicitudUsuarioClienteModel> SolicitudUsuarioCliente { get; set; }
        public DbSet<TipoUsuarioModel> TipoUsuario { get; set; }
        public DbSet<EstadoSolicitudModel> EstadoSolicitud { get; set; }
        public DbSet<ProvinciaModel> Provincia { get; set; }
        public DbSet<LocalidadModel> Localidad { get; set; }

    }
}
