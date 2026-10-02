using Microsoft.VisualStudio.TestTools.UnitTesting;
using AggronomyProject.Models;
using System; // Necesario para trabajar con fechas (DateTime)

namespace AggronomyProject.Tests
{
    [TestClass]
    public class UnitTest_Trabajador
    {
        // CASO DE PRUEBA 3: Validar la asignación de propiedades del Trabajador
        [TestMethod]
        public void ValidarDatosTrabajador()
        {
            // 1. Preparación (Arrange)
            int idEsperado = 1;
            string nombresEsperados = "Carlos";
            string apellidosEsperados = "Mendoza";
            string dniEsperado = "76543210";
            string cargoEsperado = "Supervisor";
            string telefonoEsperado = "987654321";
            string emailEsperado = "carlos.mendoza@agronomia.com";
            DateTime fechaEsperada = new DateTime(2024, 1, 15);
            bool estadoEsperado = true;

            // 2. Ejecución (Act)
            Trabajador t = new Trabajador();
            t.id_trabajador = idEsperado;
            t.nombres = nombresEsperados;
            t.apellidos = apellidosEsperados;
            t.dni = dniEsperado;
            t.cargo = cargoEsperado;
            t.telefono = telefonoEsperado;
            t.email = emailEsperado;
            t.fecha_contrato = fechaEsperada;
            t.estado = estadoEsperado;

            // 3. Afirmación (Assert)
            Assert.AreEqual(idEsperado, t.id_trabajador);
            Assert.AreEqual(nombresEsperados, t.nombres);
            Assert.AreEqual(apellidosEsperados, t.apellidos);
            Assert.AreEqual(dniEsperado, t.dni);
            Assert.AreEqual(cargoEsperado, t.cargo);
            Assert.AreEqual(telefonoEsperado, t.telefono);
            Assert.AreEqual(emailEsperado, t.email);
            Assert.AreEqual(fechaEsperada, t.fecha_contrato);
            Assert.IsTrue(t.estado);
        }
        // CASO DE PRUEBA 16: Validar Trabajador dado de baja (inactivo)
        [TestMethod]
        public void ValidarTrabajadorInactivo()
        {
            Trabajador t = new Trabajador();
            t.nombres = "Ex-empleado";
            t.estado = false; // Ya no trabaja aquí

            Assert.AreEqual("Ex-empleado", t.nombres);
            Assert.IsFalse(t.estado);
        }
    }
}