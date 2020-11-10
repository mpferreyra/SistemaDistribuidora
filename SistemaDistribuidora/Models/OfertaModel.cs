using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class OfertaModel
    {
        [Key]
        public int OfertaId { get; set; }
        [Index(IsUnique = true)]
        public String Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Boolean Activa { get; set; }
        public Boolean OfertaPrincipal { get; set; }
        public Boolean Recordar { get; set; }

        public OfertaModel( String nombre, DateTime fechaInicio, DateTime fechaFin, Boolean activa, Boolean ofertaPrincipal, Boolean recordar)
        {            
            Nombre = nombre;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Activa = activa;
            OfertaPrincipal = ofertaPrincipal;
            Recordar = recordar;
        }

    }
}