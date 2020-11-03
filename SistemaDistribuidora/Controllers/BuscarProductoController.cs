using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using SistemaDistribuidora.Data;

namespace SistemaDistribuidora.Controllers
{
    //Ventana de busqueda de un producto en particular, que devuelve el ProductoId de la fila seleccionada
    public class BuscarProductoController : Controller
    {
        private readonly DistribuidoraContext _context;

        public BuscarProductoController(DistribuidoraContext context)
        {
            _context = context;
        }
        [Route("BuscarProducto/BuscarProductoView/{filtroNombre?}/{productoCodigo?}")]
        public IActionResult BuscarProductoView(string filtroNombre, string filtroCodigo)
        {
            var distribuidoraContext = _context.Producto.Include(p => p.Categoria).Include(p => p.Marca).Include(p => p.UnidadMedida).Include(p => p.Precios).ToList();
            //filtro por nombre y codigo
            if (!String.IsNullOrEmpty(filtroNombre))
            {
                distribuidoraContext = distribuidoraContext.Where(p => p.Nombre.Contains(filtroNombre)).ToList();
                if (!String.IsNullOrEmpty(filtroCodigo))
                    distribuidoraContext = distribuidoraContext.Where(p => p.Codigo.Equals(filtroCodigo)).ToList();
            }
            //filtro por codigo
            else
            {
                if (!String.IsNullOrEmpty(filtroCodigo))
                    distribuidoraContext = distribuidoraContext.Where(p => p.Codigo.Equals(filtroCodigo)).ToList();
            }
            return View(distribuidoraContext);
        }


    }
}
