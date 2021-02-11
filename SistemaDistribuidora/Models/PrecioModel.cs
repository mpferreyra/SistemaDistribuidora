using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class PrecioModel
    {
        [Key]
        public int PrecioId { get; set; }

        [Required(ErrorMessage = "Ingrese el precio")]
        public float Valor { get; set; }

        [Display(Name = "Fecha de alta")]
        public DateTime FechaAlta { get; set; }

        [Display(Name = "Fecha de baja")]
        public DateTime? FechaBaja { get; set; }

        [ForeignKey("Producto")]
        public int ProductoID { get; set; }
        public virtual ProductoModel Producto { get; set; }

        public PrecioModel()
        { }

        public PrecioModel(float valor, DateTime fechaAlta, DateTime? fechaBaja, int productoID)
        {            
            Valor = valor;
            FechaAlta = fechaAlta;
            FechaBaja = fechaBaja;
            ProductoID = productoID;
        }
    }
}
