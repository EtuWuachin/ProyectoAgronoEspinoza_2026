using AggronomyProject.Data;
using AggronomyProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AggronomyProject.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AdministracionController(ApplicationDbContext db) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var lista = await db.Administraciones.AsNoTracking()
                .Include(a => a.reporte)
                .Include(a => a.trabajador)
                .Include(a => a.inventario)
                .Include(a => a.metodopago)
                .Include(a => a.recursosadministrador)
                .OrderByDescending(a => a.fecha_registro)
                .ToListAsync();
            return View(lista);
        }

        public async Task<IActionResult> Create()
        {
            await CargarListas();
            return View(new Administracion
            {
                estado = true,
                fecha_registro = DateTime.Today,
                responsable = User.Identity?.Name ?? string.Empty
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Administracion m)
        {
            if (!ModelState.IsValid)
            {
                await CargarListas(m);
                return View(m);
            }
            db.Add(m);
            await db.SaveChangesAsync();
            TempData["Success"] = "Operación administrativa registrada.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id)
        {
            var m = await db.Administraciones.FindAsync(id);
            if (m == null) return NotFound();
            m.estado = !m.estado;
            await db.SaveChangesAsync();
            TempData["Success"] = m.estado ? "Registro activado." : "Registro anulado.";
            return RedirectToAction(nameof(Index));
        }

        private async Task CargarListas(Administracion? m = null)
        {
            ViewBag.id_reporte = new SelectList(
                await db.Reportes.AsNoTracking().Where(r => r.estado).OrderByDescending(r => r.fecha_generacion).ToListAsync(),
                "id_reporte", "titulo", m?.id_reporte);

            var trabajadores = await db.Trabajadores.AsNoTracking().Where(t => t.estado)
                .OrderBy(t => t.apellidos)
                .Select(t => new { t.id_trabajador, Texto = t.apellidos + ", " + t.nombres })
                .ToListAsync();
            ViewBag.id_trabajador = new SelectList(trabajadores, "id_trabajador", "Texto", m?.id_trabajador);

            ViewBag.id_inventario = new SelectList(
                await db.Inventarios.AsNoTracking().Where(i => i.estado).OrderBy(i => i.nombre).ToListAsync(),
                "id_iventario", "nombre", m?.id_inventario);

            ViewBag.id_metodo_pago = new SelectList(
                await db.MetodosPagos.AsNoTracking().Where(mp => mp.estado).OrderBy(mp => mp.nombre).ToListAsync(),
                "IdMetodoPago", "nombre", m?.id_metodo_pago);

            var recursos = await db.RecursosAdministradores.AsNoTracking().Where(ra => ra.estado)
                .OrderByDescending(ra => ra.fecha_recepcion)
                .Select(ra => new { ra.id_recursos_administrador, Texto = "Acta #" + ra.id_recursos_administrador + " - " + ra.observaciones })
                .ToListAsync();
            ViewBag.id_recursos_administrador = new SelectList(recursos, "id_recursos_administrador", "Texto", m?.id_recursos_administrador);
        }
    }
}
