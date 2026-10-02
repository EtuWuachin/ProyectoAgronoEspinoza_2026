using Microsoft.VisualStudio.TestTools.UnitTesting;
using AggronomyProject.Models;

namespace AggronomyProject.Tests
{
    [TestClass]
    public class UnitTest_Proveedor
    {
        // CASO DE PRUEBA 8: Validar la asignación de propiedades de Proveedor
        [TestMethod]
        public void ValidarDatosProveedor()
        {
            // 1. Preparación (Arrange)
            int idEsperado = 1;
            string nombreEsperado = "AgroInsumos S.A.";
            string rucEsperado = "20123456789";
            string direccionEsperada = "Av. Principal 123";
            string telefonoEsperado = "987654321";
            string emailEsperado = "ventas@agroinsumos.com";
            bool estadoEsperado = true;

            // 2. Ejecución (Act)
            // Asignamos los datos basándonos en las propiedades de Proveedor.cs
            Proveedor p = new Proveedor();
            p.id_proveedor = idEsperado;
            p.nombre = nombreEsperado;
            p.ruc = rucEsperado;
            p.direccion = direccionEsperada;
            p.telefono = telefonoEsperado;
            p.email = emailEsperado;
            p.estado = estadoEsperado;

            // 3. Afirmación (Assert)
            Assert.AreEqual(idEsperado, p.id_proveedor);
            Assert.AreEqual(nombreEsperado, p.nombre);
            Assert.AreEqual(rucEsperado, p.ruc);
            Assert.AreEqual(direccionEsperada, p.direccion);
            Assert.AreEqual(telefonoEsperado, p.telefono);
            Assert.AreEqual(emailEsperado, p.email);
            Assert.IsTrue(p.estado);
        }
    }
}