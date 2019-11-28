using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void IdRepetido()
        {
            Correo c = new Correo();
            Paquete p1 = new Paquete("Avellaneda", "1234");
            Paquete p2 = new Paquete("Berazategui", "1234");
            c += p1;
            c += p2;
         
        }
    }
}
