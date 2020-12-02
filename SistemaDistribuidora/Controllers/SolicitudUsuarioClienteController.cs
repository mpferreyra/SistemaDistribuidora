using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaDistribuidora.Data;
using SistemaDistribuidora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Controllers
{
    public class SolicitudUsuarioClienteController : Controller
    {
        private readonly DistribuidoraContext _context;
        public SolicitudUsuarioClienteController(DistribuidoraContext context)
        {
            _context = context;

        }

        public IActionResult SolicitudUsuarioClienteView()
        {
            return View();
        }

        /// <summary>
        /// Carga la solicitud a la BD
        /// </summary>
        /// <param name="ofertaDetalleModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RazonSocialCliente","TelefonoCliente","DirrecionCliente","MailCliente","CodigoPostalCliente","ActividadComercialCliente","AntiguedadEnEmpresaCliente","CargoCliente","CUITCliente","DNIPersona","NombresPersona","ApellidosPersona","TelefonoPersona","CelularPersona","MailPersona")] SolicitudUsuarioClienteModel solicitudUsuarioCliente)
        {
            solicitudUsuarioCliente.FechaPedido = DateTime.Now;
            solicitudUsuarioCliente.Estado = "Enviado";
            if (ModelState.IsValid)
            {
                _context.Add(solicitudUsuarioCliente);
                await _context.SaveChangesAsync();
                //HACK: redireccionar bien a la pagian de inicio sin usuario (cuando exista)
                return RedirectToAction(nameof(Index));
            }            
            return View(solicitudUsuarioCliente);
        }
    }
}
