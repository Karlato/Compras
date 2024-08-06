using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Compras.Data;
using Compras.Models.Entities;
using System.Text;
using System.Xml.Linq;
using System.Diagnostics;

namespace Compras.Controllers
{
    public class AsientosContablesController : Controller
    {
        private readonly AppDbContext _context;

        public AsientosContablesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AsientosContables
        public async Task<IActionResult> Index()
        {
            return View(await _context.AsientosContables.ToListAsync());
        }


        // GET: AsientosContables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientoContable = await _context.AsientosContables
                .FirstOrDefaultAsync(m => m.ID == id);
            if (asientoContable == null)
            {
                return NotFound();
            }

            return View(asientoContable);
        }

        // GET: AsientosContables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AsientosContables/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FechaInicio,FechaFin,IdCuenta,Descripcion,CuentaDB,CuentaCR")] AsientoContable asientoContable)
        {
            if (ModelState.IsValid)
            {
                var montoTotal = await _context.Ordenes
                    .Where(o => o.FechaOrden >= asientoContable.FechaInicio && o.FechaOrden <= asientoContable.FechaFin)
                    .SumAsync(o => (double?)(o.CostoUnitario * o.Cantidad)) ?? 0.0;

                asientoContable.Monto = montoTotal;
                asientoContable.Descripcion = $"Asiento de Compras correspondiente al periodo {asientoContable.FechaInicio:yyyy-MM}";

                _context.Add(asientoContable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asientoContable);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contabilizar(int id)
        {
            var asientoContable = await _context.AsientosContables.FindAsync(id);
            if (asientoContable == null)
            {
                return NotFound();
            }

            var success = await CallWebService(asientoContable);

            if (success)
            {
                asientoContable.Estado = "Contabilizado";
                _context.Update(asientoContable);
                await _context.SaveChangesAsync();

                Debug.WriteLine($"AsientoContable with ID {asientoContable.ID} has been updated.");
            }
            else
            {
                Debug.WriteLine($"AsientoContable with ID {asientoContable.ID} could not be updated.");
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CallWebService(AsientoContable asientoContable)
        {
            var soapEnvelope = $@"
        <soap:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'>
          <soap:Body>
            <AsientoContable xmlns='http://tempuri.org/'>
              <idAuxiliarOrigen>{asientoContable.IdAuxiliarOrigen}</idAuxiliarOrigen>
              <descripcion>{asientoContable.Descripcion}</descripcion>
              <cuentaDB>{asientoContable.CuentaDB}</cuentaDB>
              <cuentaCR>{asientoContable.CuentaCR}</cuentaCR>
              <monto>{asientoContable.Monto}</monto>
            </AsientoContable>
          </soap:Body>
        </soap:Envelope>";

            var httpContent = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("SOAPAction", "http://tempuri.org/AsientoContable");
            var response = await client.PostAsync("http://www.contabilidadws.somee.com/SSWS.asmx", httpContent);

            if (response.IsSuccessStatusCode)
            {
                var responseXml = await response.Content.ReadAsStringAsync();
                var xdoc = XDocument.Parse(responseXml);
                var ns = xdoc.Root.GetDefaultNamespace();

                asientoContable.Fecha = DateTime.Parse(xdoc.Descendants(ns + "Fecha").FirstOrDefault()?.Value);
                asientoContable.Estado = xdoc.Descendants(ns + "Estado").FirstOrDefault()?.Value;

                return true;
            }

            return false;
        }

    // GET: AsientosContables/Edit/5
    public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientoContable = await _context.AsientosContables.FindAsync(id);
            if (asientoContable == null)
            {
                return NotFound();
            }
            return View(asientoContable);
        }

        // GET: AsientosContables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientoContable = await _context.AsientosContables
                .FirstOrDefaultAsync(m => m.ID == id);
            if (asientoContable == null)
            {
                return NotFound();
            }

            return View(asientoContable);
        }

        // POST: AsientosContables/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asientoContable = await _context.AsientosContables.FindAsync(id);
            if (asientoContable != null)
            {
                _context.AsientosContables.Remove(asientoContable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsientoContableExists(int id)
        {
            return _context.AsientosContables.Any(e => e.ID == id);
        }
    }
}
