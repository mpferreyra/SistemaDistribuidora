using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class OfertaDetalleModel
    {
        [Key]
        public int OfertaDetalleId { get; set; }

        //porcentaje de descuento por producto individual
        [Display(Name = "Porcentaje de descuento")]
        public float DescuentoPorcentaje { get; set; }

        //cantidad de productos necesaria alcanzada para que riga un descuento por candidad comprada
        [Display(Name = "Cantidad valida para descuento")]
        public float CantidadValidadDescuento { get; set; }

        //cantidad de descuento por cantidad de productos comprados
        [Display(Name = "Porcentaje de descuento por cantidad")]
        public float DescuentoCantidad { get; set; }

        //llave foranea
        [ForeignKey("OfertaModel")]
        public int OfertaId { get; set; }        
        public OfertaModel Oferta { get; set; }

        [ForeignKey("ProductoModel")]
        public int ProductoId { get; set; }
        public ProductoModel Producto { get; set; }
    }
}
