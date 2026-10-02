using Microsoft.VisualStudio.TestTools.UnitTesting;
using AggronomyProject.Models;

namespace AggronomyProject.Tests
{
    [TestClass]
    public class UnitTest_Login
    {
        [TestMethod]
        public void ValidarDatosUsuarioAdmin()
        {
            // 1. Preparación 
            int idEsperado = 1;
            string nombreEsperado = "admin";
            string correoEsperado = "admin@agronomia.com";
            string contrasenaEsperada = "Admin123";
            bool estadoEsperado = true;
            int idRolEsperado = 1;

            // 2. Ejecución 
            Usuario u = new Usuario();
            u.IdUsuario = idEsperado;
            u.NombreUsuario = nombreEsperado;
            u.CorreoElectronico = correoEsperado;
            u.Contrasena = contrasenaEsperada;
            u.Estado = estadoEsperado;
            u.IdRol = idRolEsperado;

            // 3. Afirmación 
            Assert.AreEqual("admin", u.NombreUsuario);
            Assert.AreEqual("admin@agronomia.com", u.CorreoElectronico);
            Assert.AreEqual("Admin123", u.Contrasena);
            Assert.AreEqual(1, u.IdRol);
            Assert.IsTrue(u.Estado);
        }

        // CASO DE PRUEBA 2: Validar asignación de datos del usuario Trabajador
        [TestMethod]
        public void ValidarDatosUsuarioTrabajador()
        {
            // 1. Preparación
            int idEsperado = 2;
            string nombreEsperado = "trabajador";
            string correoEsperado = "trabajador@agronomia.com";
            string contrasenaEsperada = "Trab123";
            bool estadoEsperado = true;
            int idRolEsperado = 2;

            // 2. Ejecución
            Usuario u = new Usuario();
            u.IdUsuario = idEsperado;
            u.NombreUsuario = nombreEsperado;
            u.CorreoElectronico = correoEsperado;
            u.Contrasena = contrasenaEsperada;
            u.Estado = estadoEsperado;
            u.IdRol = idRolEsperado;

            // 3. Afirmación
            Assert.AreEqual("trabajador", u.NombreUsuario);
            Assert.AreEqual("trabajador@agronomia.com", u.CorreoElectronico);
            Assert.AreEqual("Trab123", u.Contrasena);
            Assert.AreEqual(2, u.IdRol);
            Assert.IsTrue(u.Estado);
        }
        // CASO DE PRUEBA 15: Validar creación de Usuario Inactivo o suspendido
        [TestMethod]
        public void ValidarUsuarioInactivo()
        {
            Usuario u = new Usuario();
            u.NombreUsuario = "usuario_suspendido";
            u.Estado = false; // Estado inactivo

            Assert.AreEqual("usuario_suspendido", u.NombreUsuario);
            Assert.IsFalse(u.Estado); // Verifica específicamente que sea Falso
        }


    }
}