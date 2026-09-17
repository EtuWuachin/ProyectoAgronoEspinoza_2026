using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoAgroEspinosa_2026.Models;
using ProyectoAgroEspinosa_2026.Data;
using Microsoft.EntityFrameworkCore;

namespace ProyectoAgroEspinosa_2026.Controllers
{
    [Authorize]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class T_AdmTTController : Controller
    {
        private readonly AppDbContext _context;

        public T_AdmTTController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            List<T_AdmTT> lista = await _context.Administraciones
                .Include(a => a.trabajador)
                .Include(a => a.inventario)
                .Include(a => a.metodopago)
                .Include(a => a.reporte)
                .Include(a => a.recursosadministrador)
                .ToListAsync();
            return View(lista);
        }
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Nuevo()
        {
            CargarViewBags();
            return View();
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> Nuevo(T_AdmTT administracion)
        {
            await _context.Administraciones.AddAsync(administracion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            T_AdmTT administracion = await _context.Administraciones
                .Include(a => a.trabajador)
                .Include(a => a.inventario)
                .Include(a => a.metodopago)
                .Include(a => a.reporte)
                .Include(a => a.recursosadministrador)
                .FirstAsync(a => a.IdAdministracion == id);
            CargarViewBags();
            return View(administracion);
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> Editar(T_AdmTT administracion)
        {
            _context.Administraciones.Update(administracion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            T_AdmTT administracion = await _context.Administraciones
                .FirstAsync(a => a.IdAdministracion == id);
            _context.Administraciones.Remove(administracion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }
        private void CargarViewBags()
        {
            ViewBag.Trabajadores = _context.Trabajadores.ToList();
            ViewBag.Inventarios = _context.Inventarios.ToList();
            ViewBag.MetodosPago = _context.MetodosPagos.ToList();
            ViewBag.Reportes = _context.Reportes.ToList();
            ViewBag.RecursosAdmin = _context.RecursosAdministradores.ToList();
        }
    }
}
