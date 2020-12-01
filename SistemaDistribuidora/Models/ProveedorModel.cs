using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class ProveedorModel
    {
        [Key]
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }    


    }

}
