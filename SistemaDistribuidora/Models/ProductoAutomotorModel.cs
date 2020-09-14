using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class ProductoAutomotorModel
    {
        [Key]
        public int ProductoAutomotorId { get; set; }

        [ForeignKey("ProductoModel")]
        public int ProductoId { get; set; }

        [ForeignKey("AutomotorModel")]
        public int AutomotorId { get; set; }        
        public virtual AutomotorModel Automotor { get; set; }  
        public virtual ProductoModel Producto { get; set; }

    }
}
