using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAgroEspinosa_2026.Data;
using ProyectoAgroEspinosa_2026.Models;

namespace ProyectoAgroEspinosa_2026.Controllers
{
    [Authorize]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class M_PaymentmethodController : Controller
    {
        private readonly AppDbContext _context;

        public M_PaymentmethodController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            List<M_Paymentmethod> lista = await _context.MetodosPagos
                .Include(m => m.pagos)
                .ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(M_Paymentmethod metodoPago)
        {
            await _context.MetodosPagos.AddAsync(metodoPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            M_Paymentmethod metodoPago = await _context.MetodosPagos
                .FirstAsync(m => m.IdMetodoPago == id);
            return View(metodoPago);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(M_Paymentmethod metodoPago)
        {
            _context.MetodosPagos.Update(metodoPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            M_Paymentmethod metodoPago = await _context.MetodosPagos
                .FirstAsync(m => m.IdMetodoPago == id);
            _context.MetodosPagos.Remove(metodoPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }
    }
}