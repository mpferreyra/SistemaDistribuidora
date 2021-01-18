using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDistribuidora.Data;
using SistemaDistribuidora.Models;
using SistemaDistribuidora.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Controllers
{
    public class LogginController : Controller
    {
        private readonly DistribuidoraContext _context;

        public LogginController(DistribuidoraContext context)
        {
            _context = context;
        }
        public IActionResult LogginView()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public  IActionResult LogginView(string nombreUsuario)
        {
            string nivelUsuario = tipoDeUsuario(nombreUsuario);
            switch(nivelUsuario)
            {
                case "Administrador":
                    {
                        return  RedirectToAction("Index", "Home");
                    }
                case "Cliente":
                    {
                        //TODO: retornar a las vista de clietne
                        return  View();
                    }
                default:
                    {
                        return NotFound();
                    }
            }                       
        }


        public  string tipoDeUsuario(string usuarioNombre)
        {
            var tipoUsuarioID = from s in  _context.Usuario
                                   where s.NombreUsuario == usuarioNombre
                                   select s.TipoUsuarioId;            
            switch(tipoUsuarioID.ToString())
            {
                case "1":
                    return ("Administrador");
                case "2":
                    return ("Cliente");
                default:
                    return ("NotFound");
            }
        }
    }
}
