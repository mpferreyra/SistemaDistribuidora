using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Controllers
{
    public class LogginController : Controller
    {
        public IActionResult LogginView()
        {
            return View();
        }
    }
}
