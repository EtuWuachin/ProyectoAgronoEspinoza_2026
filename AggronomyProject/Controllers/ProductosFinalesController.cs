using AggronomyProject.Data;
using AggronomyProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AggronomyProject.Controllers
{
    [Authorize]
    public class ProductosFinalesController(ApplicationDbContext db) : Controller
    {
        public async Task<IActionResult> Index(string? q)
        {
            var query = db.ProductosFinales.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(q))
                query = query.Where(p => p.nombre.Contains(q) || p.descripcion.Contains(q));
            ViewData["q"] = q;
            return View(await query.OrderBy(p => p.nombre).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var m = await db.ProductosFinales.Include(p => p.inventario)
                .FirstOrDefaultAsync(p => p.id_producto_final == id);
            return m == null ? NotFound() : View(m);
        }

        public IActionResult Create() => View(new ProductoFinal { estado = true });

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoFinal m)
        {
            if (!ModelState.IsValid) return View(m);
            db.Add(m);
            await db.SaveChangesAsync();
            TempData["Success"] = "Cosecha registrada correctamente.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var m = await db.ProductosFinales.FindAsync(id);
            return m == null ? NotFound() : View(m);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductoFinal m)
        {
            if (id != m.id_producto_final) return NotFound();
            if (!ModelState.IsValid) return View(m);
            db.Update(m);
            await db.SaveChangesAsync();
            TempData["Success"] = "Producto final actualizado.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id)
        {
            var m = await db.ProductosFinales.FindAsync(id);
            if (m == null) return NotFound();
            m.estado = !m.estado;
            await db.SaveChangesAsync();
            TempData["Success"] = m.estado ? "Producto activado." : "Producto desactivado.";
            return RedirectToAction(nameof(Index));
        }
    }
}
