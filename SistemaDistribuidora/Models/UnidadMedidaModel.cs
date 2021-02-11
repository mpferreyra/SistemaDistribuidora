using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class UnidadMedidaModel
    {
        [Key]
        public int UnidadMedidaId { get; set; }

        [Display(Name = "Ingrese el nombre")]
        public string Nombre { get; set; }
        public string Imagen { get; set; }
    }
}

