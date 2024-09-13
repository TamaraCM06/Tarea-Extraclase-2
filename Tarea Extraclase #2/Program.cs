using System;

namespace Tarea2
{
    interface IList
    {
        void InsertInOrder(int value);
        int DeleteFirst();
        int DeleteLast();
        bool DeleteValue(int value);
        int GetMiddle();
        //void MergeSorted(IList listA, IList listB, SortDirection direction);
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
         return 0;
        }
        public int DeleteLast()
        {
            return -1;
        }
        public bool DeleteValue(int value)
        {
            return false;
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