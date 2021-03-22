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
        public DateTime? FechaRevision { get; set; }  
        public string AprovacionUsuario { get; set; }

        [Required(ErrorMessage = "Ingrese la razon social")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Razon social")]
        public string RazonSocialCliente { get; set; }

        [Required(ErrorMessage = "Ingrese el CUIT")]
        public int CUIT{ get; set; }

        [Display(Name = "Telefono del cliente")]
        public int TelefonoCliente { get; set; }

        [Display(Name = "Direccion del cliente")]
        [Required(ErrorMessage = "Ingrese la direccion del cliente")]
        public string DirrecionCliente { get; set; }

        [Display(Name = "Mail del cliente")]
        [Required(ErrorMessage = "Ingrese el mail del cliente")]
        //TODO: [EmailAddress]
        public string MailCliente { get; set; }


        [Display(Name = "Codigo postal")]
        public int CodigoPostalCliente { get; set; }

        [Display(Name = "Actividad comercial")]
        [Required(ErrorMessage = "Ingrese la actividad comercial")]
        //TODO: podria ser un select
        public string ActividadComercialCliente { get; set; }

        [Display(Name = "Antiguedad en la empresa")]
        public int AntiguedadEnEmpresaCliente { get; set; }

        [Display(Name = "Cargo que usufrutua en la empresa")]
        public string CargoCliente { get; set; }

        [Display(Name = "DNI")]
        [Required(ErrorMessage = "Ingrese el DNI")]
        public string DNIPersona { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Ingrese el nombre")]
        public string NombresPersona { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Ingrese el apellido")]
        public string ApellidosPersona { get; set; }
        public int TelefonoPersona { get; set; }
        public int CelularPersona { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Ingrese el mail")]
        //TODO: [EmailAddress]
        public string MailPersona { get; set; }

        [Display(Name = "Elija el nombre de usuario")]
        [Required(ErrorMessage = "Ingres el nombre de usuario")]
        public string NombreUsuario { get; set; }

        [Display(Name = "Elija una contraseña")]
        [Required(ErrorMessage = "Ingres la contraseña")]
        public string ContraseñaUsuario { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Confirme su contraseña")]
        [CompareAttribute("ContraseñaUsuario", ErrorMessage = "Contraseñas diferentes.")]
        public string ConfirmarContraseñaUsuario { get; set; }

        //Claves foraneas
        [ForeignKey("TipoUsuario")]
        public int TipoUsuarioId { get; set; }
        public virtual TipoUsuarioModel TipoUsuario { get; set; }

        [ForeignKey("EstadoSolicitud")]
        public int EstadoSolicitudId { get; set; }
        public virtual EstadoSolicitudModel EstadoSolicitud { get; set; }        

        [ForeignKey("Localidad")]
        public int LocalidadId { get; set; }
        public virtual LocalidadModel Localidad { get; set; }


        public SolicitudUsuarioClienteModel()
        {

        }

        public SolicitudUsuarioClienteModel(DateTime fechaPedido, DateTime fechaRevision, string aprovacionUsuario, string razonSocialCliente, int cUIT, int telefonoCliente, string dirrecionCliente, string mailCliente, int codigoPostalCliente, string actividadComercialCliente, int antiguedadEnEmpresaCliente, string cargoCliente, string dNIPersona, string nombresPersona, string apellidosPersona, int telefonoPersona, int celularPersona, string mailPersona, string nombreUsuario, string contraseñaUsuario, int estadoSolicitudId, int localidadId)
        {
            FechaPedido = fechaPedido;
            FechaRevision = fechaRevision;            
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
            EstadoSolicitudId = estadoSolicitudId;
            LocalidadId = localidadId;
        }


    } 
}
