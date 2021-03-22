using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDistribuidora.Data;
using SistemaDistribuidora.Models;

namespace SistemaDistribuidora.Controllers
{
    public class EstadoSolicitudController : Controller
    {
        private readonly DistribuidoraContext _context;

        public EstadoSolicitudController(DistribuidoraContext context)
        {
            _context = context;
        }

        //ERROR: no funca, no llama al metodo.no llega al punto de interrupcion
        /// <summary>
        /// Carga los valores para los tipos de usuarios
        /// </summary>
        /// <returns>Siempre true</returns>
        [HttpPost]
        public async Task<IActionResult> CargarValoresDefecto()
        {
            TipoUsuarioModel TipoUsuario = new TipoUsuarioModel("Todos los estados");
            if (ModelState.IsValid)
            {
                _context.Add(TipoUsuario);
                await _context.SaveChangesAsync();
            }

            TipoUsuario = new TipoUsuarioModel("Aprobado");
            if (ModelState.IsValid)
            {
                _context.Add(TipoUsuario);
                await _context.SaveChangesAsync();
            }

            TipoUsuario = new TipoUsuarioModel("Desaprobado");
            if (ModelState.IsValid)
            {
                _context.Add(TipoUsuario);
                await _context.SaveChangesAsync();
            }

            TipoUsuario = new TipoUsuarioModel("Enviado");
            if (ModelState.IsValid)
            {
                _context.Add(TipoUsuario);
                await _context.SaveChangesAsync();
            }
            return View();
        }


    }
}
