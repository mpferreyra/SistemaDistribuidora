using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class MarcaModel
    {
        [Key]
        public int MarcaId { get; set; }
        public string Nombre { get; set; }
    }
}
