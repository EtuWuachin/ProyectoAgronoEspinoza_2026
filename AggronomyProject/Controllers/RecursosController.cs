using AggronomyProject.Data;
using AggronomyProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AggronomyProject.Controllers
{
    [Authorize]
    public class RecursosController(ApplicationDbContext db) : Controller
    {
        public async Task<IActionResult> Index(int? proveedorId)
        {
            var query = db.Recursos.AsNoTracking().Include(r => r.proveedor).AsQueryable();
            if (proveedorId != null) query = query.Where(r => r.id_proveedor == proveedorId);

            ViewBag.Proveedores = new SelectList(
                await db.Proveedores.AsNoTracking().OrderBy(p => p.nombre).ToListAsync(),
                "id_proveedor", "nombre", proveedorId);

            return View(await query.OrderByDescending(r => r.fecha_ingreso).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var m = await db.Recursos
                .Include(r => r.proveedor)
                .Include(r => r.recursosadministrador)
                .FirstOrDefaultAsync(r => r.id_recurso == id);
            return m == null ? NotFound() : View(m);
        }

        public async Task<IActionResult> Create()
        {
            await CargarProveedores();
            return View(new Recurso { estado = true, fecha_ingreso = DateTime.Today });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recurso m)
        {
            if (m.cantidad_recibida <= 0)
                ModelState.AddModelError(nameof(m.cantidad_recibida), "La cantidad debe ser mayor a cero.");
            if (m.costo_recurso < 0)
                ModelState.AddModelError(nameof(m.costo_recurso), "El costo no puede ser negativo.");

            if (!ModelState.IsValid)
            {
                await CargarProveedores(m.id_proveedor);
                return View(m);
            }
            db.Add(m);
            await db.SaveChangesAsync();
            TempData["Success"] = "Recurso registrado.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id)
        {
            var m = await db.Recursos.FindAsync(id);
            if (m == null) return NotFound();
            m.estado = !m.estado;
            await db.SaveChangesAsync();
            TempData["Success"] = m.estado ? "Recurso activado." : "Recurso desactivado.";
            return RedirectToAction(nameof(Index));
        }

        private async Task CargarProveedores(int? seleccionado = null)
        {
            ViewBag.id_proveedor = new SelectList(
                await db.Proveedores.Where(p => p.estado).OrderBy(p => p.nombre).ToListAsync(),
                "id_proveedor", "nombre", seleccionado);
        }
    }
}
