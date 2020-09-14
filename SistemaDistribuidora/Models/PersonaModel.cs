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
        public int? NumeroCliente { get; set; }
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Telefono1 { get; set; }
        public int Telefono2 { get; set; }
        public int Celular { get; set; }
        public int CUIT { get; set; }
        public string Localidad { get; set; }
        public string Dirrecion { get; set; }
        public string Mail { get; set; }
        public string Cargo { get; set; }
    }
}
