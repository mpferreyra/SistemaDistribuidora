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
    public class PersonaController : Controller
    {
        private readonly DistribuidoraContext _context;

        public PersonaController(DistribuidoraContext context)
        {
            _context = context;
        }

        // GET: PersonaModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Persona.ToListAsync());
        }

        // GET: PersonaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaModel = await _context.Persona
                .FirstOrDefaultAsync(m => m.PersonaId == id);
            if (personaModel == null)
            {
                return NotFound();
            }

            return View(personaModel);
        }

        // GET: PersonaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonaId,DNI,Nombres,Apellidos,Telefono,Celular,Mail")] PersonaModel personaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personaModel);
        }

        // GET: PersonaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaModel = await _context.Persona.FindAsync(id);
            if (personaModel == null)
            {
                return NotFound();
            }
            return View(personaModel);
        }

        // POST: PersonaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonaId,DNI,Nombres,Apellidos,Telefono,Celular,Mail")] PersonaModel personaModel)
        {
            if (id != personaModel.PersonaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaModelExists(personaModel.PersonaId))
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
            return View(personaModel);
        }

        // GET: PersonaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaModel = await _context.Persona
                .FirstOrDefaultAsync(m => m.PersonaId == id);
            if (personaModel == null)
            {
                return NotFound();
            }

            return View(personaModel);
        }

        // POST: PersonaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personaModel = await _context.Persona.FindAsync(id);
            _context.Persona.Remove(personaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaModelExists(int id)
        {
            return _context.Persona.Any(e => e.PersonaId == id);
        }
    }
}
