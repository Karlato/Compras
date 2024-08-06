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
    public class UnidadesMedidaController : Controller
    {
        private readonly AppDbContext _context;

        public UnidadesMedidaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UnidadesMedida
        public async Task<IActionResult> Index()
        {
            return View(await _context.UnidadesMedida.ToListAsync());
        }

        // GET: UnidadesMedida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadMedida = await _context.UnidadesMedida
                .FirstOrDefaultAsync(m => m.ID == id);
            if (unidadMedida == null)
            {
                return NotFound();
            }

            return View(unidadMedida);
        }

        // GET: UnidadesMedida/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnidadesMedida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descripcion,Estado")] UnidadMedida unidadMedida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadMedida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidadMedida);
        }

        // GET: UnidadesMedida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadMedida = await _context.UnidadesMedida.FindAsync(id);
            if (unidadMedida == null)
            {
                return NotFound();
            }
            return View(unidadMedida);
        }

        // POST: UnidadesMedida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descripcion,Estado")] UnidadMedida unidadMedida)
        {
            if (id != unidadMedida.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadMedida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadMedidaExists(unidadMedida.ID))
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
            return View(unidadMedida);
        }

        // GET: UnidadesMedida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadMedida = await _context.UnidadesMedida
                .FirstOrDefaultAsync(m => m.ID == id);
            if (unidadMedida == null)
            {
                return NotFound();
            }

            return View(unidadMedida);
        }

        // POST: UnidadesMedida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidadMedida = await _context.UnidadesMedida.FindAsync(id);
            if (unidadMedida != null)
            {
                _context.UnidadesMedida.Remove(unidadMedida);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadMedidaExists(int id)
        {
            return _context.UnidadesMedida.Any(e => e.ID == id);
        }
    }
}
