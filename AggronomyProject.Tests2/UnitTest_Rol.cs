using Microsoft.VisualStudio.TestTools.UnitTesting;
using AggronomyProject.Models;

namespace AggronomyProject.Tests
{
    [TestClass]
    public class UnitTest_Rol
    {
        // CASO DE PRUEBA 4: Validar la asignación de propiedades del Rol
        [TestMethod]
        public void ValidarDatosRol()
        {
            // 1. Preparación (Arrange)
            int idEsperado = 1;
            string nombreRolEsperado = "Administrador";
            bool estadoEsperado = true;

            // 2. Ejecución (Act)
            Rol r = new Rol();
            r.IdRol = idEsperado;
            r.NombreRol = nombreRolEsperado;
            r.Estado = estadoEsperado;

            // 3. Afirmación (Assert)
            Assert.AreEqual(idEsperado, r.IdRol);
            Assert.AreEqual(nombreRolEsperado, r.NombreRol);
            Assert.IsTrue(r.Estado);
        }
        // CASO DE PRUEBA 20: Validar Rol inhabilitado (Ej. Rol antiguo que ya no se usa)
        [TestMethod]
        public void ValidarRolInhabilitado()
        {
            Rol r = new Rol();
            r.NombreRol = "Visitante_Antiguo";
            r.Estado = false;

            Assert.AreEqual("Visitante_Antiguo", r.NombreRol);
            Assert.IsFalse(r.Estado);
        }
    }
}