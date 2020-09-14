using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class ProveedorModel
    {
        [Key]
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string NombreFantasia { get; set; }
        public int Telefono { get; set; }
        public string Dirrecion { get; set; }
        public string Mail { get; set; }

        //llaves foraneas
        [ForeignKey("Persona")]
        public int PersonaId { get; set; }
        public virtual PersonaModel Persona { get; set; }


    }

}
