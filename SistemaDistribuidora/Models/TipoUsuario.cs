﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class TipoUsuario
    {
        [Key]
        public int TipoUsuarioId { get; set; }
        public string Descripcion { get; set; }
    }
}
