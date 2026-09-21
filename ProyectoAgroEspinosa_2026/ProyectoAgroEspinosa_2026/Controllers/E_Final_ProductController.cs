using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAgroEspinosa_2026.Data;
using ProyectoAgroEspinosa_2026.Models;

namespace ProyectoAgroEspinosa_2026.Controllers
{
    [Authorize]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class E_Final_ProductController : Controller
    {
        private readonly AppDbContext _context;

        public E_Final_ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            List<E_Final_Product> lista = await _context.ProductosFinales
                .ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(E_Final_Product productoFinal)
        {
            await _context.ProductosFinales.AddAsync(productoFinal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            E_Final_Product productoFinal = await _context.ProductosFinales
                .FirstAsync(p => p.idProductoFinal == id);
            return View(productoFinal);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(E_Final_Product productoFinal)
        {
            _context.ProductosFinales.Update(productoFinal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            E_Final_Product productoFinal = await _context.ProductosFinales
                .FirstAsync(p => p.idProductoFinal == id);
            _context.ProductosFinales.Remove(productoFinal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }
    }
}