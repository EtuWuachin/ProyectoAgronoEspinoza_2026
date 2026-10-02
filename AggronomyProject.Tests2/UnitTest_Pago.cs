using Microsoft.VisualStudio.TestTools.UnitTesting;
using AggronomyProject.Models;
using System; // Necesario para trabajar con fechas (DateTime)

namespace AggronomyProject.Tests
{
    [TestClass]
    public class UnitTest_Pago
    {
        // CASO DE PRUEBA 11: Validar la asignación de propiedades de Pago
        [TestMethod]
        public void ValidarDatosPago()
        {
            // 1. Preparación (Arrange)
            int idEsperado = 1;
            decimal montoEsperado = 2500.50m; // La letra 'm' le indica a C# que es un tipo decimal
            DateTime fechaEsperada = new DateTime(2026, 10, 2);
            string conceptoEsperado = "Pago a proveedor por semillas";
            string comprobanteEsperado = "FACT-001-9876";
            bool estadoEsperado = true;

            // 2. Ejecución (Act)
            // Asignamos los datos basándonos en las propiedades de Pago.cs
            Pago p = new Pago();
            p.IdPago = idEsperado;
            p.monto = montoEsperado;
            p.fecha_pago = fechaEsperada;
            p.concepto = conceptoEsperado;
            p.comprobante = comprobanteEsperado;
            p.estado = estadoEsperado;

            // 3. Afirmación (Assert)
            Assert.AreEqual(idEsperado, p.IdPago);
            Assert.AreEqual(montoEsperado, p.monto);
            Assert.AreEqual(fechaEsperada, p.fecha_pago);
            Assert.AreEqual(conceptoEsperado, p.concepto);
            Assert.AreEqual(comprobanteEsperado, p.comprobante);
            Assert.IsTrue(p.estado);
        }
        // CASO DE PRUEBA 19: Validar un Pago rechazado o anulado
        [TestMethod]
        public void ValidarPagoAnulado()
        {
            Pago p = new Pago();
            p.monto = 500.00m;
            p.estado = false; // Pago anulado

            Assert.AreEqual(500.00m, p.monto);
            Assert.IsFalse(p.estado);
        }
    }
}