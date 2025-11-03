namespace m01
{
	// Primer clase parcial 
	public partial class Producto
	{
		public string Nombre { get; set; }
		public decimal Precio { get; set; }


		// Definición del método parcial:
		// En esta parte de la clase `Producto`, se define la firma del método parcial `OnPrecioChanged` usando la palabra clave `partial`. No se proporciona una implementación aquí, solo se declara el método.
		partial void OnPrecioChanged();

		public void MostrarInformacion()
		{
			Console.WriteLine($"Producto: {Nombre}, Precio: {Precio}");
			OnPrecioChanged();
		}
	}
}
