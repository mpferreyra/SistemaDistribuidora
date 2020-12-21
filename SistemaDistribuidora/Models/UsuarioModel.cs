using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class UsuarioModel
    {  
        [Key]
        public int UsuarioId { get; set; }
        public string NombreUsuario  { get; set; }
        [PasswordPropertyText]
        public string Contraseña { get; set; }

        //llaves foraneas
        [ForeignKey("Persona")]
        public int PersonaId { get; set; }
        public virtual PersonaModel Persona { get; set; }

        [ForeignKey("TipoUsuario")]
        public int TipoUsuarioId { get; set; }
        public virtual TipoUsuarioModel TipoUsuario { get; set; }


        public UsuarioModel(string nombreUsuario, string contraseña, int personaId, int tipoUsuarioId)
        {
            
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            PersonaId = personaId;
            TipoUsuarioId = tipoUsuarioId;
        }
    }
}
