using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Models
{
    public class CategoriaModel
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("subCategoriaId")]
        public int? CategoriaPadreId { get; set; }
        public CategoriaModel CategoriaPadre { get; set; }

    }
}
