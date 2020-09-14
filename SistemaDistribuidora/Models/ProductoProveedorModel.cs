using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class ProductoProveedorModel
    {
        [Key]
        public int ProductoProveedorId { get; set; }

        [ForeignKey("ProductoModel")]
        public int ProductoId { get; set; }

        [ForeignKey("ProveedorModel")]
        public int ProveedorId { get; set; }

        public virtual ProductoModel Producto { get; set; }
        public virtual ProveedorModel Proveedor { get; set; }
    }
}
