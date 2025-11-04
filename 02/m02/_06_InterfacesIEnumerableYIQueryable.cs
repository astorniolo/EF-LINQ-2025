
using m02.Clases;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;



namespace m02
{
    // Que son las interfaces
    // Las interfaces son contratos que definen un conjunto de métodos y propiedades que una clase debe implementar. Permiten la creación de código más flexible y reutilizable al separar la definición de la implementación.

    // `IEnumerable<T>` y `IQueryable<T>`:

    /*
		`IEnumerable<T>`:
			- Definición: Permite recorrer colecciones en memoria de manera secuencial.
			- Uso: Ideal para datos ya cargados en memoria.
			- Características: Ejecución inmediata, no optimizada para consultas complejas.
			- Ejemplo: Utilizable con listas, matrices y colecciones genéricas.
	*/

    /*
		`IQueryable<T>`:
			- Definición: Permite realizar consultas a fuentes de datos externas (como bases de datos) usando LINQ.
			- Uso: Diseñado para consultas optimizadas y diferidas.
			- Características: Ejecuta consultas en el origen de los datos (como SQL), minimizando la carga en memoria.
			- Ejemplo: Utilizado comúnmente en Entity Framework y LINQ to SQL.
	*/
    public class InterfacesIEnumerableYIQueryable
    {
        internal static void Demos()
        {
            Console.WriteLine("Interfaces IEnumerable<T> y IQueryable<T>");
            Console.WriteLine("-----------------------------------------\n");

            //DemoIEnumerable1();
            //DemoIEnumerable2();
            //DemoIEnumerable3();

            DemoIQueryable1();
            //mostramos consulta a bd con EF y linq
        }

        #region DemoIEnumerable1
        private static void DemoIEnumerable1()
        {
            // Crear una lista de números y recorrerla usando IEnumerable<T>
            // podriamos hacerlo con var que hace una inferencia
            //var numeros = new List<int> { 1, 2, 3, 4, 5 };
            // o con list<int y sabemos que lista es Ienumerable 
            IEnumerable<int> numeros = new List<int> { 1, 2, 3, 4, 5 };

            Console.WriteLine("Recorriendo una lista de números con IEnumerable<T>:");
            foreach (var numero in numeros)
            {
                Console.WriteLine(numero);
            }
            Console.WriteLine();
        }
        #endregion

        #region DemoIEnumerable2
        // Este método demuestra el uso de IEnumerable<T> para recorrer una matriz de cadenas.

        private static void DemoIEnumerable2()
        {
            // Crear una matriz de cadenas y recorrerla usando IEnumerable<T>
            //tenemos una matriz que tb soporta la interface IEnumerable
            string[] colores = { "Rojo", "Verde", "Azul" };
            Console.WriteLine("Recorriendo una matriz de cadenas con IEnumerable<T>:");

            foreach (var color in colores)
            {
                Console.WriteLine(color);
            }
            Console.WriteLine();
        }
        #endregion

        #region DemoIEnumerable3
        // Este método demuestra el uso de IEnumerable<T> para recorrer una lista de objetos personalizados

        private static void DemoIEnumerable3()
        {
            // Crear una lista de objetos Persona y recorrerla usando IEnumerable<T>

            var personas = new List<Persona>
                    {
                        new Persona { Nombre = "Alicia", Edad = 30 },
                        new Persona { Nombre = "Pablo", Edad = 25 },
                        new Persona { Nombre = "Leandro", Edad = 35 }
                    };

            Console.WriteLine("Recorriendo una lista de objetos con IEnumerable<T>:");
            foreach (var persona in personas)
            {
                Console.WriteLine($"Nombre: {persona.Nombre}, Edad: {persona.Edad}");
            }
            Console.WriteLine();
        }

        #endregion


        #region DemoIQueryable1
        // Este método demuestra el uso de IQueryable<T> para realizar una consulta a una base de datos utilizando Entity Framework Core.

        private static void DemoIQueryable1()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Database.EnsureCreated();

                IEnumerable<Cliente> clientes = dbContext.Clientes.ToList();

                Console.WriteLine("Clientes en la base de datos:");
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"Id: {cliente.Id}, Nombre: {cliente.Nombre}, Ciudad: {cliente.Ciudad}");
                }

                Console.WriteLine("-----------------------------------------");
                Console.WriteLine();

                // Consulta IQueryable para filtrar clientes en CABA
                IQueryable<Cliente> consulta = dbContext.Clientes.Where(c => c.Ciudad == "CABA");

                // Ejecutar la consulta y obtener los resultados
                // se ejeguta cuando hago toList()
                var resultados = consulta.ToList();

                // Mostrar los clientes que están en CABA
                Console.WriteLine("Clientes en CABA:");
                foreach (var cliente in resultados)
                {
                    Console.WriteLine($"Id: {cliente.Id}, Nombre: {cliente.Nombre}, Ciudad: {cliente.Ciudad}");
                }
            }
        }

        public class ApplicationDbContext : DbContext
        {
            public DbSet<Cliente> Clientes { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                // dependencias agregar nuget "microsof entitey framewor. in memory
                optionsBuilder.UseInMemoryDatabase("TestDatabase");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Cliente>().HasData(
                    new Cliente { Id = 1, Nombre = "Juan", Apellido = "Perez", Ciudad = "Buenos Aires", Email = "juan.perez@example.com", Telefono = "123456789" },
                    new Cliente { Id = 2, Nombre = "Maria", Apellido = "Gomez", Ciudad = "Córdoba", Email = "maria.gomez@example.com", Telefono = "987654321" },
                    new Cliente { Id = 3, Nombre = "Carlos", Apellido = "Lopez", Ciudad = "Rosario", Email = "carlos.lopez@example.com", Telefono = "456123789" },
                    new Cliente { Id = 4, Nombre = "Ana", Apellido = "Martinez", Ciudad = "Mendoza", Email = "ana.martinez@example.com", Telefono = "789456123" },
                    new Cliente { Id = 5, Nombre = "Luis", Apellido = "Garcia", Ciudad = "La Plata", Email = "luis.garcia@example.com", Telefono = "321654987" },
                    new Cliente { Id = 6, Nombre = "Laura", Apellido = "Fernandez", Ciudad = "Mar del Plata", Email = "laura.fernandez@example.com", Telefono = "654987321" },
                    new Cliente { Id = 7, Nombre = "Jorge", Apellido = "Rodriguez", Ciudad = "Salta", Email = "jorge.rodriguez@example.com", Telefono = "789123456" },
                    new Cliente { Id = 8, Nombre = "Sofia", Apellido = "Sanchez", Ciudad = "Santa Fe", Email = "sofia.sanchez@example.com", Telefono = "123789456" },
                    new Cliente { Id = 9, Nombre = "Diego", Apellido = "Ramirez", Ciudad = "San Juan", Email = "diego.ramirez@example.com", Telefono = "456789123" },
                    new Cliente { Id = 10, Nombre = "Lucia", Apellido = "Torres", Ciudad = "CABA", Email = "lucia.torres@example.com", Telefono = "987123654" }
                );
            }
        }


        #endregion
    }
}
