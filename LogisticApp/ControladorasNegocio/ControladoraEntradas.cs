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
        public IEnumerable<EntradaDetallada> GetEntradas()
        {
            List<EntradaDetallada> listaEntradas = new List<EntradaDetallada> { };

            IEnumerable<Producto> productos = Producto.GetProductos();
            foreach (Producto p in productos)
            {
                IEnumerable<EntradaLote> entradas = p.GetEntradasLotes();
                foreach (EntradaLote e in entradas)
                {
                    r = e.Registrador;
                    string nombreCompleto = r.Nombres + r.Apellidos;

                    listaEntradas.Add(new EntradaDetallada(e.Codigo, e.FechaHoraRegistro,
                        e.Ubicacion, e.Origen, e.CantidadInicial, e.Observaciones,
                        p.Codigo, p.Nombre, r.Codigo, nombreCompleto));
                }
            }

            return listaEntradas;
        }

        /**
         * Método agrega una nueva entrada al Contexto
         */
        public void AddEntrada(string codigoProducto, EntradaLote entrada)
        {
            Producto p = Producto.getProducto(codigoProducto);
            p.addEntradaLote(entrada);
        }

        /**
         * Método que retorna la lista de Entradas Filtradas por un dato de la Entrada.
         */
        public IEnumerable<EntradaDetallada> GetEntradas(String datoEntrada)
        {
            List<EntradaDetallada> listaEntradas = new List<EntradaDetallada> { };

            IEnumerable<Producto> productos = Producto.GetProductos();
            foreach (Producto p in productos)
            {
                IEnumerable<EntradaLote> entradas = p.GetEntradasLotes();
                foreach (EntradaLote e in entradas)
                {
                    if (e.Codigo == datoEntrada || e.Ubicacion == datoEntrada ||
                        e.Origen == datoEntrada || p.Nombre == datoEntrada)
                    {
                        r = e.Registrador;
                        string nombreCompleto = r.Nombres + r.Apellidos;

                        listaEntradas.Add(new EntradaDetallada(e.Codigo, e.FechaHoraRegistro,
                            e.Ubicacion, e.Origen, e.CantidadInicial, e.Observaciones,
                            p.Codigo, p.Nombre, r.Codigo, nombreCompleto));
                    }

                }
            }

            return listaEntradas;
        }
    }
}
