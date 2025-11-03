

using m01.clases;
using System.Linq.Expressions;

namespace m01
{
	// INICIALIZADORES DE OBJETOS:
	// Permiten crear e inicializar objetos de forma concisa asignando valores a sus propiedades al momento de su creación, sin usar constructores o métodos adicionales.

	//	Inicializadores de Objetos
	// Los inicializadores de objetos permiten establecer las propiedades de un objeto en el momento de su creación. Esto se hace utilizando una sintaxis sencilla que consiste en especificar el nombre de la propiedad seguido de su valor entre llaves {}.

	// Inicializadores de Colecciones
	// Los inicializadores de colecciones permiten crear y llenar colecciones(como listas, diccionarios, etc.) en una sola expresión.Esto se hace utilizando una sintaxis similar a la de los inicializadores de objetos.

	public class InicializadoresDeObjetosYColecciones
	{
		internal static void Demos()
		{
			Console.WriteLine("Demo de Inicializadores de Objetos y Colecciones");
			Console.WriteLine("-----------------------------------------------\n");

			// DemoInicializadorDeObjetos();

			DemoInicializadorDeColecciones();
		}
		private static void DemoInicializadorDeObjetos()
		{
			Paciente paciente0 = new Paciente();
			paciente0.Id = 0;
			paciente0.Nombre = "Juan Pérez";
			paciente0.Email = "juan.perez@yahoo.com";
			Console.WriteLine($"Paciente0: Id={paciente0.Id}, Nombre={paciente0.Nombre}, Email={paciente0.Email}");

			var paciente1 = new Paciente { Id = 1, Nombre = "Maria Lopez" };

			var paciente2 = new Paciente { Id = 2, Nombre = "Mario Ramirez" };

			var paciente3 = new Paciente { Nombre = "Maria Sanchez" };

			Console.WriteLine($"Paciente 1: {paciente1.Id} - {paciente1.Nombre} - {paciente1.Email}");
			Console.WriteLine($"Paciente 2: {paciente2.Id} - {paciente2.Nombre} - {paciente2.Email}");
			Console.WriteLine($"Paciente 3: {paciente3.Id} - {paciente3.Nombre} - {paciente3.Email} - {paciente3.Activo} - {paciente3.Domicilio}");

		}

		private static void DemoInicializadorDeColecciones()
		{
			var numeros = new List<int> { 1, 2, 3, 4, 5 };

			var nombres = new List<string> { "Ana", "Luis", "Carlos" };

			var pacientes = new List<Paciente>
				{
				new Paciente { Id = 1, Nombre = "Juan Perez", Email = "juan.perez@hotmail.com" },
				new Paciente { Id = 2, Nombre = "Mario Ramirez" }
				};

		}
	}
}
