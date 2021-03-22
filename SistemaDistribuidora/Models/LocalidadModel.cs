using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class LocalidadModel
    {
        [Key]
        public int LocalidadId { get; set; }
        public string Nombre { get; set; }

        //llaves foraneas
        [ForeignKey("Provincia")]
        public int ProvinciaId { get; set; }
        public virtual ProvinciaModel Provincia { get; set; }
    }
}
