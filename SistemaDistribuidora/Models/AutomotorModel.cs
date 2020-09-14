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
        public string Nombre { get; set; }
        public int Modelo { get; set; }
        public string Marca { get; set; }


    }
}