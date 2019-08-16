using System;
using System.Collections.Generic;
using LogisticApp.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticApp.ControladorasNegocio
{
    public class ControladoraProductos
    {
        private ControladoraProductos()
        {
            
        }

        public static IEnumerable<Producto> getProductos()
        {
            return Producto.getProductos();
        }

        public static void agregarProducto(Producto producto)
        {
            Producto.addProducto(producto);
        }

        public static IEnumerable<Producto> filtrarProductos(string datoProducto)
        {
            return from producto in Producto.getProductos()
                   where producto.codigo.Contains(datoProducto)
                    || producto.nombre.ToLower().Contains(datoProducto)
                    || producto.familia.ToLower().Contains(datoProducto)
                   select producto;
        }

        public static void modificarProducto(Producto producto)
        {
            Producto.actualizarProducto(producto);
        }

        public static void desactivarProducto(string codigoProducto)
        {
            Producto.desactivarProducto(codigoProducto);
        }
    }
}