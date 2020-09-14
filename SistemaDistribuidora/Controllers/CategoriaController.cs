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
    public class CategoriaController : Controller
    {
        private readonly DistribuidoraContext _context;

        public CategoriaController(DistribuidoraContext context)
        {
            _context = context;
        }

        // Llamado a la vista index
        public async Task<IActionResult> Index()
        {
            var sistemaDistribuidoraContext = _context.Categoria.Include(c => c.CategoriaPadre);
            return View(await sistemaDistribuidoraContext.ToListAsync());
        }

        // Llamado a la vista de detalles
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaModel = await _context.Categoria
                .Include(c => c.CategoriaPadre)
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (categoriaModel == null)
            {
                return NotFound();
            }

            return View(categoriaModel);
        }

        // GET: Categoria/Create
        public IActionResult Create()
        {
            ViewData["CategoriaPadreId"] = new SelectList(_context.Categoria, "CategoriaId", "Nombre");
            return View();
        }

        // POST: Categoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaId,Nombre,CategoriaPadreId")] CategoriaModel categoriaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaPadreId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId", categoriaModel.CategoriaPadreId);
            return View(categoriaModel);
        }

        // GET: Categoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaModel = await _context.Categoria.FindAsync(id);
            if (categoriaModel == null)
            {
                return NotFound();
            }
            ViewData["CategoriaPadreId"] = new SelectList(_context.Categoria, "CategoriaId", "Nombre", categoriaModel.CategoriaPadreId);
            return View(categoriaModel);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaId,Nombre,CategoriaPadreId")] CategoriaModel categoriaModel)
        {
            if (id != categoriaModel.CategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaModelExists(categoriaModel.CategoriaId))
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
            ViewData["CategoriaPadreId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId", categoriaModel.CategoriaPadreId);
            return View(categoriaModel);
        }

        // GET: Categoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaModel = await _context.Categoria
                .Include(c => c.CategoriaPadre)
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (categoriaModel == null)
            {
                return NotFound();
            }

            return View(categoriaModel);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaModel = await _context.Categoria.FindAsync(id);
            _context.Categoria.Remove(categoriaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaModelExists(int id)
        {
            return _context.Categoria.Any(e => e.CategoriaId == id);
        }
    }
}
