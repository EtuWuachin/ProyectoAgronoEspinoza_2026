using System.Diagnostics;
using AggronomyProject.Data;
using AggronomyProject.Models;
using AggronomyProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AggronomyProject.Controllers
{
    [Authorize]
    public class HomeController(ApplicationDbContext db) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var inicioMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            var vm = new DashboardViewModel
            {
                TotalProductosIniciales = await db.ProductosIniciales.CountAsync(p => p.estado),
                TotalProductosFinales = await db.ProductosFinales.CountAsync(p => p.estado),
                TotalTrabajadores = await db.Trabajadores.CountAsync(t => t.estado),
                TotalProveedores = await db.Proveedores.CountAsync(p => p.estado),
                TotalPagosMes = await db.Pagos
                    .Where(p => p.estado && p.fecha_pago >= inicioMes)
                    .SumAsync(p => (decimal?)p.monto) ?? 0m,
                AlertasStock = await db.Inventarios.AsNoTracking()
                    .Where(i => i.estado && i.stock_actual <= i.stock_minimo)
                    .OrderBy(i => i.stock_actual)
                    .Take(10).ToListAsync(),
                UltimosPagos = await db.Pagos.AsNoTracking()
                    .OrderByDescending(p => p.fecha_pago)
                    .Take(5).ToListAsync()
            };
            return View(vm);
        }

        [AllowAnonymous]
        public IActionResult Privacy() => View();

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
