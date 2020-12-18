using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class SolicitudUsuarioClienteModel
    {
        

        [Key]
        public int SolicitudUsuarioClienteId { get; set; }
        public DateTime FechaPedido { get; set; }
        //de aprovacion o rechazo
        public DateTime FechaRevision { get; set; }
        //true aprovado 
        public string Estado { get; set; }
        public string AprovacionUsuario { get; set; }
        public string RazonSocialCliente { get; set; }
        public int CUIT{ get; set; }
        public int TelefonoCliente { get; set; }
        public string DirrecionCliente { get; set; }
        public string MailCliente { get; set; }
        public int CodigoPostalCliente { get; set; }
        public string ActividadComercialCliente { get; set; }
        public int AntiguedadEnEmpresaCliente { get; set; }
        public string CargoCliente { get; set; }        
        public string DNIPersona { get; set; }
        public string NombresPersona { get; set; }
        public string ApellidosPersona { get; set; }
        public int TelefonoPersona { get; set; }
        public int CelularPersona { get; set; }
        public string MailPersona { get; set; }
        public string NombreUsuario { get; set; }
        public string ContraseñaUsuario { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Confirme su contraseña")]
        [CompareAttribute("ContraseñaUsuario", ErrorMessage = "Contraseñas diferentes.")]
        public string ConfirmarContraseñaUsuario { get; set; }


        public SolicitudUsuarioClienteModel()
        {

        }

        public SolicitudUsuarioClienteModel(DateTime fechaPedido, DateTime fechaRevision, string estado, string aprovacionUsuario, string razonSocialCliente, int cUIT, int telefonoCliente, string dirrecionCliente, string mailCliente, int codigoPostalCliente, string actividadComercialCliente, int antiguedadEnEmpresaCliente, string cargoCliente, string dNIPersona, string nombresPersona, string apellidosPersona, int telefonoPersona, int celularPersona, string mailPersona, string nombreUsuario, string contraseñaUsuario)
        {
            FechaPedido = fechaPedido;
            FechaRevision = fechaRevision;
            Estado = estado;
            AprovacionUsuario = aprovacionUsuario;
            RazonSocialCliente = razonSocialCliente;
            CUIT = cUIT;
            TelefonoCliente = telefonoCliente;
            DirrecionCliente = dirrecionCliente;
            MailCliente = mailCliente;
            CodigoPostalCliente = codigoPostalCliente;
            ActividadComercialCliente = actividadComercialCliente;
            AntiguedadEnEmpresaCliente = antiguedadEnEmpresaCliente;
            CargoCliente = cargoCliente;
            DNIPersona = dNIPersona;
            NombresPersona = nombresPersona;
            ApellidosPersona = apellidosPersona;
            TelefonoPersona = telefonoPersona;
            CelularPersona = celularPersona;
            MailPersona = mailPersona;
            NombreUsuario = nombreUsuario;
            ContraseñaUsuario = contraseñaUsuario;
        }


    } 
}
