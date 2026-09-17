using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAgroEspinosa_2026.Data;
using ProyectoAgroEspinosa_2026.Models;

namespace ProyectoAgroEspinosa_2026.Controllers
{
    [Authorize]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class MetodoPagoController : Controller
    {
        private readonly AppDbContext _context;

        public MetodoPagoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            List<MetodoPago> lista = await _context.MetodosPagos
                .Include(m => m.pago)
                .ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            ViewBag.Pagos = _context.Pagos.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(MetodoPago metodoPago)
        {
            await _context.MetodosPagos.AddAsync(metodoPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            MetodoPago metodoPago = await _context.MetodosPagos
                .Include(m => m.pago)
                .FirstAsync(m => m.IdMetodoPago == id);
            ViewBag.Pagos = _context.Pagos.ToList();
            return View(metodoPago);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(MetodoPago metodoPago)
        {
            _context.MetodosPagos.Update(metodoPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            MetodoPago metodoPago = await _context.MetodosPagos
                .FirstAsync(m => m.IdMetodoPago == id);
            _context.MetodosPagos.Remove(metodoPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }
    }
}
