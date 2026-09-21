using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAgroEspinosa_2026.Data;
using ProyectoAgroEspinosa_2026.Models;
using System.Security.Claims;

namespace ProyectoAgroEspinosa_2026.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var nombreRol = HttpContext.Session.GetString("UsuarioRol");
            if (nombreRol != null)
                return RedirectByRol(nombreRol);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string correo, string contrasena, string rolSeleccionado)
        {
            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contrasena))
            {
                ViewData["Mensaje"] = "Ingrese correo y contraseña.";
                return View();
            }

            M_UserTT? usuario = await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u =>
                    u.CorreoElectronico == correo &&
                    u.Contrasena == contrasena &&
                    u.Estado == true &&
                    u.Rol.NombreRol == rolSeleccionado);

            if (usuario == null)
            {
                ViewData["Mensaje"] = "No se encontraron usuarios o el rol es incorrecto.";
                return View();
            }

            if (!usuario.Rol.Estado)
            {
                ViewData["Mensaje"] = "Su rol se encuentra inactivo. Contacte al administrador.";
                return View();
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                new Claim(ClaimTypes.Email, usuario.CorreoElectronico),
                new Claim(ClaimTypes.Role, usuario.Rol.NombreRol),
                new Claim("IdUsuario", usuario.IdUsuario.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties);

            // Sesiones
            HttpContext.Session.SetInt32("UsuarioId", usuario.IdUsuario);
            HttpContext.Session.SetString("UsuarioNombre", usuario.NombreUsuario);
            HttpContext.Session.SetString("UsuarioCorreo", usuario.CorreoElectronico);
            HttpContext.Session.SetString("UsuarioRol", usuario.Rol.NombreRol);
            HttpContext.Session.SetInt32("RolId", usuario.IdRol);

            return RedirectByRol(usuario.Rol.NombreRol);
        }

        [HttpGet]
        public IActionResult AccesoDenegado()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

        private IActionResult RedirectByRol(string rol)
        {
            switch (rol)
            {
                case "Administrador":
                    return RedirectToAction("Listar", "Administracion");

                case "Trabajador":
                    return RedirectToAction("Listar", "Inventario");

                default:
                    return RedirectToAction(nameof(Login));
            }
        }
    }
}