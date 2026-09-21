using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAgroEspinosa_2026.Data;
using ProyectoAgroEspinosa_2026.Models;

namespace ProyectoAgroEspinosa_2026.Controllers
{
    [Authorize]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class PagoController : Controller
    {
        private readonly AppDbContext _context;

        public PagoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            List<Pago> lista = await _context.Pagos.Include(p => p.metodopago).ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(Pago pago)
        {
            await _context.Pagos.AddAsync(pago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Pago pago = await _context.Pagos.FirstAsync(p => p.IdPago == id);
            return View(pago);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Pago pago)
        {
            _context.Pagos.Update(pago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Pago pago = await _context.Pagos.FirstAsync(p => p.IdPago == id);
            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }
    }
}
