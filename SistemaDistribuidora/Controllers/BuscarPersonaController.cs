using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDistribuidora.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Controllers
{
    public class BuscarPersonaController : Controller
    {
        private readonly DistribuidoraContext _context;

        public BuscarPersonaController(DistribuidoraContext context)
        {
            _context = context;
        }

        //[Route("BuscarProducto/BuscarProductoView/{filtroNombre?}/{productoCodigo?}")]
        [HttpGet]
        public IActionResult BuscarPersonaView(/*string filtroNombre, string filtroCodigo*/)
        {
            var distribuidoraContext = _context.Persona;
            //var distribuidoraContext = _context.Persona.Include(p => p.Categoria).Include(p => p.Marca).Include(p => p.UnidadMedida).Include(p => p.Precios).ToList();
            //filtro por nombre y codigo
            //if (!String.IsNullOrEmpty(filtroNombre))
            //{
            //    distribuidoraContext = distribuidoraContext.Where(p => p.Nombre.Contains(filtroNombre)).ToList();
            //    if (!String.IsNullOrEmpty(filtroCodigo))
            //        distribuidoraContext = distribuidoraContext.Where(p => p.Codigo.Equals(filtroCodigo)).ToList();
            //}
            ////filtro por codigo
            //else
            //{
            //    if (!String.IsNullOrEmpty(filtroCodigo))
            //        distribuidoraContext = distribuidoraContext.Where(p => p.Codigo.Equals(filtroCodigo)).ToList();
            //}
            return PartialView(distribuidoraContext);
        }


    }
}
