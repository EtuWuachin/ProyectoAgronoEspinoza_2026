using AggronomyProject.Data;
using AggronomyProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AggronomyProject.Controllers
{
    [Authorize]
    public class TrabajadoresController(ApplicationDbContext db) : Controller
    {
        public async Task<IActionResult> Index(string? q, bool soloActivos = true)
        {
            var query = db.Trabajadores.AsNoTracking().AsQueryable();
            if (soloActivos) query = query.Where(t => t.estado);
            if (!string.IsNullOrWhiteSpace(q))
                query = query.Where(t => t.nombres.Contains(q) || t.apellidos.Contains(q)
                                      || t.dni.Contains(q) || t.cargo.Contains(q));
            ViewData["q"] = q;
            ViewData["soloActivos"] = soloActivos;
            return View(await query.OrderBy(t => t.apellidos).ThenBy(t => t.nombres).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var m = await db.Trabajadores.Include(t => t.administracion)
                .FirstOrDefaultAsync(t => t.id_trabajador == id);
            return m == null ? NotFound() : View(m);
        }

        public IActionResult Create() => View(new Trabajador { estado = true, fecha_contrato = DateTime.Today });

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trabajador m)
        {
            if (await db.Trabajadores.AnyAsync(t => t.dni == m.dni))
                ModelState.AddModelError(nameof(m.dni), "Ya existe un trabajador con este DNI.");
            if (!ModelState.IsValid) return View(m);

            db.Add(m);
            await db.SaveChangesAsync();
            TempData["Success"] = "Trabajador registrado.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var m = await db.Trabajadores.FindAsync(id);
            return m == null ? NotFound() : View(m);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Trabajador m)
        {
            if (id != m.id_trabajador) return NotFound();
            if (await db.Trabajadores.AnyAsync(t => t.dni == m.dni && t.id_trabajador != id))
                ModelState.AddModelError(nameof(m.dni), "Ya existe otro trabajador con este DNI.");
            if (!ModelState.IsValid) return View(m);

            db.Update(m);
            await db.SaveChangesAsync();
            TempData["Success"] = "Trabajador actualizado.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id)
        {
            var m = await db.Trabajadores.FindAsync(id);
            if (m == null) return NotFound();
            m.estado = !m.estado;
            await db.SaveChangesAsync();
            TempData["Success"] = m.estado ? "Trabajador activado." : "Trabajador dado de baja.";
            return RedirectToAction(nameof(Index));
        }
    }
}
