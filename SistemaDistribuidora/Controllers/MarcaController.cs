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
    public class MarcaController : Controller
    {
        private readonly DistribuidoraContext _context;

        public MarcaController(DistribuidoraContext context)
        {
            _context = context;
        }

        // GET: Marca
        public async Task<IActionResult> Index()
        {
            return View(await _context.Marca.ToListAsync());
        }

        // GET: Marca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcaModel = await _context.Marca
                .FirstOrDefaultAsync(m => m.MarcaId == id);
            if (marcaModel == null)
            {
                return NotFound();
            }

            return View(marcaModel);
        }

        // GET: Marca/Create
        public IActionResult Create()
        {
            return View();
        }

        //Metodo para evitar la publicacion de los parametros en el navegador
        // POST: Marca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MarcaId,Nombre")] MarcaModel marcaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marcaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marcaModel);
        }

        // GET: Marca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcaModel = await _context.Marca.FindAsync(id);
            if (marcaModel == null)
            {
                return NotFound();
            }
            return View(marcaModel);
        }

        //Metodo para evitar la publicacion de los parametros en el navegador
        // POST: Marca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarcaId,Nombre")] MarcaModel marcaModel)
        {
            if (id != marcaModel.MarcaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaModelExists(marcaModel.MarcaId))
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
            return View(marcaModel);
        }

        // GET: Marca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcaModel = await _context.Marca
                .FirstOrDefaultAsync(m => m.MarcaId == id);
            if (marcaModel == null)
            {
                return NotFound();
            }

            return View(marcaModel);
        }

        //Metodo para evitar la publicacion de los parametros en el navegador
        // POST: Marca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marcaModel = await _context.Marca.FindAsync(id);
            _context.Marca.Remove(marcaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaModelExists(int id)
        {
            return _context.Marca.Any(e => e.MarcaId == id);
        }
    }
}
