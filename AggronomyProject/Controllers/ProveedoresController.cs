using AggronomyProject.Data;
using AggronomyProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AggronomyProject.Controllers
{
    [Authorize]
    public class ProveedoresController(ApplicationDbContext db) : Controller
    {
        public async Task<IActionResult> Index(string? q)
        {
            var query = db.Proveedores.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(q))
                query = query.Where(p => p.nombre.Contains(q) || p.ruc.Contains(q));
            ViewData["q"] = q;
            return View(await query.OrderBy(p => p.nombre).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var m = await db.Proveedores.Include(p => p.recurso)
                .FirstOrDefaultAsync(p => p.id_proveedor == id);
            return m == null ? NotFound() : View(m);
        }

        public IActionResult Create() => View(new Proveedor { estado = true });

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Proveedor m)
        {
            if (await db.Proveedores.AnyAsync(p => p.ruc == m.ruc))
                ModelState.AddModelError(nameof(m.ruc), "Ya existe un proveedor con este RUC.");
            if (!ModelState.IsValid) return View(m);

            db.Add(m);
            await db.SaveChangesAsync();
            TempData["Success"] = "Proveedor registrado.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var m = await db.Proveedores.FindAsync(id);
            return m == null ? NotFound() : View(m);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Proveedor m)
        {
            if (id != m.id_proveedor) return NotFound();
            if (await db.Proveedores.AnyAsync(p => p.ruc == m.ruc && p.id_proveedor != id))
                ModelState.AddModelError(nameof(m.ruc), "Ya existe otro proveedor con este RUC.");
            if (!ModelState.IsValid) return View(m);

            db.Update(m);
            await db.SaveChangesAsync();
            TempData["Success"] = "Proveedor actualizado.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id)
        {
            var m = await db.Proveedores.FindAsync(id);
            if (m == null) return NotFound();
            m.estado = !m.estado;
            await db.SaveChangesAsync();
            TempData["Success"] = m.estado ? "Proveedor activado." : "Proveedor desactivado.";
            return RedirectToAction(nameof(Index));
        }
    }
}
