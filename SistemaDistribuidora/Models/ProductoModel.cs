using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class ProductoModel
    {
        //datos del producto
        [Key]
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string imagen { get; set; }
        public bool disponibilidad { get; set; }

        //llaves foraneas
        [ForeignKey("Precio")]
        public int PrecioID { get; set; }
        public virtual PrecioModel Precio { get; set; }

        [ForeignKey("Marca")]
        public int MarcaID { get; set; }
        public virtual MarcaModel Marca { get; set; }

        [ForeignKey("UnidadMedida")]
        public int UnidadMedidaId { get; set; }
        public virtual UnidadMedidaModel UnidadMedida { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public virtual CategoriaModel Categoria { get; set; }



    }
}
