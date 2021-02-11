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
        
        [Required(ErrorMessage = "Ingrese el nombre del producto")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Nombre { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Ingrese el codigo del producto")]
        public string Codigo { get; set; }


        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public bool Disponibilidad { get; set; }        

        [ForeignKey("Marca")]
        public int MarcaID { get; set; }
        public virtual MarcaModel Marca { get; set; }

        [ForeignKey("UnidadMedida")]
        public int UnidadMedidaId { get; set; }
        public virtual UnidadMedidaModel UnidadMedida { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public virtual CategoriaModel Categoria { get; set; }

        //Referencia a los precios producto
        public virtual List<PrecioModel> Precios { get; set; }



    }
}
