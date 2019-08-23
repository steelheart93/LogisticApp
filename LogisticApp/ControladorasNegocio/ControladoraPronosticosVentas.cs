using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticApp.Entidades;
using LogisticApp.Persistencia;

namespace LogisticApp.ControladorasNegocio
{
    public class ControladoraPronosticosVentas
    {
        /// <summary>
        /// Realiza un pronostico de las futuras ventas de un producto
        /// </summary>
        /// <param name="codigoProducto"> Código del producto a realizar el pronóstico</param>
        /// <param name="fechaInicial"> Fecha inicial del periodo a calcular</param>
        /// <param name="fechafinal"> Fecha final del periodo a calcular</param>
        /// <param name="accesoDatos"></param>
        public static Dictionary<string, double> getPronosticosVentas(string codigoProducto, DateTime fechaInicial, DateTime fechaFinal, AccesoDatos accesoDatos)
        {
            Producto producto = Producto.getProducto(codigoProducto, accesoDatos);

            return producto.getPronosticoVentas(fechaInicial, fechaFinal);
        }
    }
}
