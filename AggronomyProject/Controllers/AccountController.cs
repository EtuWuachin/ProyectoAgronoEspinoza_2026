using System.Security.Claims;
using AggronomyProject.Data;
using AggronomyProject.Models;
using AggronomyProject.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AggronomyProject.Controllers
{
    [AllowAnonymous]
    public class AccountController(ApplicationDbContext db) : Controller
    {
        private readonly PasswordHasher<Usuario> _hasher = new();

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            if (User.Identity?.IsAuthenticated == true) return RedirectToAction("Index", "Home");
            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid) return View(vm);

            var id = vm.Identificador.Trim();
            var usuario = await db.Usuarios.Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.Estado &&
                    (u.NombreUsuario == id || u.CorreoElectronico == id));

            if (usuario == null || !await VerificarPasswordAsync(usuario, vm.Contrasena))
            {
                ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos.");
                return View(vm);
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                new(ClaimTypes.Name, usuario.NombreUsuario),
                new(ClaimTypes.Email, usuario.CorreoElectronico),
                new(ClaimTypes.Role, usuario.Rol.NombreRol)
            };

            // Se usa el esquema de Identity para que SignInManager.IsSignedIn(User) siga funcionando
            var identity = new ClaimsIdentity(claims, IdentityConstants.ApplicationScheme);
            await HttpContext.SignInAsync(
                IdentityConstants.ApplicationScheme,
                new ClaimsPrincipal(identity),
                new AuthenticationProperties { IsPersistent = vm.Recordarme });

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return LocalRedirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction(nameof(Login));
        }

        public IActionResult AccessDenied() => View();

        private async Task<bool> VerificarPasswordAsync(Usuario u, string password)
        {
            var result = _hasher.VerifyHashedPassword(u, u.Contrasena, password);
            if (result == PasswordVerificationResult.Success) return true;
            if (result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                u.Contrasena = _hasher.HashPassword(u, password);
                await db.SaveChangesAsync();
                return true;
            }

            // Compatibilidad con los usuarios semilla (texto plano): se migran a hash en el primer login
            if (u.Contrasena == password)
            {
                u.Contrasena = _hasher.HashPassword(u, password);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
