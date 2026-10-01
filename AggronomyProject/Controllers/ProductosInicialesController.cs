using AggronomyProject.Data;
using AggronomyProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AggronomyProject.Controllers
{
    [Authorize]
    public class ProductosInicialesController(ApplicationDbContext db) : Controller
    {
        public async Task<IActionResult> Index(string? q)
        {
            var query = db.ProductosIniciales.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(q))
                query = query.Where(p => p.nombre.Contains(q) || p.proveedor_origen.Contains(q));
            ViewData["q"] = q;
            return View(await query.OrderBy(p => p.nombre).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var m = await db.ProductosIniciales.Include(p => p.inventario)
                .FirstOrDefaultAsync(p => p.id_producto_inicial == id);
            return m == null ? NotFound() : View(m);
        }

        public IActionResult Create() => View(new ProductoInicial { estado = true, fecha_ingreso = DateTime.Today });

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoInicial m)
        {
            if (!ModelState.IsValid) return View(m);
            db.Add(m);
            await db.SaveChangesAsync();
            TempData["Success"] = "Insumo registrado correctamente.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var m = await db.ProductosIniciales.FindAsync(id);
            return m == null ? NotFound() : View(m);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductoInicial m)
        {
            if (id != m.id_producto_inicial) return NotFound();
            if (!ModelState.IsValid) return View(m);
            db.Update(m);
            await db.SaveChangesAsync();
            TempData["Success"] = "Insumo actualizado.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id)
        {
            var m = await db.ProductosIniciales.FindAsync(id);
            if (m == null) return NotFound();
            m.estado = !m.estado;
            await db.SaveChangesAsync();
            TempData["Success"] = m.estado ? "Insumo activado." : "Insumo desactivado.";
            return RedirectToAction(nameof(Index));
        }
    }
}
