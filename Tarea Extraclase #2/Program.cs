﻿using System;

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
            }
            if (value < head.Dato)
            {
                nuevoNodo.Siguiente = head;
                head.Anterior = last;
                head = nuevoNodo;
            }
            if (value > last.Dato)
            {
                last.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = last;
                last = nuevoNodo;
            }
            Nodo actual = head;
            while (actual != null && actual.Dato < value)
            {
                actual = actual.Siguiente;
            }
            nuevoNodo.Anterior = actual.Anterior;
            nuevoNodo.Siguiente = actual;
            actual.Anterior.Siguiente = nuevoNodo;
            actual.Anterior = nuevoNodo;
            
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
            return 4;
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