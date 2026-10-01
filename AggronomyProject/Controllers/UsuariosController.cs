using AggronomyProject.Data;
using AggronomyProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AggronomyProject.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UsuariosController(ApplicationDbContext db) : Controller
    {
        private readonly PasswordHasher<Usuario> _hasher = new();

        public async Task<IActionResult> Index(string? q)
        {
            var query = db.Usuarios.AsNoTracking().Include(u => u.Rol).AsQueryable();
            if (!string.IsNullOrWhiteSpace(q))
                query = query.Where(u => u.NombreUsuario.Contains(q) || u.CorreoElectronico.Contains(q));
            ViewData["q"] = q;
            return View(await query.OrderBy(u => u.NombreUsuario).ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            await CargarRoles();
            return View(new Usuario { Estado = true });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario m)
        {
            if (await db.Usuarios.AnyAsync(u => u.NombreUsuario == m.NombreUsuario))
                ModelState.AddModelError(nameof(m.NombreUsuario), "Ese nombre de usuario ya existe.");
            if (await db.Usuarios.AnyAsync(u => u.CorreoElectronico == m.CorreoElectronico))
                ModelState.AddModelError(nameof(m.CorreoElectronico), "Ese correo ya está registrado.");
            if (!string.IsNullOrEmpty(m.Contrasena) && m.Contrasena.Length < 6)
                ModelState.AddModelError(nameof(m.Contrasena), "La contraseña debe tener al menos 6 caracteres.");

            if (!ModelState.IsValid)
            {
                await CargarRoles(m.IdRol);
                return View(m);
            }
            m.Contrasena = _hasher.HashPassword(m, m.Contrasena);
            db.Add(m);
            await db.SaveChangesAsync();
            TempData["Success"] = "Usuario creado.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var m = await db.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.IdUsuario == id);
            if (m == null) return NotFound();
            m.Contrasena = string.Empty; // nunca se muestra el hash
            await CargarRoles(m.IdRol);
            return View(m);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario m)
        {
            if (id != m.IdUsuario) return NotFound();

            // La contraseña es opcional al editar: si viene vacía se conserva la actual
            var cambiaPassword = !string.IsNullOrWhiteSpace(m.Contrasena);
            if (!cambiaPassword) ModelState.Remove(nameof(m.Contrasena));
            else if (m.Contrasena.Length < 6)
                ModelState.AddModelError(nameof(m.Contrasena), "La contraseña debe tener al menos 6 caracteres.");

            if (await db.Usuarios.AnyAsync(u => u.NombreUsuario == m.NombreUsuario && u.IdUsuario != id))
                ModelState.AddModelError(nameof(m.NombreUsuario), "Ese nombre de usuario ya existe.");
            if (await db.Usuarios.AnyAsync(u => u.CorreoElectronico == m.CorreoElectronico && u.IdUsuario != id))
                ModelState.AddModelError(nameof(m.CorreoElectronico), "Ese correo ya está registrado.");

            if (!ModelState.IsValid)
            {
                await CargarRoles(m.IdRol);
                return View(m);
            }

            var actual = await db.Usuarios.FindAsync(id);
            if (actual == null) return NotFound();

            actual.NombreUsuario = m.NombreUsuario;
            actual.CorreoElectronico = m.CorreoElectronico;
            actual.IdRol = m.IdRol;
            actual.Estado = m.Estado;
            if (cambiaPassword) actual.Contrasena = _hasher.HashPassword(actual, m.Contrasena);

            await db.SaveChangesAsync();
            TempData["Success"] = "Usuario actualizado.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id)
        {
            var m = await db.Usuarios.FindAsync(id);
            if (m == null) return NotFound();

            if (m.NombreUsuario == User.Identity?.Name)
            {
                TempData["Error"] = "No puede desactivar su propia cuenta.";
                return RedirectToAction(nameof(Index));
            }
            m.Estado = !m.Estado;
            await db.SaveChangesAsync();
            TempData["Success"] = m.Estado ? "Usuario activado." : "Usuario desactivado.";
            return RedirectToAction(nameof(Index));
        }

        // Configuración de roles: lista de roles con su cantidad de usuarios
        public async Task<IActionResult> Roles()
        {
            var roles = await db.Roles.AsNoTracking().OrderBy(r => r.NombreRol).ToListAsync();
            ViewBag.Conteo = await db.Usuarios.AsNoTracking()
                .GroupBy(u => u.IdRol)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
            return View(roles);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearRol(string nombreRol)
        {
            nombreRol = (nombreRol ?? string.Empty).Trim();
            if (nombreRol.Length == 0 || nombreRol.Length > 50)
                TempData["Error"] = "El nombre del rol es inválido.";
            else if (await db.Roles.AnyAsync(r => r.NombreRol == nombreRol))
                TempData["Error"] = "Ese rol ya existe.";
            else
            {
                db.Roles.Add(new Rol { NombreRol = nombreRol, Estado = true });
                await db.SaveChangesAsync();
                TempData["Success"] = "Rol creado.";
            }
            return RedirectToAction(nameof(Roles));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstadoRol(int id)
        {
            var r = await db.Roles.FindAsync(id);
            if (r == null) return NotFound();
            if (r.NombreRol == "Administrador")
            {
                TempData["Error"] = "El rol Administrador no se puede desactivar.";
                return RedirectToAction(nameof(Roles));
            }
            r.Estado = !r.Estado;
            await db.SaveChangesAsync();
            TempData["Success"] = r.Estado ? "Rol activado." : "Rol desactivado.";
            return RedirectToAction(nameof(Roles));
        }

        private async Task CargarRoles(int? seleccionado = null)
        {
            ViewBag.IdRol = new SelectList(
                await db.Roles.AsNoTracking().Where(r => r.Estado).OrderBy(r => r.NombreRol).ToListAsync(),
                "IdRol", "NombreRol", seleccionado);
        }
    }
}
