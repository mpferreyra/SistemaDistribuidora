using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Controllers
{
    public class SolicitudUsuarioClienteController : Controller
    {
        public IActionResult SolicitudUsuarioClienteView()
        {
            return View();
        }
    }
}
