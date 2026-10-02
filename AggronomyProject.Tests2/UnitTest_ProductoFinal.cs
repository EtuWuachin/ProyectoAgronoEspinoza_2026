using Microsoft.VisualStudio.TestTools.UnitTesting;
using AggronomyProject.Models;

namespace AggronomyProject.Tests
{
    [TestClass]
    public class UnitTest_ProductoFinal
    {
        // CASO DE PRUEBA 10: Validar la asignación de propiedades de ProductoFinal
        [TestMethod]
        public void ValidarDatosProductoFinal()
        {
            // 1. Preparación (Arrange)
            int idEsperado = 1;
            string nombreEsperado = "Maíz Blanco Premium";
            string descripcionEsperada = "Sacos de maíz blanco desgranado listo para venta";
            int cantidadEsperada = 1500;
            string unidadEsperada = "Sacos";
            float precioEsperado = 125.50f;
            bool estadoEsperado = true;

            // 2. Ejecución (Act)
            // Asignamos los datos basándonos en las propiedades de ProductoFinal.cs
            ProductoFinal pf = new ProductoFinal();
            pf.id_producto_final = idEsperado;
            pf.nombre = nombreEsperado;
            pf.descripcion = descripcionEsperada;
            pf.cantidad_producida = cantidadEsperada;
            pf.unidad_medida = unidadEsperada;
            pf.precio_venta = precioEsperado;
            pf.estado = estadoEsperado;

            // 3. Afirmación (Assert)
            Assert.AreEqual(idEsperado, pf.id_producto_final);
            Assert.AreEqual(nombreEsperado, pf.nombre);
            Assert.AreEqual(descripcionEsperada, pf.descripcion);
            Assert.AreEqual(cantidadEsperada, pf.cantidad_producida);
            Assert.AreEqual(unidadEsperada, pf.unidad_medida);
            Assert.AreEqual(precioEsperado, pf.precio_venta);
            Assert.IsTrue(pf.estado);
        }
        // CASO DE PRUEBA 18: Validar Producto Final gratuito o de muestra (Precio 0)
        [TestMethod]
        public void ValidarProductoMuestra()
        {
            ProductoFinal pf = new ProductoFinal();
            pf.nombre = "Muestra gratis de Maíz";
            pf.precio_venta = 0.00f; // No tiene costo

            Assert.AreEqual(0.00f, pf.precio_venta);
        }
    }
}