using Microsoft.VisualStudio.TestTools.UnitTesting;
using AggronomyProject.Models;
using System; // Necesario para trabajar con fechas (DateTime)

namespace AggronomyProject.Tests
{
    [TestClass]
    public class UnitTest_RecursosAdministrador
    {
        // CASO DE PRUEBA 6: Validar la asignación de propiedades de RecursosAdministrador
        [TestMethod]
        public void ValidarDatosRecursosAdministrador()
        {
            // 1. Preparación (Arrange)
            int idEsperado = 1;
            DateTime fechaEsperada = new DateTime(2026, 10, 2);
            int cantidadEsperada = 500;
            string observacionesEsperadas = "Materiales recibidos en óptimas condiciones.";
            bool estadoEsperado = true;
            int idRecursoEsperado = 5;

            // 2. Ejecución (Act)
            // Asignamos los datos basándonos en las propiedades de RecursosAdministrador.cs
            RecursosAdministrador ra = new RecursosAdministrador();
            ra.id_recursos_administrador = idEsperado;
            ra.fecha_recepcion = fechaEsperada;
            ra.cantidad_recibida = cantidadEsperada;
            ra.observaciones = observacionesEsperadas;
            ra.estado = estadoEsperado;
            ra.id_recurso = idRecursoEsperado;

            // 3. Afirmación (Assert)
            Assert.AreEqual(idEsperado, ra.id_recursos_administrador);
            Assert.AreEqual(fechaEsperada, ra.fecha_recepcion);
            Assert.AreEqual(cantidadEsperada, ra.cantidad_recibida);
            Assert.AreEqual(observacionesEsperadas, ra.observaciones);
            Assert.IsTrue(ra.estado);
            Assert.AreEqual(idRecursoEsperado, ra.id_recurso);
        }
    }
}