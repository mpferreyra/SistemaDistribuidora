using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class PersonaModel
    {
        [Key]
        public int PersonaId { get; set; }
        public int? ClienteId { get; set; }
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }        
        public int Celular { get; set; }               
        public string Mail { get; set; }
        
    }
}
