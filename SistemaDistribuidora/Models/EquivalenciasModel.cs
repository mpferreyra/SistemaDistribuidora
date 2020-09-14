using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class EquivalenciasModel
    {
        [Key]
        public int EquivalenciasId { get; set; }
        public int Producto1Id { get; set; }
        public int Producto2Id { get; set; }

    }
}
