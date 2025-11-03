

using m01.clases;

namespace m01
{
	// INFERENCIA DE TIPOS:
	// Permite al compilador deducir automáticamente el tipo de una variable a partir del valor asignado
	// usando var. Mejora la legibilidad, reduce el código necesario y facilita trabajar con tipos complejos
	// o anónimos, manteniendo la seguridad de tipos en tiempo de compilación.
	// var infiere tipos
	// var no es asignacion dinamica de tipos solo LOS INFIERE EN COMPILACION
	//el compilador deduce el tipo
	// VS tiene asignacion dinamica de tipos con DYNAMIC

	public class InferenciaDeTipos
	{
		internal static void Demos()
		{
			Console.WriteLine("Demo de Inferencia de Tipos");
			Console.WriteLine("---------------------------\n");

			DemoInferenciaTipos();

		}

		private static void DemoInferenciaTipos()
		{
			// El compilador infiere que nroPedido es de tipo int
			int nroPedido = 50;
			Console.WriteLine($"Nº Pedido: {nroPedido}");
			Console.WriteLine(nroPedido.GetType().Name);

			// El compilador infiere que saludo es de tipo string
			var saludo = "Bienvenidos a C#";
			Console.WriteLine(saludo);
			Console.WriteLine(saludo.GetType().Name);

			// El compilador infiere que hoy es de tipo DateTime
			var hoy = DateTime.Now.Date;
			Console.WriteLine(hoy);
			Console.WriteLine($"hoy es de tipo: {hoy.GetType().Name}");

			// El compilador infiere que numeros es de tipo int[]
			var numeros = new int[] { 1, 2, 3, 4, 5 };

			// El compilador infiere que paciente es de tipo Paciente
			var paciente = new Paciente();
			paciente.Id = 1;
			paciente.Nombre = "Juan";


			var paciente2 = new Paciente();
			paciente2.Id = 2;
			paciente2.Nombre = "Pedro";


			// El compilador infiere que listaPacientes es de tipo List<Paciente>
			var listaPacientes = new List<Paciente>();
		}
	}
}
