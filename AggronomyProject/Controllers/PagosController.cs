using AggronomyProject.Data;
using AggronomyProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AggronomyProject.Controllers
{
    [Authorize]
    public class PagosController(ApplicationDbContext db) : Controller
    {
        public async Task<IActionResult> Index(DateTime? desde, DateTime? hasta)
        {
            var query = db.Pagos.AsNoTracking().Include(p => p.metodopago).AsQueryable();
            if (desde != null) query = query.Where(p => p.fecha_pago >= desde);
            if (hasta != null) query = query.Where(p => p.fecha_pago <= hasta);

            var lista = await query.OrderByDescending(p => p.fecha_pago).ToListAsync();
            ViewData["desde"] = desde?.ToString("yyyy-MM-dd");
            ViewData["hasta"] = hasta?.ToString("yyyy-MM-dd");
            ViewData["total"] = lista.Where(p => p.estado).Sum(p => p.monto);
            return View(lista);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var m = await db.Pagos.Include(p => p.metodopago)
                .FirstOrDefaultAsync(p => p.IdPago == id);
            return m == null ? NotFound() : View(m);
        }

        public IActionResult Create() => View(new Pago { estado = true, fecha_pago = DateTime.Today });

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pago m)
        {
            if (m.monto <= 0)
                ModelState.AddModelError(nameof(m.monto), "El monto debe ser mayor a cero.");
            if (await db.Pagos.AnyAsync(p => p.comprobante == m.comprobante))
                ModelState.AddModelError(nameof(m.comprobante), "Este comprobante ya fue registrado.");
            if (!ModelState.IsValid) return View(m);

            db.Add(m);
            await db.SaveChangesAsync();
            TempData["Success"] = "Pago registrado.";
            return RedirectToAction(nameof(Details), new { id = m.IdPago });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id)
        {
            var m = await db.Pagos.FindAsync(id);
            if (m == null) return NotFound();
            m.estado = !m.estado;
            await db.SaveChangesAsync();
            TempData["Success"] = m.estado ? "Pago reactivado." : "Pago anulado.";
            return RedirectToAction(nameof(Index));
        }
    }
}
