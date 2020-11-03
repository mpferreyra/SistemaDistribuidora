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
    public class OfertaDetalleController : Controller
    {
        private readonly DistribuidoraContext _context;
        private List<OfertaDetalleModel> detalles;

        public OfertaDetalleController(DistribuidoraContext context)
        {
            _context = context;
            
        }

        // GET: OfertaDetalle
        public async Task<IActionResult> Index()
        {
            var distribuidoraContext = _context.OfertaDetalle.Include(o => o.Oferta).Include(o => o.Producto);
            return View(await distribuidoraContext.ToListAsync());
        }

        // GET: OfertaDetalle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofertaDetalleModel = await _context.OfertaDetalle
                .Include(o => o.Oferta)
                .Include(o => o.Producto)
                .FirstOrDefaultAsync(m => m.OfertaDetalleId == id);
            if (ofertaDetalleModel == null)
            {
                return NotFound();
            }

            return View(ofertaDetalleModel);
        }

        // GET: OfertaDetalle/Create
        public IActionResult Create()
        {
            ViewData["OfertaId"] = new SelectList(_context.Oferta, "OfertaId", "OfertaId");
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "ProductoId");
            return View();
        }

        // POST: OfertaDetalle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OfertaDetalleId,DescuentoPorcentaje,CantidadValidadDescuento,DescuentoCantidad,OfertaId,ProductoId")] OfertaDetalleModel ofertaDetalleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ofertaDetalleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OfertaId"] = new SelectList(_context.Oferta, "OfertaId", "OfertaId", ofertaDetalleModel.OfertaId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "ProductoId", ofertaDetalleModel.ProductoId);
            return View(ofertaDetalleModel);
        }

        // GET: OfertaDetalle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofertaDetalleModel = await _context.OfertaDetalle.FindAsync(id);
            if (ofertaDetalleModel == null)
            {
                return NotFound();
            }
            ViewData["OfertaId"] = new SelectList(_context.Oferta, "OfertaId", "OfertaId", ofertaDetalleModel.OfertaId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "ProductoId", ofertaDetalleModel.ProductoId);
            return View(ofertaDetalleModel);
        }

        // POST: OfertaDetalle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OfertaDetalleId,DescuentoPorcentaje,CantidadValidadDescuento,DescuentoCantidad,OfertaId,ProductoId")] OfertaDetalleModel ofertaDetalleModel)
        {
            if (id != ofertaDetalleModel.OfertaDetalleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ofertaDetalleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfertaDetalleModelExists(ofertaDetalleModel.OfertaDetalleId))
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
            ViewData["OfertaId"] = new SelectList(_context.Oferta, "OfertaId", "OfertaId", ofertaDetalleModel.OfertaId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "ProductoId", ofertaDetalleModel.ProductoId);
            return View(ofertaDetalleModel);
        }

        // GET: OfertaDetalle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofertaDetalleModel = await _context.OfertaDetalle
                .Include(o => o.Oferta)
                .Include(o => o.Producto)
                .FirstOrDefaultAsync(m => m.OfertaDetalleId == id);
            if (ofertaDetalleModel == null)
            {
                return NotFound();
            }

            return View(ofertaDetalleModel);
        }

        // POST: OfertaDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ofertaDetalleModel = await _context.OfertaDetalle.FindAsync(id);
            _context.OfertaDetalle.Remove(ofertaDetalleModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfertaDetalleModelExists(int id)
        {
            return _context.OfertaDetalle.Any(e => e.OfertaDetalleId == id);
        }


        //---------------------------------CODIGO ESCRITO--------------------------------
        [Route("OfertaDetalle/OfertasGestorView/{id?}")]
        public IActionResult OfertasGestorView(int id)
        {    
            //si no es 0, es un llamado para filtrar un producto
            if (id != 0)
            {                
                ProductoModel Producto = _context.Producto.Find(id);
                var Precio = _context.Precio.Where(p => p.ProductoID == Producto.ProductoId).ToList().Last();
                ViewBag.ProductoId = Producto.ProductoId;
                ViewBag.ProductoNombre = Producto.Nombre;
                ViewBag.ProductoPrecio = Precio.Valor;
            } 
            return View();
        }


        //public IActionResult AgregarDetalle([Bind("OfertaDetalleId,DescuentoPorcentaje,CantidadValidadDescuento,DescuentoCantidad,OfertaId,ProductoId")] OfertaDetalleModel detalle)
        //{
        //    detalles.Add(detalle);             
        //    ViewBag.Detalles = detalles;
        //    return View(nameof(OfertasGestorView));
        //}

        //va agregando detalles a lista de detalles que representa la oferta
        public IActionResult AgregarDetalle(int ProductoId, string ProductoNombre, int ProductoPrecio, int DescuentoPorcentaje)
        {
            //creo el detalle con los valores seleccionados por el usuario
            List<object> detalles = new List<object> { ProductoId, ProductoNombre, ProductoPrecio, DescuentoPorcentaje };
            if (ViewBag.Oferta == null)
            {
                //Si es el primero, creo la lista
                List<List<object>> oferta = new List<List<object>>();
                oferta.Add(detalles);
                ViewBag.Oferta = oferta;
            }
            else
            {
                //si no es el primero, obtengo la lista, agrego el detalle y lo vuelvo a ingresar
                List<List<object>> oferta = ViewBag.Oferta;
                oferta.Add(detalles);
                ViewBag.Oferta = oferta;
            }
            return View(nameof(OfertasGestorView));
        }








    }
}
