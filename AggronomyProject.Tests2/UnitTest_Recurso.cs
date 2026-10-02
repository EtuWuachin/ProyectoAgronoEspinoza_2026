using Microsoft.VisualStudio.TestTools.UnitTesting;
using AggronomyProject.Models;
using System; // Necesario para trabajar con fechas (DateTime)

namespace AggronomyProject.Tests
{
    [TestClass]
    public class UnitTest_Recurso
    {
        // CASO DE PRUEBA 7: Validar la asignación de propiedades de Recurso
        [TestMethod]
        public void ValidarDatosRecurso()
        {
            // 1. Preparación (Arrange)
            int idEsperado = 1;
            DateTime fechaEsperada = new DateTime(2026, 10, 2);
            int cantidadEsperada = 100;
            string unidadEsperada = "Kilogramos";
            string tipoEsperado = "Fertilizante";
            float costoEsperado = 45.5f;
            bool estadoEsperado = true;
            int idProveedorEsperado = 3;

            // 2. Ejecución (Act)
            // Asignamos los datos basándonos en las propiedades de Recurso.cs
            Recurso r = new Recurso();
            r.id_recurso = idEsperado;
            r.fecha_ingreso = fechaEsperada;
            r.cantidad_recibida = cantidadEsperada;
            r.unidad_medida = unidadEsperada;
            r.tipo_recurso = tipoEsperado;
            r.costo_recurso = costoEsperado;
            r.estado = estadoEsperado;
            r.id_proveedor = idProveedorEsperado;

            // 3. Afirmación (Assert)
            Assert.AreEqual(idEsperado, r.id_recurso);
            Assert.AreEqual(fechaEsperada, r.fecha_ingreso);
            Assert.AreEqual(cantidadEsperada, r.cantidad_recibida);
            Assert.AreEqual(unidadEsperada, r.unidad_medida);
            Assert.AreEqual(tipoEsperado, r.tipo_recurso);
            Assert.AreEqual(costoEsperado, r.costo_recurso);
            Assert.IsTrue(r.estado);
            Assert.AreEqual(idProveedorEsperado, r.id_proveedor);
        }
    }
}