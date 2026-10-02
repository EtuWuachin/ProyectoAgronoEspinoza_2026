using Microsoft.VisualStudio.TestTools.UnitTesting;
using AggronomyProject.Models;

namespace AggronomyProject.Tests
{
    [TestClass]
    public class UnitTest_MetodoPago
    {
        // CASO DE PRUEBA 12: Validar la asignación de propiedades de MetodoPago
        [TestMethod]
        public void ValidarDatosMetodoPago()
        {
            // 1. Preparación (Arrange)
            int idEsperado = 1;
            string nombreEsperado = "Transferencia Bancaria";
            string descripcionEsperada = "Pago directo a cuenta empresarial BCP";
            bool estadoEsperado = true;
            int idPagoEsperado = 10;

            // 2. Ejecución (Act)
            // Asignamos los datos basándonos en las propiedades de MetodoPago.cs
            MetodoPago mp = new MetodoPago();
            mp.IdMetodoPago = idEsperado;
            mp.nombre = nombreEsperado;
            mp.descripcion = descripcionEsperada;
            mp.estado = estadoEsperado;
            mp.id_pago = idPagoEsperado;

            // 3. Afirmación (Assert)
            Assert.AreEqual(idEsperado, mp.IdMetodoPago);
            Assert.AreEqual(nombreEsperado, mp.nombre);
            Assert.AreEqual(descripcionEsperada, mp.descripcion);
            Assert.IsTrue(mp.estado);
            Assert.AreEqual(idPagoEsperado, mp.id_pago);
        }
    }
}