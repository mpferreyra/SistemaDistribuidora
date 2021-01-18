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
    public class UsuarioController : Controller
    {
        private readonly DistribuidoraContext _context;

        public UsuarioController(DistribuidoraContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            var distribuidoraContext = _context.Usuario.Include(u => u.Persona).Include(u => u.TipoUsuario);
            return View(await distribuidoraContext.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.Usuario
                .Include(u => u.Persona)
                .Include(u => u.TipoUsuario)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId");

            SelectList listaTipoUsuario = new SelectList(_context.TipoUsuario, "TipoUsuarioId", "TipoUsuarioId");
            ViewData["TipoUsuarioId"] = listaTipoUsuario;
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Usuario/Create/{DNI?}")]
        public async Task<IActionResult> Create(string tipoUsuarioDescripcion,[Bind("UsuarioId,NombreUsuario,Contraseña,ConfirmarContraseña,PersonaId,TipoUsuarioId")] UsuarioModel usuarioModel)
        {
            //HACK: falta traer bien y vincular la descripcion del tipo de usuario con el tipoUsuarioid
            if (ModelState.IsValid)
            {
                _context.Add(usuarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId", usuarioModel.PersonaId);
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuario, "TipoUsuarioId", "TipoUsuarioId", usuarioModel.TipoUsuarioId);
            return View(usuarioModel);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.Usuario.FindAsync(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId", usuarioModel.PersonaId);
            ViewData["TipoUsuarioId"] = new SelectList(_context.Set<TipoUsuarioModel>(), "TipoUsuarioId", "TipoUsuarioId", usuarioModel.TipoUsuarioId);
            return View(usuarioModel);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,NombreUsuario,Contraseña,PersonaId,TipoUsuarioId")] UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioModelExists(usuarioModel.UsuarioId))
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
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId", usuarioModel.PersonaId);
            ViewData["TipoUsuarioId"] = new SelectList(_context.Set<TipoUsuarioModel>(), "TipoUsuarioId", "TipoUsuarioId", usuarioModel.TipoUsuarioId);
            return View(usuarioModel);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.Usuario
                .Include(u => u.Persona)
                .Include(u => u.TipoUsuario)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioModel = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuarioModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioModelExists(int id)
        {
            return _context.Usuario.Any(e => e.UsuarioId == id);
        }


        public IActionResult PruebaModal()
        {
            
            return View();
        }

    }
}
