using Microsoft.AspNetCore.Mvc;
using SistemaDistribuidora.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Controllers
{
    public class PruebaController : Controller
    {
        private readonly DistribuidoraContext _context;

        public PruebaController(DistribuidoraContext context)
        {
            _context = context;
        }
        public IActionResult indexconproductos()
        {
            return View();
        }
    }
}
