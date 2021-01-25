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
        public  IActionResult LogginView(string nombreUsuario, string contraseña)
        {
            string nivelUsuario = credencialesCorrectas(nombreUsuario, contraseña);
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

        /// <summary>
        /// Comprueba las credenciales. Devuelve null si no existen o el tipo de usuario si si.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contraseña"></param>
        /// <returns></returns>
        public string credencialesCorrectas( string usuarioNombre, string contraseña)
        {
            var descripcionUsuario = (from s in _context.Usuario
                                      where s.NombreUsuario == usuarioNombre && s.Contraseña == contraseña
                                      select s.TipoUsuario.Descripcion).SingleOrDefault();
            return descripcionUsuario;
        }

        /// <summary>
        /// Busca el tipo de usuario (permiso)
        /// </summary>
        /// <param name="usuarioNombre"></param>
        /// <returns></returns>
        public  string tipoDeUsuario(string usuarioNombre)
        {
           var descripcionUsuario = (from s in  _context.Usuario
                                   where s.NombreUsuario == usuarioNombre
                                   select s.TipoUsuario.Descripcion).SingleOrDefault();
            return descripcionUsuario;
        }
    }
}
