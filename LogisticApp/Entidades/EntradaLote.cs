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
        public Usuario registrador { get; private set; }

        [ForeignKey("registrador")]
        public string CodigoRegistrador { get; private set; }

        [Key]
        public string Codigo { get; private set; }

        [Range(1, int.MaxValue)]
        public int CantidadInicial { get; private set; }
        // TODO: buscar la manera de que la cantidad actual se inicialice con la 
        // cantidad inicial
        public int CantidadActual { get; private set; }
        public string Origen { get; private set; }
        public DateTime FechaExpiracion { get; private set; }
        // TODO: buscar la manera de que el sistema sea el que ponga la fecha y
        // hora de registro
        public DateTime FechaHoraRegistro { get; private set; }
        public string Ubicacion { get; private set; }
        public string Observaciones { get; private set; }

        public void DecrementarCantidadActual(int cantidad)
        {
            if (cantidad > CantidadActual || cantidad < 0)
            {
                throw new Excepciones.CantidadNoValidaException(cantidad);
            }

            CantidadActual -= cantidad;
        }

        // Es opcional poner un constructor privado.
        private EntradaLote()
        {
            Console.WriteLine("Hola soy el constructor privado de EntradaLote, ¿Por alguna razón?");
        }
    }
}
