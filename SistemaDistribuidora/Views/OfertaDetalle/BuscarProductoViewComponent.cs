//ERROR: esta clase deverai ir en el shared
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDistribuidora.Controllers;
using SistemaDistribuidora.Data;
using SistemaDistribuidora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Views.Shared
{
    [ViewComponent(Name = "BuscarProductoViewComponent")]
    public class BuscarProductoViewComponent : ViewComponent
    {
        private readonly DistribuidoraContext _context;        
        public BuscarProductoViewComponent(DistribuidoraContext context)
        {
            _context = context;
        }

        //HACK: revisar en base al controlador producto, para ver si es la forma correcta de hacerlo
        public IViewComponentResult Invoke(string code)
        {
            ProductoController p = new ProductoController(_context);
            var distribuidoraContext = p.devolverProductos();
            return View("~/Views/OfertaDetalle/BuscarProductoView.cshtml", distribuidoraContext.ToList());       
        }
    }
}
