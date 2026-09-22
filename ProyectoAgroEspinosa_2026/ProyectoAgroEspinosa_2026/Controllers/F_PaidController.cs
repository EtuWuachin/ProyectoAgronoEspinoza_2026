using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAgroEspinosa_2026.Data;
using ProyectoAgroEspinosa_2026.Models;

namespace ProyectoAgroEspinosa_2026.Controllers
{
    [Authorize]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class F_PaidController : Controller
    {
        private readonly AppDbContext _context;

        public F_PaidController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            List<F_Paid> lista = await _context.Pagos
                .Include(p => p.metodopago)
                .ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            ViewBag.MetodosPago = _context.MetodosPagos.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(F_Paid pago)
        {
            await _context.Pagos.AddAsync(pago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            F_Paid pago = await _context.Pagos
                .Include(p => p.metodopago)
                .FirstAsync(p => p.IdPago == id);
            ViewBag.MetodosPago = _context.MetodosPagos.ToList();
            return View(pago);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(F_Paid pago)
        {
            _context.Pagos.Update(pago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            F_Paid pago = await _context.Pagos
                .FirstAsync(p => p.IdPago == id);
            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }
    }
}