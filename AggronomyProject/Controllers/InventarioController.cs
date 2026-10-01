using AggronomyProject.Data;
using AggronomyProject.Models;
using AggronomyProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AggronomyProject.Controllers
{
    [Authorize]
    public class InventarioController(ApplicationDbContext db) : Controller
    {
        public async Task<IActionResult> Index(InventarioFilterViewModel filtro)
        {
            var query = db.Inventarios.AsNoTracking()
                .Include(i => i.productoinicial)
                .Include(i => i.productofinal)
                .AsQueryable();

            if (filtro.SoloActivos) query = query.Where(i => i.estado);
            if (filtro.SoloStockBajo) query = query.Where(i => i.stock_actual <= i.stock_minimo);
            if (!string.IsNullOrWhiteSpace(filtro.Busqueda))
                query = query.Where(i => i.nombre.Contains(filtro.Busqueda) || i.descripcion.Contains(filtro.Busqueda));

            filtro.Items = await query.OrderBy(i => i.nombre).ToListAsync();
            return View(filtro);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var m = await db.Inventarios
                .Include(i => i.productoinicial)
                .Include(i => i.productofinal)
                .Include(i => i.administracion)
                .FirstOrDefaultAsync(i => i.id_iventario == id);
            return m == null ? NotFound() : View(m);
        }

        public async Task<IActionResult> Create()
        {
            await CargarListas();
            return View(new Inventario { estado = true });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inventario m)
        {
            if (m.stock_minimo < 0 || m.stock_actual < 0)
                ModelState.AddModelError(string.Empty, "El stock no puede ser negativo.");

            if (!ModelState.IsValid)
            {
                await CargarListas(m);
                return View(m);
            }
            m.fecha_actualizacion = DateTime.Now;
            db.Add(m);
            await db.SaveChangesAsync();
            TempData["Success"] = "Artículo registrado en el inventario.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var m = await db.Inventarios.FindAsync(id);
            if (m == null) return NotFound();
            await CargarListas(m);
            return View(m);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Inventario m)
        {
            if (id != m.id_iventario) return NotFound();
            if (!ModelState.IsValid)
            {
                await CargarListas(m);
                return View(m);
            }
            m.fecha_actualizacion = DateTime.Now;
            db.Update(m);
            await db.SaveChangesAsync();
            TempData["Success"] = "Inventario actualizado.";
            return RedirectToAction(nameof(Index));
        }

        // Entradas / salidas rápidas desde el modal _AjusteStockModal
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AjusteStock(int id, int cantidad, string tipo)
        {
            var m = await db.Inventarios.FindAsync(id);
            if (m == null) return NotFound();

            if (cantidad <= 0)
            {
                TempData["Error"] = "La cantidad debe ser mayor a cero.";
                return RedirectToAction(nameof(Index));
            }

            if (tipo == "salida")
            {
                if (cantidad > m.stock_actual)
                {
                    TempData["Error"] = "La salida supera el stock disponible.";
                    return RedirectToAction(nameof(Index));
                }
                m.stock_actual -= cantidad;
            }
            else
            {
                m.stock_actual += cantidad;
            }

            m.fecha_actualizacion = DateTime.Now;
            await db.SaveChangesAsync();
            TempData["Success"] = $"Stock de '{m.nombre}' actualizado ({m.stock_actual} {m.unidad_medida}).";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id)
        {
            var m = await db.Inventarios.FindAsync(id);
            if (m == null) return NotFound();
            m.estado = !m.estado;
            await db.SaveChangesAsync();
            TempData["Success"] = m.estado ? "Artículo activado." : "Artículo desactivado.";
            return RedirectToAction(nameof(Index));
        }

        private async Task CargarListas(Inventario? m = null)
        {
            ViewBag.id_producto_inicial = new SelectList(
                await db.ProductosIniciales.Where(p => p.estado).OrderBy(p => p.nombre).ToListAsync(),
                "id_producto_inicial", "nombre", m?.id_producto_inicial);
            ViewBag.id_producto_final = new SelectList(
                await db.ProductosFinales.Where(p => p.estado).OrderBy(p => p.nombre).ToListAsync(),
                "id_producto_final", "nombre", m?.id_producto_final);
        }
    }
}
