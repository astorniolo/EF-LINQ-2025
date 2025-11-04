
namespace m02
{
    // Predicate<T>
    /*
	 Predicate<T> es un delegado genérico que encapsula un método que toma un argumento de tipo T
     y devuelve un valor booleano (true o false). 
     Es útil para filtrar o buscar elementos en colecciones.

	SINTAXIS:
		bool Metodo(T parametro);

	*/
    public class Predicados
    {
        internal static void Demos()
        {
            DemoPredicados1();
        }


        #region DemoPredicados1
        // Este método demuestra el uso de Predicate<T> para filtrar una lista de objetos Persona
        // y obtener solo aquellos que son mayores de edad.
        private static void DemoPredicados1()
        {
            var listaPersonas = new List<Persona>
                {
                    new Persona { Nombre = "Marco", Edad = 17 },
                    new Persona { Nombre = "Juan", Edad = 25 },
                    new Persona { Nombre = "Mario", Edad = 30 },
                    new Persona { Nombre = "Edith", Edad = 15 },
                };

            // Definimos un Predicate que verifica si una persona es mayor de edad.
            Predicate<Persona> esMayorDeEdad = persona => persona.Edad >= 18;

            var mayoresDeEdad = listaPersonas.FindAll(esMayorDeEdad);

            // Imprimimos los nombres y edades de las personas mayores de edad.
            mayoresDeEdad.ForEach(persona =>
                Console.WriteLine($"{persona.Nombre}, {persona.Edad} años"));
        }
        #endregion
    }

    public class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
}