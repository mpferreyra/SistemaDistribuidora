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
    public class UnidadMedidaController : Controller
    {
        private readonly DistribuidoraContext _context;

        public UnidadMedidaController(DistribuidoraContext context)
        {
            _context = context;
        }

        // GET: UnidadMedida
        public async Task<IActionResult> Index()
        {
            return View(await _context.UnidadMedida.ToListAsync());
        }

        // GET: UnidadMedida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadMedidaModel = await _context.UnidadMedida
                .FirstOrDefaultAsync(m => m.UnidadMedidaId == id);
            if (unidadMedidaModel == null)
            {
                return NotFound();
            }

            return View(unidadMedidaModel);
        }

        // GET: UnidadMedida/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnidadMedida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnidadMedidaId,Nombre,Imagen")] UnidadMedidaModel unidadMedidaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadMedidaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidadMedidaModel);
        }

        // GET: UnidadMedida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadMedidaModel = await _context.UnidadMedida.FindAsync(id);
            if (unidadMedidaModel == null)
            {
                return NotFound();
            }
            return View(unidadMedidaModel);
        }

        // POST: UnidadMedida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnidadMedidaId,Nombre,Imagen")] UnidadMedidaModel unidadMedidaModel)
        {
            if (id != unidadMedidaModel.UnidadMedidaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadMedidaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadMedidaModelExists(unidadMedidaModel.UnidadMedidaId))
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
            return View(unidadMedidaModel);
        }

        // GET: UnidadMedida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadMedidaModel = await _context.UnidadMedida
                .FirstOrDefaultAsync(m => m.UnidadMedidaId == id);
            if (unidadMedidaModel == null)
            {
                return NotFound();
            }

            return View(unidadMedidaModel);
        }

        // POST: UnidadMedida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidadMedidaModel = await _context.UnidadMedida.FindAsync(id);
            _context.UnidadMedida.Remove(unidadMedidaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadMedidaModelExists(int id)
        {
            return _context.UnidadMedida.Any(e => e.UnidadMedidaId == id);
        }
    }
}
