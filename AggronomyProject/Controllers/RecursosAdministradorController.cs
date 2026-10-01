using AggronomyProject.Data;
using AggronomyProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AggronomyProject.Controllers
{
    [Authorize]
    public class RecursosAdministradorController(ApplicationDbContext db) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var lista = await db.RecursosAdministradores.AsNoTracking()
                .Include(ra => ra.recurso).ThenInclude(r => r.proveedor)
                .OrderByDescending(ra => ra.fecha_recepcion)
                .ToListAsync();
            return View(lista);
        }

        public async Task<IActionResult> Create()
        {
            await CargarRecursos();
            return View(new RecursosAdministrador { estado = true, fecha_recepcion = DateTime.Today });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecursosAdministrador m)
        {
            if (m.cantidad_recibida < 0)
                ModelState.AddModelError(nameof(m.cantidad_recibida), "La cantidad no puede ser negativa.");

            if (!ModelState.IsValid)
            {
                await CargarRecursos(m.id_recurso);
                return View(m);
            }
            db.Add(m);
            await db.SaveChangesAsync();
            TempData["Success"] = "Acta de recepción registrada.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id)
        {
            var m = await db.RecursosAdministradores.FindAsync(id);
            if (m == null) return NotFound();
            m.estado = !m.estado;
            await db.SaveChangesAsync();
            TempData["Success"] = m.estado ? "Registro activado." : "Registro anulado.";
            return RedirectToAction(nameof(Index));
        }

        private async Task CargarRecursos(int? seleccionado = null)
        {
            var recursos = await db.Recursos.AsNoTracking()
                .Include(r => r.proveedor)
                .Where(r => r.estado)
                .OrderByDescending(r => r.fecha_ingreso)
                .Select(r => new
                {
                    r.id_recurso,
                    Texto = r.tipo_recurso + " - " + r.proveedor.nombre + " (" + r.cantidad_recibida + " " + r.unidad_medida + ")"
                })
                .ToListAsync();
            ViewBag.id_recurso = new SelectList(recursos, "id_recurso", "Texto", seleccionado);
        }
    }
}
