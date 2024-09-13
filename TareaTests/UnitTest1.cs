using Tarea2;

namespace TareaTests
{
   [TestClass]
   public class UnitTest
    {
        [TestMethod]
        public void Problema2()
        {
            ListaDoble lista = new ListaDoble();

            lista.Insertar(7);
            lista.Insertar(1);
            lista.Insertar(9);
            lista.Insertar(4);
            lista.Insertar(3);

            lista.Invert();

            Nodo actualInvertido = lista.head;

            Assert.AreEqual(3, actualInvertido.Dato);
            actualInvertido = actualInvertido.Siguiente;
            Assert.AreEqual(4, actualInvertido.Dato);
            actualInvertido = actualInvertido.Siguiente;
            Assert.AreEqual(9, actualInvertido.Dato);
            actualInvertido = actualInvertido.Siguiente;
            Assert.AreEqual(1, actualInvertido.Dato);
            actualInvertido = actualInvertido.Siguiente;
            Assert.AreEqual(7, actualInvertido.Dato);

        }

        [TestMethod]
        public void Problema3()
        {
            ListaDoble lista = new ListaDoble();

            lista.InsertInOrder(7);
            lista.InsertInOrder(1);
            lista.InsertInOrder(9);
            lista.InsertInOrder(4);
            lista.InsertInOrder(3);

            int middle = lista.GetMiddle();
            Assert.AreEqual(4, middle);
            
        }
   }
}