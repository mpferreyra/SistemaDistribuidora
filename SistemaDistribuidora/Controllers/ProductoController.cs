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
    public class ProductoController : Controller
    {
        private readonly DistribuidoraContext _context;

        public ProductoController(DistribuidoraContext context)
        {
            _context = context;
        }

        // GET: Producto
        public async Task<IActionResult> Index()
        {
            var distribuidoraContext = _context.Producto.Include(p => p.Categoria).Include(p => p.Marca).Include(p => p.UnidadMedida);
            return View(await distribuidoraContext.ToListAsync());
        }

        // GET: Producto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoModel = await _context.Producto
                .Include(p => p.Categoria)
                .Include(p => p.Marca)
                .Include(p => p.UnidadMedida)
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (productoModel == null)
            {
                return NotFound();
            }

            return View(productoModel);
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId");
            ViewData["MarcaID"] = new SelectList(_context.Marca, "MarcaId", "MarcaId");
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadMedida, "UnidadMedidaId", "UnidadMedidaId");
            return View();
        }

        // POST: Producto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoId,Nombre,Codigo,Descripcion,imagen,disponibilidad,MarcaID,UnidadMedidaId,CategoriaId")] ProductoModel productoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId", productoModel.CategoriaId);
            ViewData["MarcaID"] = new SelectList(_context.Marca, "MarcaId", "MarcaId", productoModel.MarcaID);
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadMedida, "UnidadMedidaId", "UnidadMedidaId", productoModel.UnidadMedidaId);
            return View(productoModel);
        }

        // GET: Producto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoModel = await _context.Producto.FindAsync(id);
            if (productoModel == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId", productoModel.CategoriaId);
            ViewData["MarcaID"] = new SelectList(_context.Marca, "MarcaId", "MarcaId", productoModel.MarcaID);
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadMedida, "UnidadMedidaId", "UnidadMedidaId", productoModel.UnidadMedidaId);
            return View(productoModel);
        }

        // POST: Producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoId,Nombre,Codigo,Descripcion,imagen,disponibilidad,MarcaID,UnidadMedidaId,CategoriaId")] ProductoModel productoModel)
        {
            if (id != productoModel.ProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoModelExists(productoModel.ProductoId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId", productoModel.CategoriaId);
            ViewData["MarcaID"] = new SelectList(_context.Marca, "MarcaId", "MarcaId", productoModel.MarcaID);
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadMedida, "UnidadMedidaId", "UnidadMedidaId", productoModel.UnidadMedidaId);
            return View(productoModel);
        }

        // GET: Producto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoModel = await _context.Producto
                .Include(p => p.Categoria)
                .Include(p => p.Marca)
                .Include(p => p.UnidadMedida)
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (productoModel == null)
            {
                return NotFound();
            }

            return View(productoModel);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productoModel = await _context.Producto.FindAsync(id);
            _context.Producto.Remove(productoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoModelExists(int id)
        {
            return _context.Producto.Any(e => e.ProductoId == id);
        }


        //public PartialViewResult BuscarProductoViewP()
        //{           
        //    return PartialView("_BuscarProductoViewP");
        //}

        //// GET: Producto
        //public PartialViewResult BuscarProductoView()
        //{
        //    var distribuidoraContext = _context.Producto.Include(p => p.Categoria).Include(p => p.Marca).Include(p => p.UnidadMedida).Include(p => p.Precios);
        //    return PartialView( distribuidoraContext.ToListAsync());
        //}

        //HACK:esto no se si es lo mas lindo
        public IEnumerable<SistemaDistribuidora.Models.ProductoModel>  devolverProductos()
        {
            var distribuidoraContext = _context.Producto.Include(p => p.Categoria).Include(p => p.Marca).Include(p => p.UnidadMedida).Include(p => p.Precios);
            return distribuidoraContext.ToList(); 
        }

        


    }
}
