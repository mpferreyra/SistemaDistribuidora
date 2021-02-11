using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class AutomotorModel
    {
        [Key]
        public int AutomotorId { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre del automotor")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese el modelo del automotor")]
        public int Modelo { get; set; }
        [Required(ErrorMessage = "Ingrese la marca del automotor")]
        public string Marca { get; set; }


    }
}