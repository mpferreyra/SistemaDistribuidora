using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class SolicitudUsuarioClienteModel
    {
        public int SolicitudUsuarioClienteId { get; set; }
        public DateTime FechaPedido { get; set; }
        //de aprovacion o rechazo
        public DateTime FechaRevision { get; set; }
        //true aprovado 
        public bool Estado { get; set; }
        public string AprovacionUsuario { get; set; }

        //llaves foraneas
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public virtual ClienteModel Cliente
        {
            get; set;
        }        
    } 
}
