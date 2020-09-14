using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }

        //llaves foraneas
        [ForeignKey("Persona")]
        public int PersonaId { get; set; }
        public virtual PersonaModel Persona { get; set; }

    }
}
