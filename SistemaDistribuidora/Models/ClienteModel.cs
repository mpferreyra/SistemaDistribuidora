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

        [Required(ErrorMessage = "Ingrese la razon social")]
        [Display(Name = "Razon social")]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "Ingrese el telefono")]
        [Phone]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "Ingrese la direccion")]
        public string Dirrecion { get; set; }

        [Required(ErrorMessage = "Ingrese el Mail")]
        [EmailAddress]
        public string Mail { get; set; }

        [Display(Name = "Codigo postal")]
        public int CodigoPostal { get; set; }

        [Required(ErrorMessage = "Ingrese la actividad comercial")]
        [Display(Name = "Actividad comercial")]
        public string ActividadComercial { get; set; }

        [Display(Name = "Antiguedad en la empresa")]
        public int AntiguedadEnEmpresa { get; set; }

        public string Cargo { get; set; }

        [Required(ErrorMessage = "Ingrese el CUIT")]
        public int CUIT { get; set; }

        



        //llaves foraneas
        [ForeignKey("Persona")]
        public int PersonaId { get; set; }
        public virtual PersonaModel Persona { get; set; }

        [ForeignKey("Localidad")]
        public int LocalidadId { get; set; }
        public virtual LocalidadModel Localidad { get; set; }

        public ClienteModel(string razonSocial, int telefono, string dirrecion, string mail, int codigoPostal, string actividadComercial, int antiguedadEnEmpresa, string cargo, int cUIT, int personaId, int localidadId)
        {
            
            RazonSocial = razonSocial;
            Telefono = telefono;
            Dirrecion = dirrecion;
            Mail = mail;
            CodigoPostal = codigoPostal;
            ActividadComercial = actividadComercial;
            AntiguedadEnEmpresa = antiguedadEnEmpresa;
            Cargo = cargo;
            CUIT = cUIT;
            PersonaId = personaId;            
            LocalidadId = localidadId;
        }




    }
}
