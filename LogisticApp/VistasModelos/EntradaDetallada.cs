using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogisticApp.VistasModelos
{
    public class EntradaDetallada
    {
        // Datos de la Entrada
        public string codigo { get; private set; }
        public DateTime fechaHoraRegistro { get; private set; }
        public string ubicacion { get; private set; }
        public string origen { get; private set; }
        public string cantidadInicial { get; private set; }
        public string observaciones { get; private set; }

        // Datos del Producto
        public string codigoProducto { get; private set; }
        public string nombreProducto { get; private set; }

        // Datos del Registrador
        public string codigoRegistrador { get; private set; }
        public string nombreRegistrador { get; private set; }


        /**
         * Constructor de la Clase Entrada Detallada 
         */
        public EntradaDetallada(string codigo, DateTime fechaHoraRegistro,
            string ubicacion, string origen, string cantidadInicial, string observaciones,
            string codigoProducto, string nombreProducto, string codigoRegistrador, string nombreRegistrador)
        {
            this.codigo = codigo;
            this.fechaHoraRegistro = fechaHoraRegistro;
            this.ubicacion = ubicacion;
            this.origen = origen;
            this.cantidadInicial = cantidadInicial;
            this.observaciones = observaciones;
            this.codigoProducto = codigoProducto;
            this.nombreProducto = nombreProducto;
            this.codigoRegistrador = codigoRegistrador;
            this.nombreRegistrador = nombreRegistrador;
        }
    }
}