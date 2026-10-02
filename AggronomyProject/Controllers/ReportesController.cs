using AggronomyProject.Data;
using AggronomyProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AggronomyProject.Controllers
{
    [Authorize]
    public class ReportesController(ApplicationDbContext db) : Controller
    {
        public async Task<IActionResult> Index(string? tipo)
        {
            var query = db.Reportes.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(tipo)) query = query.Where(r => r.tipo_reporte == tipo);

            ViewBag.Tipos = await db.Reportes.AsNoTracking()
                .Select(r => r.tipo_reporte).Distinct().OrderBy(t => t).ToListAsync();
            ViewData["tipo"] = tipo;
            return View(await query.OrderByDescending(r => r.fecha_generacion).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var m = await db.Reportes.FirstOrDefaultAsync(r => r.id_reporte == id);
            return m == null ? NotFound() : View(m);
        }

        public IActionResult Create() => View(new Reporte { estado = true });

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reporte m)
        {
            // Estos campos los define el servidor, no el formulario
            ModelState.Remove(nameof(m.fecha_generacion));
            ModelState.Remove(nameof(m.generado_por));
            m.fecha_generacion = DateTime.Now;
            m.generado_por = User.Identity?.Name ?? "Sistema";
            m.estado = true;

            if (!ModelState.IsValid) return View(m);

            db.Add(m);
            await db.SaveChangesAsync();
            TempData["Success"] = "Reporte generado.";
            return RedirectToAction(nameof(Details), new { id = m.id_reporte });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id)
        {
            var m = await db.Reportes.FindAsync(id);
            if (m == null) return NotFound();
            m.estado = !m.estado;
            await db.SaveChangesAsync();
            TempData["Success"] = m.estado ? "Reporte activado." : "Reporte archivado.";
            return RedirectToAction(nameof(Index));
        }
    }
}
