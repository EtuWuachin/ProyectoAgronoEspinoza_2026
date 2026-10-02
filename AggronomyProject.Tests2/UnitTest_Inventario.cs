using Microsoft.VisualStudio.TestTools.UnitTesting;
using AggronomyProject.Models;
using System; // Necesario para trabajar con fechas (DateTime)

namespace AggronomyProject.Tests
{
    [TestClass]
    public class UnitTest_Inventario
    {
        // CASO DE PRUEBA 13: Validar la asignación de propiedades de Inventario
        [TestMethod]
        public void ValidarDatosInventario()
        {
            // 1. Preparación (Arrange)
            int idEsperado = 1;
            string nombreEsperado = "Almacén Principal";
            string descripcionEsperada = "Inventario general de semillas y fertilizantes";
            int stockActualEsperado = 500;
            int stockMinimoEsperado = 50;
            string unidadEsperada = "Kilogramos";
            DateTime fechaEsperada = new DateTime(2026, 10, 2);
            bool estadoEsperado = true;
            int idProdInicialEsperado = 3;
            int idProdFinalEsperado = 5;

            // 2. Ejecución (Act)
            // Asignamos los datos basándonos en las propiedades de Inventario.cs
            Inventario inv = new Inventario();
            inv.id_iventario = idEsperado; // Escrito exactamente como en tu modelo (sin la 'n')
            inv.nombre = nombreEsperado;
            inv.descripcion = descripcionEsperada;
            inv.stock_actual = stockActualEsperado;
            inv.stock_minimo = stockMinimoEsperado;
            inv.unidad_medida = unidadEsperada;
            inv.fecha_actualizacion = fechaEsperada;
            inv.estado = estadoEsperado;
            inv.id_producto_inicial = idProdInicialEsperado;
            inv.id_producto_final = idProdFinalEsperado;

            // 3. Afirmación (Assert)
            Assert.AreEqual(idEsperado, inv.id_iventario);
            Assert.AreEqual(nombreEsperado, inv.nombre);
            Assert.AreEqual(descripcionEsperada, inv.descripcion);
            Assert.AreEqual(stockActualEsperado, inv.stock_actual);
            Assert.AreEqual(stockMinimoEsperado, inv.stock_minimo);
            Assert.AreEqual(unidadEsperada, inv.unidad_medida);
            Assert.AreEqual(fechaEsperada, inv.fecha_actualizacion);
            Assert.IsTrue(inv.estado);
            Assert.AreEqual(idProdInicialEsperado, inv.id_producto_inicial);
            Assert.AreEqual(idProdFinalEsperado, inv.id_producto_final);
        }
        // CASO DE PRUEBA 17: Validar Inventario sin stock (Agotado)
        [TestMethod]
        public void ValidarInventarioSinStock()
        {
            Inventario inv = new Inventario();
            inv.nombre = "Fertilizante Agotado";
            inv.stock_actual = 0; // Simulamos que se acabó

            Assert.AreEqual(0, inv.stock_actual);
        }
    }
}