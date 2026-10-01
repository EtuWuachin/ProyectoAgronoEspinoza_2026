using AggronomyProject.Data;
using AggronomyProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AggronomyProject.Controllers
{
    [Authorize]
    public class MetodosPagoController(ApplicationDbContext db) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var lista = await db.MetodosPagos.AsNoTracking()
                .Include(mp => mp.pago)
                .OrderBy(mp => mp.nombre)
                .ToListAsync();
            return View(lista);
        }

        public async Task<IActionResult> Create()
        {
            await CargarPagos();
            return View(new MetodoPago { estado = true });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MetodoPago m)
        {
            if (!ModelState.IsValid)
            {
                await CargarPagos(m.id_pago);
                return View(m);
            }
            db.Add(m);
            await db.SaveChangesAsync();
            TempData["Success"] = "Método de pago registrado.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id)
        {
            var m = await db.MetodosPagos.FindAsync(id);
            if (m == null) return NotFound();
            m.estado = !m.estado;
            await db.SaveChangesAsync();
            TempData["Success"] = m.estado ? "Método activado." : "Método desactivado.";
            return RedirectToAction(nameof(Index));
        }

        private async Task CargarPagos(int? seleccionado = null)
        {
            var pagos = await db.Pagos.AsNoTracking()
                .Where(p => p.estado)
                .OrderByDescending(p => p.fecha_pago)
                .Select(p => new { p.IdPago, Texto = p.comprobante + " - " + p.concepto })
                .ToListAsync();
            ViewBag.id_pago = new SelectList(pagos, "IdPago", "Texto", seleccionado);
        }
    }
}
