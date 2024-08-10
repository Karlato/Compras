using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Compras.Data;
using Compras.Models.Entities;

namespace Compras.Controllers
{
    public class OrdenesController : Controller
    {
        private readonly AppDbContext _context;

        public OrdenesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Ordenes
        public async Task<IActionResult> Index(int? numeroOrden, DateTime? fechaOrden, string articulo)
        {
            var appDbContext = _context.Ordenes.Include(o => o.Articulo).Include(o => o.UnidadMedida).AsQueryable();

            if (numeroOrden.HasValue)
            {
                appDbContext = appDbContext.Where(o => o.NumeroOrden == numeroOrden.Value);
                ViewData["numeroOrden"] = numeroOrden.Value;
            }

            if (fechaOrden.HasValue)
            {
                appDbContext = appDbContext.Where(o => o.FechaOrden.Date == fechaOrden.Value.Date);
                ViewData["fechaOrden"] = fechaOrden.Value.ToString("yyyy-MM-dd");
            }

            if (!string.IsNullOrWhiteSpace(articulo))
            {
                appDbContext = appDbContext.Where(o => o.Articulo.Descripcion.Contains(articulo));
                ViewData["articulo"] = articulo;
            }

            return View(await appDbContext.ToListAsync());
        }

        // GET: Ordenes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordenes
                .Include(o => o.Articulo)
                .Include(o => o.UnidadMedida)
                .FirstOrDefaultAsync(m => m.NumeroOrden == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // GET: Ordenes/Create
        public IActionResult Create()
        {
            ViewData["ArticuloID"] = new SelectList(_context.Articulos, "ID", "Descripcion");
            ViewData["MedidaID"] = new SelectList(_context.UnidadesMedida, "ID", "Descripcion");
            return View();
        }

        // POST: Ordenes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FechaOrden,ArticuloID,Cantidad,Estado,CostoUnitario")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.RealizarOrdenAsync(orden.FechaOrden, orden.ArticuloID, orden.Cantidad, orden.Estado, orden.CostoUnitario);
                    await _context.SaveChangesAsync();
                    await _context.DisponibilidadArticulosAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar la orden: " + ex.Message);
                }
            }
            ViewData["ArticuloID"] = new SelectList(_context.Articulos, "ID", "Descripcion", orden.ArticuloID);
            ViewData["MedidaID"] = new SelectList(_context.UnidadesMedida, "ID", "Descripcion", orden.MedidaID);
            return View(orden);
        }

        // GET: Ordenes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }
            ViewData["ArticuloID"] = new SelectList(_context.Articulos, "ID", "Descripcion", orden.ArticuloID);
            ViewData["MedidaID"] = new SelectList(_context.UnidadesMedida, "ID", "Descripcion", orden.MedidaID);
            return View(orden);
        }

        // POST: Ordenes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumeroOrden,FechaOrden,ArticuloID,Cantidad,Estado,CostoUnitario")] Orden orden)
        {
            if (id != orden.NumeroOrden)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var ordenExistente = await _context.Ordenes.FindAsync(id);
                    if (ordenExistente == null)
                    {
                        return NotFound();
                    }

                    await _context.ActualizarOrdenAsync(orden.NumeroOrden, orden.FechaOrden, orden.ArticuloID, orden.Cantidad, orden.Estado, orden.CostoUnitario);
                    await _context.DisponibilidadArticulosAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenExists(orden.NumeroOrden))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["ArticuloID"] = new SelectList(_context.Articulos, "ID", "Descripcion", orden.ArticuloID);
            ViewData["MedidaID"] = new SelectList(_context.UnidadesMedida, "ID", "Descripcion", orden.MedidaID);
            return View(orden);
        }

        // GET: Ordenes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordenes
                .Include(o => o.Articulo)
                .Include(o => o.UnidadMedida)
                .FirstOrDefaultAsync(m => m.NumeroOrden == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // POST: Ordenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orden = await _context.Ordenes.FindAsync(id);
            if (orden != null)
            {
                _context.Ordenes.Remove(orden);
            }

            await _context.RevertirOrdenAsync(id);
            await _context.SaveChangesAsync();

            await _context.DisponibilidadArticulosAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool OrdenExists(int id)
        {
            return _context.Ordenes.Any(e => e.NumeroOrden == id);
        }
    }
}
