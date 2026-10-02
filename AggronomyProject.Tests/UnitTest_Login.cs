using Microsoft.VisualStudio.TestTools.UnitTesting;
using AggronomyProject.Models;
using System;

namespace AggronomyProject.Tests
{
    [TestClass]
    public class UnitTest_Usuario
    {
        [TestMethod]
        public void ValidarDatosUsuarioAdmin()
        {
            // 1. Preparación (Arrange)
            // Usamos exactamente los mismos datos de tu ApplicationDbContext
            int idEsperado = 1;
            string nombreEsperado = "admin";
            string correoEsperado = "admin@agronomia.com";
            string contrasenaEsperada = "Admin123";
            bool estadoEsperado = true;
            int idRolEsperado = 1;

            // 2. Ejecución (Act)
            // Creamos el objeto y le asignamos los valores
            Usuario u = new Usuario();
            u.IdUsuario = idEsperado;
            u.NombreUsuario = nombreEsperado;
            u.CorreoElectronico = correoEsperado;
            u.Contrasena = contrasenaEsperada;
            u.Estado = estadoEsperado;
            u.IdRol = idRolEsperado;

            // 3. Afirmación (Assert)
            // Comprobamos que el objeto tiene los datos correctos
            Assert.AreEqual("admin", u.NombreUsuario);
            Assert.AreEqual("admin@agronomia.com", u.CorreoElectronico);
            Assert.AreEqual("Admin123", u.Contrasena);
            Assert.AreEqual(1, u.IdRol);
            Assert.IsTrue(u.Estado);
        }
    }
}
