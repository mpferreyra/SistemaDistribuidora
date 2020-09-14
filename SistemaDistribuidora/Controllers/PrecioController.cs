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
    public class PrecioController : Controller
    {
        private readonly DistribuidoraContext _context;

        public PrecioController(DistribuidoraContext context)
        {
            _context = context;
        }

        // GET: Precio
        public async Task<IActionResult> Index()
        {
            return View(await _context.Precio.ToListAsync());
        }

        // GET: Precio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precioModel = await _context.Precio
                .FirstOrDefaultAsync(m => m.PrecioId == id);
            if (precioModel == null)
            {
                return NotFound();
            }

            return View(precioModel);
        }

        // GET: Precio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Precio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrecioId,Valor,FechaAlta,FechaBaja")] PrecioModel precioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(precioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(precioModel);
        }

        // GET: Precio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precioModel = await _context.Precio.FindAsync(id);
            if (precioModel == null)
            {
                return NotFound();
            }
            return View(precioModel);
        }

        // POST: Precio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrecioId,Valor,FechaAlta,FechaBaja")] PrecioModel precioModel)
        {
            if (id != precioModel.PrecioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(precioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrecioModelExists(precioModel.PrecioId))
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
            return View(precioModel);
        }

        // GET: Precio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precioModel = await _context.Precio
                .FirstOrDefaultAsync(m => m.PrecioId == id);
            if (precioModel == null)
            {
                return NotFound();
            }

            return View(precioModel);
        }

        // POST: Precio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var precioModel = await _context.Precio.FindAsync(id);
            _context.Precio.Remove(precioModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrecioModelExists(int id)
        {
            return _context.Precio.Any(e => e.PrecioId == id);
        }
    }
}
