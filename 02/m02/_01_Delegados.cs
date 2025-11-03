
using System.Transactions;

namespace m02
{
	public class Delegados
	{
		// DELEGADOS
		// Los delegados son un tipo especial de objeto que se utiliza para representar y referenciar métodos. Actúan como punteros a funciones, pero son seguros en cuanto a tipos.

		// Sintaxis básica de un delegado:
		//		delegate tipoDeRetorno NombreDelegado(parametros);
		// Donde:
		//		- tipoDeRetorno es el tipo de dato que el delegado devolverá.
		//		- NombreDelegado es el nombre que le das al delegado.
		//	    - parametros son los parámetros que toma el delegado. Pueden ser opcionales según el caso.

		internal static void Demos()
		{
			Console.WriteLine("Delegados");
			Console.WriteLine("-----------------------------------\n");

			//DemoDelegadosBasicos1();

			//DemoDelegadosBasicos2();

			//DemoDelegadosBasicos3();

			//DemoDelegadosConGenerics();

			//DemoDelegadosAvanzados1();

            // herramientas qeu tiene instaladas : 
            // extensione -> administrar extensiones
            //    .net nanoFramework extension
            //    adaptador de prueba para boost.test
            //    dotfuscado comunity
            //  herramientas de azure data lake y strem..
            //  incredibuid build aceleretion
            //  liveshare 2022
            //  markdown editor v2
            //  microsoft 385 agents toolkit
            //  microsoft library manager
            //  ml.net model buildes 2022
            //  python-c** proyect debugging syuport
            //  python - profilling
            //  single project MSIX packagin tools for...
            //  test adapter para google test
            //  visual studio snapboot debugger
            //  windows app SDK c# vs2022 template
            // work flow manager activities
            // xamarin android  SDK

		}

        #region DemoDelegadosBasicos1
        // Sintaxis básica de un delegado:
        //	delegate tipoDeRetorno NombreDelegado(parametros);
        public delegate void MiDelegado(string mensaje);

		private static void DemoDelegadosBasicos1()
		{
			// Crear una instancia del delegado y asignarle un método
			MiDelegado delegado = MostrarMensaje;

			// Invocar el delegado
			delegado("Hola desde el delegado!");


			// Asignar otro método al delegado
			delegado = MostrarMensajeEnMayusculas;

			// Invocar el delegado
			delegado("Hola desde el delegado en mayúsculas!");

            // para que sirve delegado > para cambiar comportamiento de una variable en ejecucio
		}

		// metodo que se usa a traves de delegado
        public static void MostrarMensaje(string mensaje)
		{
			Console.WriteLine(mensaje);
		}
		public static void MostrarMensajeEnMayusculas(string mensaje)
		{
			Console.WriteLine(mensaje.ToUpper());
		}
        #endregion

        #region DemoDelegadosBasicos2

        public delegate void ImprimirMensaje(string mensaje);

        private static void DemoDelegadosBasicos2()
        {
            Console.WriteLine("Delegados Básicos 2");
            Console.WriteLine("-----------------------------------\n");

            // Creación de una instancia del delegado y asignación de un método
            ImprimirMensaje imprimir = ImprimirEnConsola;

            // Llamada al delegado para imprimir un mensaje en la consola
            imprimir.Invoke("Hola, mundo!");

            // Reasignación del delegado a otro método
            imprimir = ImprimirEnArchivo;
            // Llamada al delegado para imprimir un mensaje en un archivo
            imprimir.Invoke("Este mensaje se guarda en un archivo.");
        }

        public static void ImprimirEnConsola(string mensaje)
        {
            Console.WriteLine("Imprimiendo en la consola: " + mensaje);
        }

        public static void ImprimirEnArchivo(string mensaje)
        {
            string filePath = "mensaje.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(mensaje);
            }
            Console.WriteLine("Guardando en un archivo: " + mensaje);
        }

        #endregion

        #region DemoDelegadosBasicos3
        delegate double OperacionMatematica(double a, double b);

        private static void DemoDelegadosBasicos3()
        {
            Console.WriteLine("Delegados Básicos 3");
            Console.WriteLine("-----------------------------------\n");

            OperacionMatematica operacion;
            double resultado;

            operacion = Sumar;
            resultado = operacion(10, 7);
            Console.WriteLine($"Operación: {operacion.Method.Name} | resultado: {resultado}");

            operacion = Restar;
            resultado = operacion(8, 4);
            Console.WriteLine($"Operación: {operacion.Method.Name} | resultado: {resultado}");

            operacion = Multiplicar;
            resultado = operacion(15, 3);
            Console.WriteLine($"Operación: {operacion.Method.Name} | resultado: {resultado}");

            operacion = Dividir;
            resultado = operacion(30, 5);
            Console.WriteLine($"Operación: {operacion.Method.Name} | resultado: {resultado}");
        }

        static double Sumar(double a, double b) { return a + b; }
        static double Restar(double a, double b) { return a - b; }
        static double Multiplicar(double x, double y) { return x * y; }
        static double Dividir(double x, double y) { return x / y; }
        #endregion

        #region DemoDelegadosAvanzados
        /*
		Delegados Multicast
			Los delegados multicast son delegados que pueden 
            hacer referencia a múltiples métodos. 
            Cuando se invoca un delegado multicast, 
            se ejecutan todos los métodos a los que hace referencia.
		 */

        public delegate void NotificacionHandler(string mensaje);

        public class NotificacionEmail
        {
            public void EnviarEmail(string mensaje)
            {
                Console.WriteLine($"Enviando correo electrónico: {mensaje}");
            }
        }

        public class NotificacionSMS
        {
            public void EnviarSMS(string mensaje)
            {
                Console.WriteLine($"Enviando SMS: {mensaje}");
            }
        }

        public class NotificacionWhatsApp
        {
            public void EnviarWhatsApp(string mensaje)
            {
                Console.WriteLine($"Enviando WhatsApp: {mensaje}");
            }
        }

        public class ProcesadorTransacciones
        {
            public NotificacionHandler Notificacion { get; set; } = delegate { };

            public void ProcesarTransaccion(string transaccion)
            {
                Console.WriteLine($"Procesando transacción: {transaccion}");
                Notificacion?.Invoke($"Transacción {transaccion} procesada con éxito.");
            }
        }

        private static void DemoDelegadosAvanzados()
        {
            Console.WriteLine("Delegados Avanzados");
            Console.WriteLine("-----------------------------------\n");

            // Crear instancias de las clases de notificación
            var notificadorEmail = new NotificacionEmail();
            var notificadorSMS = new NotificacionSMS();
            var notificadorWhatsApp = new NotificacionWhatsApp();

            // Instanciar el procesador de transacciones
            var procesador = new ProcesadorTransacciones();

            // Agregar métodos al delegado multicast
            procesador.Notificacion += notificadorEmail.EnviarEmail;
            procesador.Notificacion += notificadorSMS.EnviarSMS;
            procesador.Notificacion += notificadorWhatsApp.EnviarWhatsApp;

            // Procesar una transacción
            procesador.ProcesarTransaccion("12345");

            // Eliminar un método del delegado
            procesador.Notificacion -= notificadorSMS.EnviarSMS;

            // Procesar otra transacción
            Console.WriteLine("\nDespués de eliminar el método SMS:");
            procesador.ProcesarTransaccion("67890");
        }
        #endregion
    }
}
