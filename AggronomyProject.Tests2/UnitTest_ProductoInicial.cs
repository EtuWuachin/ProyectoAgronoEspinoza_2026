using Microsoft.VisualStudio.TestTools.UnitTesting;
using AggronomyProject.Models;
using System; // Necesario para trabajar con fechas (DateTime)

namespace AggronomyProject.Tests
{
    [TestClass]
    public class UnitTest_ProductoInicial
    {
        // CASO DE PRUEBA 9: Validar la asignación de propiedades de ProductoInicial
        [TestMethod]
        public void ValidarDatosProductoInicial()
        {
            // 1. Preparación (Arrange)
            int idEsperado = 1;
            string nombreEsperado = "Semilla de Maíz";
            string descripcionEsperada = "Semilla híbrida de alto rendimiento";
            int cantidadEsperada = 500;
            string unidadEsperada = "Kilogramos";
            float costoEsperado = 15.5f;
            DateTime fechaEsperada = new DateTime(2026, 10, 2);
            string proveedorEsperado = "AgroSemillas S.A.";
            bool estadoEsperado = true;

            // 2. Ejecución (Act)
            // Asignamos los datos basándonos en las propiedades de ProductoInicial.cs
            ProductoInicial pi = new ProductoInicial();
            pi.id_producto_inicial = idEsperado;
            pi.nombre = nombreEsperado;
            pi.descripcion = descripcionEsperada;
            pi.cantidad_inicial = cantidadEsperada;
            pi.unidad_medida = unidadEsperada;
            pi.costo_unitario = costoEsperado;
            pi.fecha_ingreso = fechaEsperada;
            pi.proveedor_origen = proveedorEsperado;
            pi.estado = estadoEsperado;

            // 3. Afirmación (Assert)
            Assert.AreEqual(idEsperado, pi.id_producto_inicial);
            Assert.AreEqual(nombreEsperado, pi.nombre);
            Assert.AreEqual(descripcionEsperada, pi.descripcion);
            Assert.AreEqual(cantidadEsperada, pi.cantidad_inicial);
            Assert.AreEqual(unidadEsperada, pi.unidad_medida);
            Assert.AreEqual(costoEsperado, pi.costo_unitario);
            Assert.AreEqual(fechaEsperada, pi.fecha_ingreso);
            Assert.AreEqual(proveedorEsperado, pi.proveedor_origen);
            Assert.IsTrue(pi.estado);
        }
    }
}