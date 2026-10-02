using Microsoft.VisualStudio.TestTools.UnitTesting;
using AggronomyProject.Models;
using System; // Necesario para trabajar con fechas (DateTime)

namespace AggronomyProject.Tests
{
    [TestClass]
    public class UnitTest_Administracion
    {
        // CASO DE PRUEBA 14: Validar la asignación de propiedades de Administracion
        [TestMethod]
        public void ValidarDatosAdministracion()
        {
            // 1. Preparación (Arrange)
            int idEsperado = 1;
            string nombreEsperado = "Gestión Central de Octubre";
            string descripcionEsperada = "Supervisión de inventario y pagos del mes";
            DateTime fechaEsperada = new DateTime(2026, 10, 2);
            string responsableEsperado = "Johel Roncal";
            bool estadoEsperado = true;

            // Llaves foráneas
            int idReporteEsperado = 10;
            int idTrabajadorEsperado = 2;
            int idInventarioEsperado = 3;
            int idMetodoPagoEsperado = 1;
            int idRecursosAdminEsperado = 5;

            // 2. Ejecución (Act)
            Administracion admin = new Administracion();
            admin.IdAdministracion = idEsperado;
            admin.nombre = nombreEsperado;
            admin.descripcion = descripcionEsperada;
            admin.fecha_registro = fechaEsperada;
            admin.responsable = responsableEsperado;
            admin.estado = estadoEsperado;

            admin.id_reporte = idReporteEsperado;
            admin.id_trabajador = idTrabajadorEsperado;
            admin.id_inventario = idInventarioEsperado;
            admin.id_metodo_pago = idMetodoPagoEsperado;
            admin.id_recursos_administrador = idRecursosAdminEsperado;

            // 3. Afirmación (Assert)
            Assert.AreEqual(idEsperado, admin.IdAdministracion);
            Assert.AreEqual(nombreEsperado, admin.nombre);
            Assert.AreEqual(descripcionEsperada, admin.descripcion);
            Assert.AreEqual(fechaEsperada, admin.fecha_registro);
            Assert.AreEqual(responsableEsperado, admin.responsable);
            Assert.IsTrue(admin.estado);

            Assert.AreEqual(idReporteEsperado, admin.id_reporte);
            Assert.AreEqual(idTrabajadorEsperado, admin.id_trabajador);
            Assert.AreEqual(idInventarioEsperado, admin.id_inventario);
            Assert.AreEqual(idMetodoPagoEsperado, admin.id_metodo_pago);
            Assert.AreEqual(idRecursosAdminEsperado, admin.id_recursos_administrador);
        }
    }
}