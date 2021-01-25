using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class TipoUsuarioModel
    {
        [Key]
        public int TipoUsuarioId { get; set; }
        [Display(Name = "Permisos")]
        public string Descripcion { get; set; }
    }
}
