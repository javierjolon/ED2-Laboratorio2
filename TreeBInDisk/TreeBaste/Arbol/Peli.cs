using System;
using System.Collections.Generic;
using System.Text;

namespace TreeBaste.Arbol
{
    public class Peli : IComparable
    {
        public string Name { get; set; } //Nombre de la Peli
        public string Flavor { get; set; }//Sabor de la Peli
        public int Vol { get; set; } //Volumen de la Peli
        public float Price { get; set; }//Precio de la Peli
        public string ProductHouse { get; set; } //Casa productora de la Peli

        public int CompareTo(object obj) //Comparación del Nombre de las bebidas
                                         //retorna los siguientes 3 valores -1 menor, 0 igual, 1 mayor
        {

            return this.Name.CompareTo(((Peli)obj).Name);

        }
        public static Comparison<Peli> CompareByName = delegate (Peli s1, Peli s2)
        {
            return s1.CompareTo(s2);
        };
    }
}
