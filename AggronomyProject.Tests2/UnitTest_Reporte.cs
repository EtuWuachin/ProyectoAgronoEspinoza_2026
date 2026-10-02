using Microsoft.VisualStudio.TestTools.UnitTesting;
using AggronomyProject.Models;
using System; // Necesario para la fecha_generacion

namespace AggronomyProject.Tests
{
    [TestClass]
    public class UnitTest_Reporte
    {
        // CASO DE PRUEBA 5: Validar la asignación de propiedades del Reporte
        [TestMethod]
        public void ValidarDatosReporte()
        {
            // 1. Preparación (Arrange)
            int idEsperado = 10;
            string tituloEsperado = "Reporte Mensual de Cosecha";
            string tipoEsperado = "Producción";
            DateTime fechaEsperada = new DateTime(2026, 10, 2);
            string contenidoEsperado = "Resumen de la producción del mes de octubre.";
            string generadoPorEsperado = "Supervisor Juan";
            bool estadoEsperado = true;

            // 2. Ejecución (Act)
            // Instanciamos el modelo y asignamos basándonos en las propiedades de Reporte.cs
            Reporte r = new Reporte();
            r.id_reporte = idEsperado;
            r.titulo = tituloEsperado;
            r.tipo_reporte = tipoEsperado;
            r.fecha_generacion = fechaEsperada;
            r.contenido = contenidoEsperado;
            r.generado_por = generadoPorEsperado;
            r.estado = estadoEsperado;

            // 3. Afirmación (Assert)
            Assert.AreEqual(idEsperado, r.id_reporte);
            Assert.AreEqual(tituloEsperado, r.titulo);
            Assert.AreEqual(tipoEsperado, r.tipo_reporte);
            Assert.AreEqual(fechaEsperada, r.fecha_generacion);
            Assert.AreEqual(contenidoEsperado, r.contenido);
            Assert.AreEqual(generadoPorEsperado, r.generado_por);
            Assert.IsTrue(r.estado);
        }
    }
}