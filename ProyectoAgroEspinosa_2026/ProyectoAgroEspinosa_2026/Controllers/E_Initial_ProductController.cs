using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAgroEspinosa_2026.Data;
using ProyectoAgroEspinosa_2026.Models;

namespace ProyectoAgroEspinosa_2026.Controllers
{
    [Authorize]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class E_Initial_ProductController : Controller
    {
        private readonly AppDbContext _context;

        public E_Initial_ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            List<E_Initial_Product> lista = await _context.ProductosIniciales
                .ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(E_Initial_Product productoInicial)
        {
            await _context.ProductosIniciales.AddAsync(productoInicial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            E_Initial_Product productoInicial = await _context.ProductosIniciales
                .FirstAsync(p => p.idProductoInicial == id);
            return View(productoInicial);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(E_Initial_Product productoInicial)
        {
            _context.ProductosIniciales.Update(productoInicial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            E_Initial_Product productoInicial = await _context.ProductosIniciales
                .FirstAsync(p => p.idProductoInicial == id);
            _context.ProductosIniciales.Remove(productoInicial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }
    }
}