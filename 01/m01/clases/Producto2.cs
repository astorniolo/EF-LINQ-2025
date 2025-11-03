namespace m01
{
	// Segunda clase parcial con implementación de métodos parciales
	public partial class Producto
	{
		// Implementación del método parcial:
		// En esta otra parte de la clase `Producto`, se proporciona la implementación del método parcial `OnPrecioChanged`. Aquí, el método simplemente imprime un mensaje indicando que el precio ha sido actualizado.
		partial void OnPrecioChanged()
		{
			Console.WriteLine("El precio ha sido actualizado.");
		}
	}
}
