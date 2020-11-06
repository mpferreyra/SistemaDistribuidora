using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Utilities
{
    public class DetalleOfertaResumen
    {
        public int ProductoID { get; set; }
        public string ProductoNombre { get; set; }
        public decimal Precio { get; set; }
        public int Descuento { get; set; }

        public DetalleOfertaResumen()
        { }
        public DetalleOfertaResumen(int productoID, string productoNombre, decimal precio, int descuento)
        {
            ProductoID = productoID;
            ProductoNombre = productoNombre;
            Precio = precio;
            Descuento = descuento;
        }
    }
}
