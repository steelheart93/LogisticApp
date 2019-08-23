using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticApp.Entidades;
using LogisticApp.Persistencia;
using System;

namespace LogisticApp.ControladorasNegocio
{
    public class ControladoraInventario : ControllerBase
    {
        /// <summary>
        /// Obtiene una lista de todos los productos con su stock actual, lotes y dias de cobertura
        /// </summary>
        /// <returns>lista de todos los productos con su stock actual, lotes y dias de cobertura</returns>
        public static IEnumerable<InventarioDetallado> getInventario(AccesoDatos accesoDatos)
        {
            IEnumerable<Producto> productos = Producto.getProductos(accesoDatos);
            IEnumerable<SalidaExistencia> salidas;
            List<InventarioDetallado> listaInventario = new List<InventarioDetallado> { };
            foreach (Producto p in productos)
            {
                salidas = p.getSalidasExistencias();
                double diasCobertura = p.getDiasCobertura();
                int stockActual = 0;
                IEnumerable<EntradaLote> lotes = p.getEntradasLotes();
                foreach (EntradaLote l in lotes)
                {
                    stockActual += l.CantidadActual;
                }
                listaInventario.Add(new InventarioDetallado(p.codigo, p.nombre, stockActual, diasCobertura, lotes));
                
            }
            return listaInventario;
        }
        /// <summary>
        /// Filtra el inventario según el parámetro de texto que recibe
        /// </summary>
        /// <param name="datoProducto">texto según el cual se realiza el filtrado</param>
        /// <returns>Lista de salidas que coinciden con la búsqueda(JsonResult)</returns>
        public static IEnumerable<InventarioDetallado> filtrarInventario(string datoProducto, AccesoDatos accesoDatos)
        {
            IEnumerable<Producto> productos = Producto.getProductos(accesoDatos);
            IEnumerable<SalidaExistencia> salidas;
            List<InventarioDetallado> listaInventario = new List<InventarioDetallado> { };
            foreach (Producto p in productos)
            {
                if (p.nombre == datoProducto || p.codigo == datoProducto)
                {
                    salidas = p.getSalidasExistencias();
                    double diasCobertura = p.getDiasCobertura();
                    int stockActual = 0;
                    IEnumerable<EntradaLote> lotes = p.getEntradasLotes();
                    foreach (EntradaLote l in lotes)
                    {
                        stockActual += l.CantidadActual;
                    }
                    listaInventario.Add(new InventarioDetallado(p.codigo, p.nombre, stockActual, diasCobertura, lotes));
                }
            }
            return listaInventario;
        }
    }
}
