
﻿using System.Timers;
using Timer = System.Timers.Timer;

namespace m02
{
    // MÉTODOS ANÓNIMOS
    // Los métodos anónimos son funciones sin nombre definidas directamente en el lugar donde se necesitan, sin declarar un método por separado.Son útiles para tareas simples y locales, como:
    //	1. Callbacks: Pasar funciones como argumentos para responder a eventos o condiciones.
    //	2. Expresiones Lambda: Facilitan código conciso y legible, especialmente con LINQ y eventos.
    //	3. Funciones Locales: Permiten encapsular lógica dentro del alcance de un método, organizando mejor el código.
    // Proporcionan una forma concisa y flexible de trabajar con delegados y eventos.

    public class MetodosAnonimos
    {
        internal static void Demos()
        {
            Console.WriteLine("Métodos Anónimos");
            Console.WriteLine("-----------------------------------\n");

            // DemoMetodosSinAnonimos();
            // DemoMetodosConAnonimos();
            // DemoMetodosAnonimos1();
            // DemoMetodosAnonimos2();
            // DemoMetodosAnonimosYEventos();
        }

        #region DemoMetodosSinAnonimos
        // Ejemplo de Métodos Sin Anónimos con Delegados

        delegate void Operacion(int n);
        private static void DemoMetodosSinAnonimos()
        {
            Console.WriteLine("Métodos Sin Anónimos y Delegados");
            Console.WriteLine("-----------------------------------\n");

            // Lista de números
            var numeros = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine("Números:");
            numeros.ForEach(Console.WriteLine);

            Operacion cuadrado = Cuadrado;

            // Recorrer la lista y aplicar la operación
            Console.WriteLine("\nCuadrados:");
            foreach (int numero in numeros)
            {
                cuadrado(numero);
            }
        }
        public static void Cuadrado(int x) { Console.WriteLine($"{x}² = {x * x}"); ; }
        #endregion

        #region DemoMetodosConAnonimos
        private static void DemoMetodosConAnonimos()
        {
            Console.WriteLine("Métodos Con Anónimos y Delegados");
            Console.WriteLine("-----------------------------------\n");

            // Lista de números
            var numeros = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine("Números:");
            numeros.ForEach(Console.WriteLine);

            Operacion cuadrado = delegate (int x) { Console.WriteLine($"{x}² = {x * x}"); };

            // Recorrer la lista y aplicar la operación
            Console.WriteLine("\nCuadrados:");
            foreach (int numero in numeros)
            {
                cuadrado(numero);
            }
        }
        #endregion

        #region DemoMetodosAnonimos1
        // Filtrar Números Pares
        private static void DemoMetodosAnonimos1()
        {
            Console.WriteLine("Métodos Anónimos con Delegados 1");
            Console.WriteLine("-----------------------------------\n");

            // Lista de números
            List<int> numeros = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine("Números:");
            numeros.ForEach(Console.WriteLine);

            // Filtrar los números pares
            Console.WriteLine("\nPares:");

            // find all recibe un predicado
            // un predicado es un delegado que devuelve true o false
            // entonces finadall filtra y devuelve los elementos que matchean true 
            var pares = numeros.FindAll( delegate (int x) {   return x % 2 == 0; } );

            pares.ForEach(Console.WriteLine);
        }
        #endregion

        #region DemoMetodosAnonimos2
        
        // Ordenamiento Personalizado 
        // definimos una forma de ordenar a traves de delegados y anonimos

        private static void DemoMetodosAnonimos2()
        {
            Console.WriteLine("Métodos Anónimos con Delegados 2");
            Console.WriteLine("-----------------------------------\n");

            // Lista de productos
            List<string> productos = new List<string> { "Notebook", "Monitor", "Mouse", "SSD", "Headset" };
            Console.WriteLine("Productos:");

            productos.ForEach(Imprimir); //aca invocamos un codigo  // a foreach le pasamos un metodo 

            productos.Sort(                               // a Sort le pasamos un mecanismo de comparacion a traves de delegado anonimo
                delegate (string a, string b)             // sort es mutable mutan la posicion  para ordenar
                {
                    return a.Length.CompareTo(b.Length);
                }
                );
            Console.WriteLine("\nProductos Ordenados por Longitud:");
            productos.ForEach(Imprimir);
        }

        public static void Imprimir<T>(T valor)    // metodo generico
        {
            Console.WriteLine(valor);
        }
        #endregion

        #region DemoMetodosAnonimosYEventos

        // Eventos con Métodos Anónimos
        // OBJ tienen  propiedades y comportamiento(metodos)
        // Los OBJ tienen la capacidad de comunicarse  con otros OBJ a traves de mensajes
        // si quiero q 1 OBJ le diga  a otro que haga  1 determinada tarea , le manda un MENSAJE
        // existe tambien la posibilidad de trabajar con eventos q permite interactuar (accion reaccion)
        // laq accion es hacer un clich ...un EVENTO 
        // necesitamos un MANEJADOR de EVENTOS qye escuche un evento y reaccion , lo maneje...
        // podemos reacion a eventos con met anonimos   ..... por ejemplo un manejado q sea anonimo


        private static void DemoMetodosAnonimosYEventos()
        {
            Timer myTimer = new Timer(1000); //cada 1000 milisegundo 
           
            // aca manejamos lo que hacemos en cada tic  con un anonimo
            myTimer.Elapsed += delegate (System.Object source, ElapsedEventArgs e)
            {
                Console.WriteLine("Un segundo ha pasado.");
            };

            myTimer.Start();

            Console.WriteLine("Presiona Enter para salir.");
            Console.ReadLine();

            myTimer.Stop();
        }
        #endregion
    }
}
