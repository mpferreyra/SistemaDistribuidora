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
        public string Estado { get; set; }
        public string AprovacionUsuario { get; set; }
        public string RazonSocialCliente { get; set; }
        public int TelefonoCliente { get; set; }
        public string DirrecionCliente { get; set; }
        public string MailCliente { get; set; }
        public int CodigoPostalCliente { get; set; }
        public string ActividadComercialCliente { get; set; }
        public int AntiguedadEnEmpresaCliente { get; set; }
        public string CargoCliente { get; set; }
        public int CUITCliente { get; set; }
        public string DNIPersona { get; set; }
        public string NombresPersona { get; set; }
        public string ApellidosPersona { get; set; }
        public int TelefonoPersona { get; set; }
        public int CelularPersona { get; set; }
        public string MailPersona { get; set; }


    } 
}
