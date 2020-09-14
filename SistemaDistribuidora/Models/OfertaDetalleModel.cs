﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class OfertaDetalleModel
    {
        [Key]
        public int OfertaDetalleId { get; set; }
        //porcentaje de descuento por producto individual
        public float DescuentoPorcentaje { get; set; }
        //cantidad de productos necesaria alcanzada para que riga un descuento por candidad comprada
        public float CantidadValidadDescuento { get; set; }
        //cantidad de descuento por cantidad de productos comprados
        public float DescuentoCantidad { get; set; }

        //llave foranea
        [ForeignKey("OfertaModel")]
        public int OfertaId { get; set; }        
        public OfertaModel Oferta { get; set; }
    }
}
