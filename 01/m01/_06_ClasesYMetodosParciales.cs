namespace m01
{
	// CLASES PARCIALES:
	// Las clases parciales, definidas con la palabra clave 'partial', permiten dividir una clase en varios archivos dentro del mismo ensamblado y espacio de nombres. El compilador las combina en una única clase al compilar.

	// MÉTODOS PARCIALES:
	// Los métodos parciales, definidos con la palabra clave partial, permiten que una clase parcial tenga métodos opcionales. Si no se implementan, el compilador elimina sus llamadas sin impactar el rendimiento.

	public class ClasesYMetodosParciales
	{
		internal static void Demos()
		{
			Console.WriteLine("Demo de Clases y Métodos Parciales");
			Console.WriteLine("----------------------------------\n");

			// DemoClasesParciales();

			DemoMetodosParciales();
		}

		private static void DemoClasesParciales()
		{
			var persona = new Persona();
			persona.Nombre = "Juan";
			persona.Edad = 33;
			persona.MostrarInformacion();
		}

		private static void DemoMetodosParciales()
		{
			var producto = new Producto();
			producto.Nombre = "Mouse";
			producto.Precio = 8;
			producto.MostrarInformacion();
		}
	}
}
