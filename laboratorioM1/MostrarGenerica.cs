using System;

namespace laboratorioM1
{
    public class MostrarGenerica<T>
    {
        T valor;

        public MostrarGenerica( T valor)
        {
            this.valor = valor;
        }

        public void show() 
        {
            Console.WriteLine($"El contenido de esta clase es {this.valor} y su tipo es {this.valor.GetType().Name}");
        }

    }
}
