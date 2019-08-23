using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticApp.Entidades;
using System;

namespace LogisticApp.ControladorasNegocio
{
    public class ControladoraInventario : ControllerBase
    {
        /// <summary>
        /// Obtiene una lista de todos los productos con su stock actual, lotes y dias de cobertura
        /// </summary>
        /// <returns>lista de todos los productos con su stock actual, lotes y dias de cobertura</returns>
        public IEnumerable<InventarioDetallado> getInventario(DateTime fechaInicial, DateTime fechaFinal)
        {
            IEnumerable<Producto> productos = Producto.getProductos();
            IEnumerable<SalidaExistencia> salidas;
            List<InventarioDetallado> listaInventario = new List<InventarioDetallado> { };
            foreach (Producto p in productos)
            {
                salidas = p.getSalidasExistencias();
                double diasCobertura = p.getDiasCobertura(fechaInicial, fechaFinal);
                int stockActual = 0;
                IEnumerable<EntradaLote> lotes = p.getEntradasLotes();
                foreach (EntradaLote l in lotes)
                {
                    stockActual += l.cantidadActual;
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
        public IEnumerable<InventarioDetallado> filtrarInventario(DateTime fechaInicial, DateTime fechaFinal, string datoProducto)
        {
            IEnumerable<Producto> productos = Producto.getProductos();
            IEnumerable<SalidaExistencia> salidas;
            List<InventarioDetallado> listaInventario = new List<InventarioDetallado> { };
            foreach (Producto p in productos)
            {
                if (p.nombre == datoProducto || p.codigo == datoProducto)
                {
                    salidas = p.getSalidasExistencias();
                    double diasCobertura = p.getDiasCobertura(fechaInicial, fechaFinal);
                    int stockActual = 0;
                    IEnumerable<EntradaLote> lotes = p.getEntradasLotes();
                    foreach (EntradaLote l in lotes)
                    {
                        stockActual += l.cantidadActual;
                    }
                    listaInventario.Add(new InventarioDetallado(p.codigo, p.nombre, stockActual, diasCobertura, lotes));
                }
            }
            return listaInventario;
        }
    }
}
