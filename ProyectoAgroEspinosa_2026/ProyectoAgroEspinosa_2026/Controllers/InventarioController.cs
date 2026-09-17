using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAgroEspinosa_2026.Data;
using ProyectoAgroEspinosa_2026.Models;

namespace ProyectoAgroEspinosa_2026.Controllers
{
    [Authorize]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class InventarioController : Controller
    {
        private readonly AppDbContext _context;

        public InventarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            List<Inventario> lista = await _context.Inventarios
                .Include(i => i.productoinicial)
                .Include(i => i.productofinal)
                .ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            CargarViewBags();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(Inventario inventario)
        {
            await _context.Inventarios.AddAsync(inventario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Inventario inventario = await _context.Inventarios
                .Include(i => i.productoinicial)
                .Include(i => i.productofinal)
                .FirstAsync(i => i.id_iventario == id);
            CargarViewBags();
            return View(inventario);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Inventario inventario)
        {
            _context.Inventarios.Update(inventario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Inventario inventario = await _context.Inventarios
                .FirstAsync(i => i.id_iventario == id);
            _context.Inventarios.Remove(inventario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        private void CargarViewBags()
        {
            ViewBag.ProductosIniciales = _context.ProductosIniciales.ToList();
            ViewBag.ProductosFinales = _context.ProductosFinales.ToList();
        }
    }
}
