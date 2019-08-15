using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticApp.Entidades
{
    public class EntradaLote
    {
        public Usuario registrador { get; private set; }
        public string codigo { get; private set; }
        public int cantidadInicial { get; private set; }
        public int cantidadActual { get; private set; }
        public string origen { get; private set; }
        public DateTime fechaExpiracion { get; private set; }
        public DateTime fechaHoraRegistro { get; private set; }
        public string ubicacion { get; private set; }
        public string observaciones { get; private set; }

        public void decrementarCantidadActual(int cantidad)
        {
            cantidadActual -= cantidad;
        }

        private EntradaLote()
        {
            Console.WriteLine("Hola soy el constructor privado de EntradaLote, ¿Por alguna razón?");
        }
    }
}
