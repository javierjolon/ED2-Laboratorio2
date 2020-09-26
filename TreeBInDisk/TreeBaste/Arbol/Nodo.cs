using System;
using System.Collections.Generic;
using System.Text;

namespace TreeBaste.Arbol
{

    public class Nodo<T> where T : IComparable
    {
        public const int m = 5; // Grado del árbol 
        public T[] Values = new T[m - 1]; // Vector de sodas en el nodo
        public Nodo<T>[] Children = new Nodo<T>[m]; // Vector de hijos 
        public Nodo<T> father; //apuntador al padre
        public Nodo()
        {
            for (int i = 0; i < m - 1; i++)
            {
                Values[i] = default(T);
            }
            for (int j = 0; j < m; j++)
            {
                Children[j] = null;
            }
        }

    }
}
