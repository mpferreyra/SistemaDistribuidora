using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Create()
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
        public async Task<IActionResult> Create([Bind("RazonSocialCliente","TelefonoCliente","DirrecionCliente","MailCliente","CodigoPostalCliente","ActividadComercialCliente","AntiguedadEnEmpresaCliente","CargoCliente","CUIT","DNIPersona","NombresPersona","ApellidosPersona","TelefonoPersona","CelularPersona","MailPersona")] SolicitudUsuarioClienteModel solicitudUsuarioCliente)
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

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitudUsuarioCliente = await _context.SolicitudUsuarioCliente.FindAsync(id);
            if (solicitudUsuarioCliente == null)
            {
                return NotFound();
            }
            return View(solicitudUsuarioCliente);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SolicitudUsuarioClienteId", "RazonSocialCliente", "TelefonoCliente", "DirrecionCliente", "MailCliente", "CodigoPostalCliente", "ActividadComercialCliente", "AntiguedadEnEmpresaCliente", "CargoCliente", "CUIT", "DNIPersona", "NombresPersona", "ApellidosPersona", "TelefonoPersona", "CelularPersona", "MailPersona")] SolicitudUsuarioClienteModel solicitudUsuarioCliente)
        {
            if (id != solicitudUsuarioCliente.SolicitudUsuarioClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitudUsuarioCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!solicitudUsuarioClienteModelExists(solicitudUsuarioCliente.SolicitudUsuarioClienteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }           
            return View(solicitudUsuarioCliente);
        }

        private bool solicitudUsuarioClienteModelExists(int id)
        {
            return _context.SolicitudUsuarioCliente.Any(e => e.SolicitudUsuarioClienteId == id);
        }

        // GET: Producto/Delete/5
        public async Task<IActionResult> Revisar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitudUsuarioCliente = await _context.SolicitudUsuarioCliente.FirstOrDefaultAsync(m => m.SolicitudUsuarioClienteId == id);
            if (solicitudUsuarioCliente == null)
            {
                return NotFound();
            }

            return View(solicitudUsuarioCliente);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Aprobar(int SolicitudUsuarioClienteId)
        {
            var solicitudUsuarioCliente = await _context.SolicitudUsuarioCliente.FindAsync(SolicitudUsuarioClienteId);
            solicitudUsuarioCliente.FechaRevision = DateTime.Now;
            solicitudUsuarioCliente.Estado = "Aprobado";
            _context.Update(solicitudUsuarioCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Desaprobar(int SolicitudUsuarioClienteId)
        {
            var solicitudUsuarioCliente = await _context.SolicitudUsuarioCliente.FindAsync(SolicitudUsuarioClienteId);
            solicitudUsuarioCliente.FechaRevision = DateTime.Now;
            solicitudUsuarioCliente.Estado = "Desaprobado";
            _context.Update(solicitudUsuarioCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Index(string SearchFilterRazon, string SearchFilterEstado, string FilterEstado)
        {
            //var SolicitudContext = _context.SolicitudUsuarioCliente;
            //HACK: como seria la conversion a dbset para seguir usando los mismos metodos
            var SolicitudContext = from s in _context.SolicitudUsuarioCliente                                   
                                   select s;

            //Busqueda
            ViewData["SearchFilterRazon"] = SearchFilterRazon;
            if (!String.IsNullOrEmpty(SearchFilterRazon))
            {
                SolicitudContext = SolicitudContext.Where(s => s.RazonSocialCliente.Contains(SearchFilterRazon));
            }
            
            if (!String.IsNullOrEmpty(FilterEstado))
            {                
                SolicitudContext = SolicitudContext.Where(s => s.Estado.Contains(FilterEstado));
            }
            else
            {
                SolicitudContext = SolicitudContext.Where(s => s.Estado.Contains("Enviado"));
            }

            return View(await SolicitudContext.ToListAsync());
        }

        
    }
}
