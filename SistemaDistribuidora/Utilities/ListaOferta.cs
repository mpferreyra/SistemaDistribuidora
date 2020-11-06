using System.Collections.Generic;

namespace SistemaDistribuidora.Utilities
{
    public class ListaOferta
    {
        public List<DetalleOfertaResumen> Oferta { get; set; }

        public ListaOferta()
        {
            Oferta = new List<DetalleOfertaResumen>();
        }

        public List<DetalleOfertaResumen> getOferta()
        {
            return Oferta;
        }
        public void setOferta(List<DetalleOfertaResumen> oferta)
        {
            Oferta = oferta;
        }

        public void addDetalles(int productoID, string productoNombre, decimal precio, int descuento)
        {
            Oferta.Add(new DetalleOfertaResumen(productoID, productoNombre, precio, descuento));
        }

        //Devuelve el detalle o null
        public DetalleOfertaResumen findDetalle(int productoID)
        {
            return buscarDetalle(productoID);
        }

        //busca el detalle en la oferta segun el productoId
        public DetalleOfertaResumen buscarDetalle(int productoID)
        {
            foreach (DetalleOfertaResumen detalle in Oferta)
            {
                if (detalle.ProductoID == productoID)
                    return detalle;
            }
            return null;
        }


    }
}
