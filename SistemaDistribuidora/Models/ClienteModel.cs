using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class ClienteModel
    {
        [Key]
        public int ClienteId { get; set; }
        public string RazonSocial { get; set; }
        public int Telefono { get; set; }
        public string Dirrecion { get; set; }
        public string Mail { get; set; }
        public int CodigoPostal { get; set; }
        public string ActividadComercial { get; set; }
        public int AntiguedadEnEmpresa { get; set; }
        public string Cargo { get; set; }
        public int CUIT { get; set; }


        //llaves foraneas
        [ForeignKey("Persona")]
        public int PersonaId { get; set; }
        public virtual PersonaModel Persona { get; set; }

    }
}
