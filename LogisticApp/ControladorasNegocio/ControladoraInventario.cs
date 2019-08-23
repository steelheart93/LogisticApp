using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticApp.Entidades;

namespace LogisticApp.ControladorasNegocio
{
    public class ControladoraInventario : ControllerBase
    {
        public IEnumerable<SalidaDetallada> getInventario()
        {
            IEnumerable<Producto> productos = Producto.getProductos();
            IEnumerable<SalidaExistencia> salidas;
            List<SalidaDetallada> listaSalidas = new List<SalidaDetallada> { };
            foreach (Producto p in productos)
            {
                salidas = p.getSalidasExistencias();
                double diasCobertura = p.getDiasCobertura();
                int stockActual = 0;
                IEnumerable<EntradaLote> lotes = p.getEntradasLotes();
                foreach (EntradaLote l in lotes)
                {
                    stockActual += l.cantidadActual;
                }
                listaSalidas.Add(new InventarioDetallado(p.codigo, p.nombre, stockActual, diasCobertura, lotes));
                
            }
            return listaSalidas;
        }

        public IEnumerable<SalidaDetallada> filtrarInventario(string datoProducto)
        {
            IEnumerable<Producto> productos = Producto.getProductos();
            IEnumerable<SalidaExistencia> salidas;
            List<SalidaDetallada> listaSalidas = new List<SalidaDetallada> { };
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
                        stockActual += l.cantidadActual;
                    }
                    listaSalidas.Add(new InventarioDetallado(p.codigo, p.nombre, stockActual, diasCobertura, lotes));
                }
            }
            return listaSalidas;
        }
    }
}
