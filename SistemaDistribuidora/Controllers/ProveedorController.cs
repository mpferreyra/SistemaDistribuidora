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
    public class ProveedorController : Controller
    {
        private readonly DistribuidoraContext _context;

        public ProveedorController(DistribuidoraContext context)
        {
            _context = context;
        }

        // GET: Proveedor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proveedor.ToListAsync());
        }

        // GET: Proveedor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedorModel = await _context.Proveedor
                .FirstOrDefaultAsync(m => m.ProveedorId == id);
            if (proveedorModel == null)
            {
                return NotFound();
            }

            return View(proveedorModel);
        }

        // GET: Proveedor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proveedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProveedorId,Nombre,Telefono,Dirrecion,Mail")] ProveedorModel proveedorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proveedorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proveedorModel);
        }

        // GET: Proveedor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedorModel = await _context.Proveedor.FindAsync(id);
            if (proveedorModel == null)
            {
                return NotFound();
            }
            return View(proveedorModel);
        }

        // POST: Proveedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProveedorId,Nombre,Telefono,Dirrecion,Mail")] ProveedorModel proveedorModel)
        {
            if (id != proveedorModel.ProveedorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveedorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedorModelExists(proveedorModel.ProveedorId))
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
            return View(proveedorModel);
        }

        // GET: Proveedor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedorModel = await _context.Proveedor
                .FirstOrDefaultAsync(m => m.ProveedorId == id);
            if (proveedorModel == null)
            {
                return NotFound();
            }

            return View(proveedorModel);
        }

        // POST: Proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proveedorModel = await _context.Proveedor.FindAsync(id);
            _context.Proveedor.Remove(proveedorModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProveedorModelExists(int id)
        {
            return _context.Proveedor.Any(e => e.ProveedorId == id);
        }
    }
}
