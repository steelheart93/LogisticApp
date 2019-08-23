using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticApp.Entidades
{
    public class EntradaLote
    {
        // TODO: buscar la manera de que el usuario solo ingrese el código del
        // registrador y que el sistema sea el que ponga el Usuario registrador.
        public Usuario Registrador { get; private set; }

        [ForeignKey("Registrador")]
        public string codigoRegistrador { get; private set; }

        [Key]
        public string codigo { get; private set; }

        [Range(1, int.MaxValue)]
        public int cantidadInicial { get; private set; }
        // TODO: buscar la manera de que la cantidad actual se inicialice con la 
        // cantidad inicial
        public int cantidadActual { get; private set; }
        public string origen { get; private set; }
        public DateTime fechaExpiracion { get; private set; }
        // TODO: buscar la manera de que el sistema sea el que ponga la fecha y
        // hora de registro
        public DateTime fechaHoraRegistro { get; private set; }
        public string ubicacion { get; private set; }
        public string observaciones { get; private set; }

        public void decrementarCantidadActual(int cantidad)
        {
            if (cantidad > cantidadActual || cantidad < 0)
            {
                throw new Excepciones.CantidadNoValidaException(cantidad);
            }

            cantidadActual -= cantidad;
        }

        // Es opcional poner un constructor privado.
        private EntradaLote()
        {
            Console.WriteLine("Hola soy el constructor privado de EntradaLote, ¿Por alguna razón?");
        }
    }
}
