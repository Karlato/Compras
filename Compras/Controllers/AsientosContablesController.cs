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

        // GET: AsientosContables/Index
        public async Task<IActionResult> Index(DateTime? fechaInicio, DateTime? fechaFin)
        {
            var asientos = _context.AsientosContables.AsQueryable();

            if (fechaInicio.HasValue && fechaFin.HasValue)
            {
                asientos = asientos.Where(a => a.Fecha >= fechaInicio.Value && a.Fecha <= fechaFin.Value);
            }

            var model = await asientos.ToListAsync();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contabilizar(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaFin < fechaInicio)
            {
                TempData["Resultado"] = "La fecha de fin debe ser mayor o igual a la fecha de inicio.";
                return RedirectToAction("Index", new { fechaInicio, fechaFin });
            }

            try
            {
                decimal montoTotal = GetMontoTotal(fechaInicio, fechaFin);
                string descripcion = $"Asiento de Compras correspondiente al periodo {GetPeriodoActual(fechaInicio)}";
                string cuentaDB = "80";
                string cuentaCR = "4";
                string idAuxiliar = "7";

                string result = await CallWebService(idAuxiliar, descripcion, cuentaDB, cuentaCR, montoTotal);

                TempData["Resultado"] = $"Resultado del servicio: {result}";

                var asientoContable = new AsientoContable
                {
                    Fecha = DateTime.Now,
                    Descripcion = descripcion,
                    Monto = montoTotal,
                    Cuenta_DB = cuentaDB,
                    Cuenta_CR = cuentaCR,
                    IdAuxiliar = idAuxiliar
                };

                _context.AsientosContables.Add(asientoContable);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", new { fechaInicio, fechaFin });
            }
            catch (Exception ex)
            {
                TempData["Resultado"] = "Error al contabilizar: " + ex.Message;
                return RedirectToAction("Index", new { fechaInicio, fechaFin });
            }
        }

        private decimal GetMontoTotal(DateTime fechaInicio, DateTime fechaFin)
        {
            return _context.Ordenes
                .Where(o => o.FechaOrden >= fechaInicio && o.FechaOrden <= fechaFin)
                .Sum(o => o.CostoUnitario * o.Cantidad);
        }

        private string GetPeriodoActual(DateTime fechaInicio)
        {
            return fechaInicio.ToString("yyyy-MM");
        }


        private async Task<string> CallWebService(string idAuxiliar, string descripcion, string cuentaDB, string cuentaCR, decimal montoTotal)
        {
            var soapEnvelope = $@"
    <soap:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'>
        <soap:Body>
            <AsientoContable xmlns='http://tempuri.org/'>
                <idAuxiliarOrigen>{idAuxiliar}</idAuxiliarOrigen>
                <descripcion>{descripcion}</descripcion>
                <cuentaDB>{cuentaDB}</cuentaDB>
                <cuentaCR>{cuentaCR}</cuentaCR>
                <monto>{montoTotal}</monto>
            </AsientoContable>
        </soap:Body>
    </soap:Envelope>";

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("SOAPAction", "http://tempuri.org/AsientoContable");
            var httpContent = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");
            var response = await client.PostAsync("http://www.contabilidadws.somee.com/SSWS.asmx", httpContent);

            var responseString = await response.Content.ReadAsStringAsync();

            var xdoc = XDocument.Parse(responseString);
            var result = xdoc.Descendants(XName.Get("AsientoContableResult", "http://tempuri.org/")).FirstOrDefault()?.Value;

            return result;
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
        public async Task<IActionResult> Create(AsientoContable asientoContable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asientoContable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
        [HttpPost, ActionName("Delete")]
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
