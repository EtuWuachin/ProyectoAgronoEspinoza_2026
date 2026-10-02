using Microsoft.VisualStudio.TestTools.UnitTesting;
using AggronomyProject.Models; 

namespace AggronomyProject.Tests
{
    [TestClass]
    public class UnitTest_ErrorViewModel
    {
        // CASO DE PRUEBA 15: Validar la lógica del ErrorViewModel
        [TestMethod]
        public void ValidarErrorViewModel_ConId()
        {
            // 1. Preparación y 2. Ejecución
            ErrorViewModel errorVM = new ErrorViewModel();
            errorVM.RequestId = "12345-ABCDE";

            // 3. Afirmación
            // Verificamos que guardó el ID correctamente
            Assert.AreEqual("12345-ABCDE", errorVM.RequestId);

            // Verificamos que la lógica de "ShowRequestId" funcione (debería ser true porque sí hay un ID)
            Assert.IsTrue(errorVM.ShowRequestId);
        }
    }
}