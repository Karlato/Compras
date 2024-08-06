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
    public class ArticulosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ArticulosController> _logger;

        public ArticulosController(AppDbContext context, ILogger<ArticulosController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Articulos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Articulos.Include(a => a.UnidadMedida);
            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> Buscar(int? articuloID, string descripcion)
        {
            var articulos = from a in _context.Articulos
                            select a;

            if (articuloID.HasValue)
            {
                articulos = articulos.Where(a => a.ID == articuloID.Value);
            }

            if (!string.IsNullOrEmpty(descripcion))
            {
                articulos = articulos.Where(a => a.Descripcion.Contains(descripcion));
            }

            return View("Index", await articulos.ToListAsync());
        }

        // GET: Articulos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .Include(a => a.UnidadMedida)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // GET: Articulos/Create
        public IActionResult Create()
        {
            _logger.LogInformation("Entering Create action");
            ViewData["MedidaID"] = new SelectList(_context.UnidadesMedida, "ID", "Descripcion");
            return View();
        }

        // POST: Articulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descripcion,Marca,MedidaID,Existencia,Estado")] Articulo articulo)
        {
            _logger.LogInformation("Creating new articulo");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(articulo);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Articulo created successfully");
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating articulo");
                    ModelState.AddModelError("", $"Unable to save changes. Error: {ex.Message}");
                }
            }
            _logger.LogWarning("ModelState is invalid");
            ViewData["MedidaID"] = new SelectList(_context.UnidadesMedida, "ID", "Descripcion", articulo.MedidaID);
            return View(articulo);
        }

        // GET: Articulos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }
            ViewData["MedidaID"] = new SelectList(_context.UnidadesMedida, "ID", "Descripcion", articulo.MedidaID);
            return View(articulo);
        }

        // POST: Articulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descripcion,Marca,MedidaID,Existencia,Estado")] Articulo articulo)
        {
            if (id != articulo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticuloExists(articulo.ID))
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
            ViewData["MedidaID"] = new SelectList(_context.UnidadesMedida, "ID", "Descripcion", articulo.MedidaID);
            return View(articulo);
        }

        // GET: Articulos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .Include(a => a.UnidadMedida)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // POST: Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo != null)
            {
                _context.Articulos.Remove(articulo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(e => e.ID == id);
        }
    }
}
