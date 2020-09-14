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
    public class AutomotorController : Controller
    {
        private readonly DistribuidoraContext _context;

        public AutomotorController(DistribuidoraContext context)
        {
            _context = context;
        }

        // GET: Automotor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Automotor.ToListAsync());
        }

        // GET: Automotor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automotorModel = await _context.Automotor
                .FirstOrDefaultAsync(m => m.AutomotorId == id);
            if (automotorModel == null)
            {
                return NotFound();
            }

            return View(automotorModel);
        }

        // GET: Automotor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Automotor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutomotorId,Nombre,Modelo,Marca")] AutomotorModel automotorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(automotorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(automotorModel);
        }

        // GET: Automotor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automotorModel = await _context.Automotor.FindAsync(id);
            if (automotorModel == null)
            {
                return NotFound();
            }
            return View(automotorModel);
        }

        // POST: Automotor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutomotorId,Nombre,Modelo,Marca")] AutomotorModel automotorModel)
        {
            if (id != automotorModel.AutomotorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(automotorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutomotorModelExists(automotorModel.AutomotorId))
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
            return View(automotorModel);
        }

        // GET: Automotor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automotorModel = await _context.Automotor
                .FirstOrDefaultAsync(m => m.AutomotorId == id);
            if (automotorModel == null)
            {
                return NotFound();
            }

            return View(automotorModel);
        }

        // POST: Automotor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var automotorModel = await _context.Automotor.FindAsync(id);
            _context.Automotor.Remove(automotorModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutomotorModelExists(int id)
        {
            return _context.Automotor.Any(e => e.AutomotorId == id);
        }
    }
}
