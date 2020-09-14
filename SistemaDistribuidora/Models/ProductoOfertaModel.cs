using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class ProductoOfertaModel
    {
        [Key]
        public int ProductoOfertaId { get; set; }

        [ForeignKey("Producto")]
        public int ProductoId { get; set; }

        [ForeignKey("Oferta")]
        public int OfertaId { get; set; }

        public ProductoModel Producto { get; set; }
        public OfertaModel Oferta { get; set; }
    }
}
