using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDistribuidora.Data;
using SistemaDistribuidora.Models;
using SistemaDistribuidora.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDistribuidora.Controllers
{
    public class SolicitudUsuarioClienteController : Controller
    {
        private readonly DistribuidoraContext _context;
        private PersonaRepository personaRepository;
        public SolicitudUsuarioClienteController(DistribuidoraContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuario, "TipoUsuarioId", "Descripcion");
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "ProvinciaId", "Nombre");
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "LocalidadId", "Nombre");
            return View();
        }

        /// <summary>
        /// Carga la solicitud a la BD
        /// </summary>
        /// <param name="ofertaDetalleModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RazonSocialCliente", "TelefonoCliente", "DirrecionCliente", "MailCliente", "CodigoPostalCliente", "ActividadComercialCliente", "AntiguedadEnEmpresaCliente", "CargoCliente", "CUIT", "DNIPersona", "NombresPersona", "ApellidosPersona", "TelefonoPersona", "CelularPersona", "MailPersona", "NombreUsuario", "ContraseñaUsuario", "ConfirmarContraseñaUsuario","TipoUsuarioId","LocalidadId")] SolicitudUsuarioClienteModel solicitudUsuarioCliente)
        {            
            solicitudUsuarioCliente.FechaPedido = DateTime.Now;

            //busco el id del estado enviado y se lo paso a la solicitud
            EstadoSolicitudModel estado = _context.EstadoSolicitud.Where(e => e.Descripcion == "Enviado").FirstOrDefault();
            solicitudUsuarioCliente.EstadoSolicitudId = estado.EstadoSolicitudId;
            if (ModelState.IsValid)
            {
                _context.Add(solicitudUsuarioCliente);
                await _context.SaveChangesAsync();                
                return RedirectToAction("LogginView", "Loggin");
            }
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuario, "TipoUsuarioId", "Descripcion");
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "ProvinciaId", "Nombre");
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "LocalidadId", "Nombre");
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
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuario, "TipoUsuarioId", "Descripcion");
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "ProvinciaId", "Nombre");
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "LocalidadId", "Nombre");
            return View(solicitudUsuarioCliente);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SolicitudUsuarioClienteId", "RazonSocialCliente", "TelefonoCliente", "DirrecionCliente", "MailCliente", "CodigoPostalCliente", "ActividadComercialCliente", "AntiguedadEnEmpresaCliente", "CargoCliente", "CUIT", "DNIPersona", "NombresPersona", "ApellidosPersona", "TelefonoPersona", "CelularPersona", "MailPersona", "NombreUsuario", "ContraseñaUsuario", "ConfirmarContraseñaUsuario", "TipoUsuarioId", "EstadoSolicitudId")] SolicitudUsuarioClienteModel solicitudUsuarioCliente)
        {
            if (id != solicitudUsuarioCliente.SolicitudUsuarioClienteId)
            {
                return NotFound();
            }

            //para que la confirmacion de contraseña no falle en la comprovacino de estado
            solicitudUsuarioCliente.ConfirmarContraseñaUsuario = solicitudUsuarioCliente.ContraseñaUsuario.Trim();
            //ERROR: falla la validacion del estado en la parte de confirmar contraseña, a pesar de corregirse en la lina anterior
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
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuario, "TipoUsuarioId", "Descripcion");
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "ProvinciaId", "Nombre");
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "LocalidadId", "Nombre");
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
            
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuario, "TipoUsuarioId", "Descripcion");
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "ProvinciaId", "Nombre");
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "LocalidadId", "Nombre");
            return View(solicitudUsuarioCliente);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Aprobar(int SolicitudUsuarioClienteId)
        {
            var solicitudUsuarioCliente = await _context.SolicitudUsuarioCliente.FindAsync(SolicitudUsuarioClienteId);
            //Actualizo los valores de la solicitud
            solicitudUsuarioCliente.FechaRevision = DateTime.Now;

            //busco el id del estado aprobado y se lo paso a la solicitud
            EstadoSolicitudModel estado = _context.EstadoSolicitud.Where(e => e.Descripcion == "Aprobado").FirstOrDefault();
            solicitudUsuarioCliente.EstadoSolicitudId = estado.EstadoSolicitudId;
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
            }
            //cargo el usuario, el cliente y la persona
            personaRepository = new PersonaRepository(_context);
            try
            {               
                personaRepository.CrearConjuntoPersonaClienteUsuario(solicitudUsuarioCliente);
            }
            catch (Exception e)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Desaprobar(int SolicitudUsuarioClienteId)
        {
            var solicitudUsuarioCliente = await _context.SolicitudUsuarioCliente.FindAsync(SolicitudUsuarioClienteId);
            solicitudUsuarioCliente.FechaRevision = DateTime.Now;

            //busco el id del estado enviado y se lo paso a la solicitud
            EstadoSolicitudModel estado = _context.EstadoSolicitud.Where(e => e.Descripcion == "Desaprobado").FirstOrDefault();
            solicitudUsuarioCliente.EstadoSolicitudId = estado.EstadoSolicitudId;
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
            }
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Index(string SearchRazon,int SearchCUIT, string Estado, string Tipo)
        {
            //var SolicitudContext = _context.SolicitudUsuarioCliente;
            //HACK: como seria la conversion a dbset para seguir usando los mismos metodos
            var SolicitudContext = from s in _context.SolicitudUsuarioCliente
                                   select s;

            //Busqueda            
            if (!String.IsNullOrEmpty(SearchRazon)) 
            {
                SolicitudContext = SolicitudContext.Where(s => s.RazonSocialCliente.Contains(SearchRazon));
            }

            if (SearchCUIT != 0)
            {
                SolicitudContext = SolicitudContext.Where(s => s.CUIT.ToString().Contains(SearchCUIT.ToString()));
            }

            if (!String.IsNullOrEmpty(Estado)) 
            {
                SolicitudContext = SolicitudContext.Where(s => s.EstadoSolicitud.EstadoSolicitudId.ToString() == Estado);
            }

            if (!String.IsNullOrEmpty(Tipo))
            {
                SolicitudContext = SolicitudContext.Where(s => s.TipoUsuario.TipoUsuarioId.ToString() == Tipo);
            }

            //SelectList listaTipo = new SelectList(_context.TipoUsuario, "TipoUsuarioId", "Descripcion");
            //listaTipo.Prepend(new SelectListItem("va","5",true));
            //ViewData["SearchTipo"] = listaTipo;

            ViewData["SearchRazon"] = SearchRazon;
            ViewData["SearchCUIT"] = SearchCUIT;
            ViewData["SearchEstado"] = new SelectList(_context.EstadoSolicitud, "EstadoSolicitudId", "Descripcion");
            ViewData["SearchTipo"] = new SelectList(_context.TipoUsuario, "TipoUsuarioId", "Descripcion");

            return View(await SolicitudContext.ToListAsync());
        }


    }
}
