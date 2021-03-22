using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class EstadoSolicitudModel
    {
        [Key]
        public int EstadoSolicitudId { get; set; }

        public string Descripcion { get; set; }

        public EstadoSolicitudModel()
        { }
        public EstadoSolicitudModel(string descripcion)
        {
            Descripcion = descripcion;
        }
    }
}


