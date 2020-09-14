using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class PrecioModel
    {
        [Key]
        public int PrecioId { get; set; }
        public float Valor { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }


    }
}
