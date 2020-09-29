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
    public class OfertaController : Controller
    {
        private readonly DistribuidoraContext _context;

        public OfertaController(DistribuidoraContext context)
        {
            _context = context;
        }

        // GET: Oferta
        public async Task<IActionResult> Index()
        {
            return View(await _context.Oferta.ToListAsync());
        }

        // GET: Oferta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofertaModel = await _context.Oferta
                .FirstOrDefaultAsync(m => m.OfertaId == id);
            if (ofertaModel == null)
            {
                return NotFound();
            }

            return View(ofertaModel);
        }

        // GET: Oferta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oferta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OfertaId,FechaInicio,FechaFin,Activa")] OfertaModel ofertaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ofertaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ofertaModel);
        }

        // GET: Oferta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofertaModel = await _context.Oferta.FindAsync(id);
            if (ofertaModel == null)
            {
                return NotFound();
            }
            return View(ofertaModel);
        }

        // POST: Oferta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OfertaId,FechaInicio,FechaFin,Activa")] OfertaModel ofertaModel)
        {
            if (id != ofertaModel.OfertaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ofertaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfertaModelExists(ofertaModel.OfertaId))
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
            return View(ofertaModel);
        }

        // GET: Oferta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofertaModel = await _context.Oferta
                .FirstOrDefaultAsync(m => m.OfertaId == id);
            if (ofertaModel == null)
            {
                return NotFound();
            }

            return View(ofertaModel);
        }

        // POST: Oferta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ofertaModel = await _context.Oferta.FindAsync(id);
            _context.Oferta.Remove(ofertaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfertaModelExists(int id)
        {
            return _context.Oferta.Any(e => e.OfertaId == id);
        }

        //-----------------------cODIGO GENERADO A MANO-------------------------
                
    }
}
