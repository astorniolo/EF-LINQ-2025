using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace laboratorioM1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Laboratorio1();
            Laboratorio2();
            Laboratorio3();
            Laboratorio4();

        }

        private static void Laboratorio4()
        {
            Console.WriteLine("Laboratorio 4");
            //var cliente = new Customer { id=0, name = "Andrea" };
        }

        private static void Laboratorio1()
        {
            Console.WriteLine("Laboratorio 1");
            MostrarGenerica<int> mostrarGenericaEntera = new MostrarGenerica<int>(8);
            mostrarGenericaEntera.show();

            MostrarGenerica<string> mostrarGenericaString = new MostrarGenerica<string>("Buenas Tardes");
            mostrarGenericaString.show();
        }
        private static void Laboratorio2()
        {
            Console.WriteLine("Laboratorio 2");
            string cadena = "esta es una cadena de caracteres";
            Console.WriteLine($"Esta es la cadena: {cadena} y su invertida es: {cadena.Invertir()}");
        }

        private static void Laboratorio3()
        {
            Console.WriteLine("Laboratorio 3");
            List<int> lista = new List<int> { 1,2,3,4,5,6,7,8,9,10} ;
            foreach (var item in lista)
            {
                Console.WriteLine(item);   
            }
        }


    }

    public static class StringExtensions
    {
        
        // Invertir una cadena
        public static string Invertir(this string cadena)
        {
            char[] arreglo = cadena.ToCharArray();          
            Array.Reverse(arreglo);
            return new string(arreglo);
        }
        
       
    }

    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public Customer(int id, string name) 
        {
            this.id = id;
            this.name = name;
        }
    }
}
