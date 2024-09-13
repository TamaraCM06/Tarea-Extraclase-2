using System;

namespace Tarea2
{
    public interface IList
    {
        void InsertInOrder(int value);
        int DeleteFirst();
        int DeleteLast();
        bool DeleteValue(int value);
        int GetMiddle();
        void MergeSorted(IList listA, IList listB, SortDirection direction);
    }


    public class Nodo
    {
        public int Dato { get; set; }
        public Nodo? Siguiente { get; set; }
        public Nodo? Anterior { get; set; }

        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null;
            Anterior = null;
        }
    }
    public class ListaDoble : IList 
    {
        public Nodo? head;
        public Nodo? last;
        public Nodo? middle;
        public int nodos;
        public ListaDoble()
        {
            head = null;
            last = null;
        }
        public void InsertInOrder(int value)
        {
            Nodo nuevoNodo = new Nodo(value);

            if (head == null || last == null)
            {
                head = nuevoNodo;
                last = nuevoNodo;
                middle = nuevoNodo;
                nodos = 0;
                nodos = 1;
                return;
                
            }
            if (value < head.Dato)
            {
                nuevoNodo.Siguiente = head;
                head.Anterior = last;
                head = nuevoNodo;
                if ((nodos%2) != 0)
                {
                    middle = middle.Anterior;
                }

                nodos += 1;

                return;


            }
            if (value > last.Dato)
            {
                last.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = last;
                last = nuevoNodo;
                if ((nodos % 2) != 0)
                {
                    middle = middle.Siguiente;
                }

                nodos += 1;

                return;
            }
            Nodo actual = head;
            while (actual != null && actual.Dato < value)
            {
                actual = actual.Siguiente;
            }
            nuevoNodo.Anterior = actual.Anterior;
            nuevoNodo.Siguiente = actual;
            if (actual.Anterior != null)
            {
                actual.Anterior.Siguiente = nuevoNodo;
            }

            actual.Anterior = nuevoNodo;
            if ((nodos % 2) != 0)
            {
                middle = middle.Siguiente;
            }

            nodos += 1;
            Console.WriteLine(middle);
        }
        public int DeleteFirst()
        {
            if (head == null)
            {
                return -1000000;         
            }

            int valor = head.Dato;
            head = head.Siguiente;

            if (head != null)
            {
                head.Anterior = null;
            }
            else
            {
                last = null;
            }
            return valor;
        }

        public int DeleteLast()
        {
            if (last == null)
            {
                return -1000000;
            }

            int valor = last.Dato;
            last = last.Anterior;

            if (last != null)
            {
                last.Siguiente = null;
            }
            else
            {
                head = null;
            }
            return valor;
        }
        public bool DeleteValue(int value)
        {
            if (head == null || last == null)
            {
                return false;
            }

            Nodo actual = head;

            while (actual != null && actual.Dato != value)
            {
                actual = actual.Siguiente;
            }

            if (actual == null)
            {
                return false;
            }

            if (actual == head)
            {
                DeleteFirst();
            }
            else if (actual == last)
            {
                DeleteLast();
            }
            else
            {
                actual.Anterior.Siguiente = actual.Siguiente;
                actual.Siguiente.Anterior = actual.Anterior;
            }
            return true;
        }
        public int GetMiddle()
        {
            if (middle == null)
            {
                return -1000000;
            }
            return middle.Dato;
        }

        public void Insertar(int value)  //Metodo para insertar sin orden especifico para problemas 1 y 2
        {
            Nodo nuevoNodo = new Nodo(value);

            if (head == null)
            {
                head = nuevoNodo;
                last = nuevoNodo;
            }
            else
            {
                last.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = last;
                last = nuevoNodo;
            }
        }

        public void Invert()
        {
            if ((head == null) || (last == null))
            {
                return;
            }

            Nodo actual = head;
            Nodo holder = null;

            while(actual != null)
            {
                holder = actual.Anterior;
                actual.Anterior = actual.Siguiente;
                actual.Siguiente = holder;
                actual = actual.Anterior;
            }

            if (holder != null)
            {
                holder = head;
                head = last;
                last = holder;
            }
        }

        public void MergeSorted(IList listA, IList listB, SortDirection direction)
        {
            if (listA == null || listB == null) 
            { 
                return;
            }

            ListaDoble listAA = listA as ListaDoble;
            ListaDoble listBB = listB as ListaDoble;

            Nodo nodoA = listAA.head;
            Nodo nodoB = listBB.head;

            ListaDoble mergedList = new ListaDoble();

            while (nodoA != null && nodoB != null)
            {
                if (direction == SortDirection.Asc)
                {
                    if (nodoA.Dato <= nodoB.Dato)
                    {
                        mergedList.InsertInOrder(nodoA.Dato);
                        nodoA = nodoA.Siguiente;
                    }
                    else
                    {
                        mergedList.InsertInOrder(nodoB.Dato);
                        nodoB = nodoB.Siguiente;
                    }
                    while (nodoA != null)
                    {
                        mergedList.InsertInOrder(nodoA.Dato);
                        nodoA = nodoA.Siguiente;
                    }
                    while (nodoB != null)
                    {
                        mergedList.InsertInOrder(nodoB.Dato);
                        nodoB = nodoB.Siguiente;
                    }


                }
                else
                {

                    if (nodoA.Dato >= nodoB.Dato)
                    {
                        mergedList.Insertar(nodoA.Dato);
                        nodoA = nodoA.Anterior;
                    }
                    else
                    {
                        mergedList.Insertar(nodoB.Dato);
                        nodoB = nodoB.Anterior;
                    }
                    while (nodoA != null)
                    {
                        mergedList.Insertar(nodoA.Dato);
                        nodoA = nodoA.Anterior;
                    }
                    while (nodoB != null)
                    {
                        mergedList.Insertar(nodoB.Dato);
                        nodoB = nodoB.Anterior;
                    }

                }
            }

            this.head = mergedList.head;
            this.last = mergedList.last;

        }
    }
    public enum SortDirection
    {
        Asc,
        Desc
    }

    public class Program
    {
        public static void Main(string[] args)
        {

        }

    }
}