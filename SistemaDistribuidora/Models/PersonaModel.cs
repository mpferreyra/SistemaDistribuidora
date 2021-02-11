using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class PersonaModel
    {
        [Key]
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "Ingrese el telefono")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string DNI { get; set; }

        [Required(ErrorMessage = "Ingrese los nombres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Ingrese el apellido")]
        public string Apellidos { get; set; }


        public int Telefono { get; set; } 
        

        public int Celular { get; set; }

        [Required(ErrorMessage = "Ingrese el mail")]
        [EmailAddress]
        public string Mail { get; set; }




        public PersonaModel(string dNI,string nombres,string apellidos,int telefono,int celular,string mail)
        {            
            DNI = dNI;
            Nombres = nombres;
            Apellidos = apellidos;
            Telefono = telefono;
            Celular = celular;
            Mail = mail;
        }

    }
}
