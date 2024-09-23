using Tarea2;

namespace TareaTests
{
   [TestClass]
   public class UnitTest
    {
        [TestMethod]
        public void Problema1Ascendente()
        {
            ListaDoble listaA = new ListaDoble();

            listaA.InsertInOrder(4);
            listaA.InsertInOrder(5);
            listaA.InsertInOrder(6);

            ListaDoble listaB = new ListaDoble();

            listaB.InsertInOrder(3);
            listaB.InsertInOrder(1);
            listaB.InsertInOrder(7);


            listaA.MergeSorted(listaA, listaB, SortDirection.Asc);

            Nodo actual = listaA.head;

            int[] result = {1,3,4,5,6,7};
            int i = 0;

            while (actual != null)
            {
                Assert.AreEqual(result[i], actual.Dato);
                actual = actual.Siguiente;
                i++;
            }

        }
        [TestMethod]
        public void Problema1Descendente()
        {
            ListaDoble listaA = new ListaDoble();

            listaA.InsertInOrder(5);
            listaA.InsertInOrder(8);
            listaA.InsertInOrder(4);

            ListaDoble listaB = new ListaDoble();

            listaB.InsertInOrder(2);
            listaB.InsertInOrder(1);
            listaB.InsertInOrder(3);


            listaA.MergeSorted(listaA, listaB, SortDirection.Desc);

            Nodo actual = listaA.head;

            int[] result = { 8,5,4,3,2,1};
            int i = 0;

            while (actual != null)
            {
                Assert.AreEqual(result[i], actual.Dato);
                actual = actual.Siguiente;
                i++;
            }

        }
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