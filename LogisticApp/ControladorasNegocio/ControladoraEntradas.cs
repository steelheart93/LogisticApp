using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticApp.ControladorasNegocio
{
    public class ControladoraEntradas : ControllerBase
    {
        /**
         * Método que retorna la información de las Entrada para la Vista
         */
        public IEnumerable<EntradaDetallada> getEntradas()
        {
            List<EntradaDetallada> listaEntradas = new List<EntradaDetallada> { };

            IEnumerable<Producto> productos = Producto.getProductos();
            foreach (Producto p in productos)
            {
                IEnumerable<EntradaLote> entradas = p.getEntradasLotes();
                foreach (EntradaLote e in entradas)
                {
                    r = e.registrador;
                    string nombreCompleto = r.nombres + r.apellidos;

                    listaEntradas.Add(new EntradaDetallada(e.codigo, e.fechaHoraRegistro,
                        e.ubicacion, e.origen, e.cantidadInicial, e.observaciones,
                        p.codigo, p.nombre, r.codigo, nombreCompleto));
                }
            }

            return listaEntradas;
        }

        /**
         * Método agrega una nueva entrada al Contexto
         */
        public void addEntrada(string codigoProducto, EntradaLote entrada)
        {
            Producto p = Producto.getProducto(codigoProducto);
            p.addEntradaLote(entrada);
        }

        /**
         * Método que retorna la lista de Entradas Filtradas por un dato de la Entrada.
         */
        public IEnumerable<EntradaDetallada> getEntradas(String datoEntrada)
        {
            List<EntradaDetallada> listaEntradas = new List<EntradaDetallada> { };

            IEnumerable<Producto> productos = Producto.getProductos();
            foreach (Producto p in productos)
            {
                IEnumerable<EntradaLote> entradas = p.getEntradasLotes();
                foreach (EntradaLote e in entradas)
                {
                    if (e.codigo == datoEntrada || e.ubicacion == datoEntrada || e.origen == datoEntrada || p.nombre == datoEntrada)
                        r = e.registrador;
                    string nombreCompleto = r.nombres + r.apellidos;

                    listaEntradas.Add(new EntradaDetallada(e.codigo, e.fechaHoraRegistro,
                        e.ubicacion, e.origen, e.cantidadInicial, e.observaciones,
                        p.codigo, p.nombre, r.codigo, nombreCompleto));
                }
            }

            return listaEntradas;
        }
    }
}
