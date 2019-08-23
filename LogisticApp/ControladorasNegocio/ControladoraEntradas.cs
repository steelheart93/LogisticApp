using LogisticApp.Entidades;
using LogisticApp.Persistencia;
using LogisticApp.VistasModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticApp.ControladorasNegocio
{
    public class ControladoraEntradas
    {
        /**
         * Método que retorna la información de las Entrada para la Vista
         */
        public static IEnumerable<EntradaDetallada> GetEntradas(AccesoDatos accesoDatos)
        {
            List<EntradaDetallada> listaEntradas = new List<EntradaDetallada> { };

            IEnumerable<Producto> productos = Producto.getProductos(accesoDatos);
            foreach (Producto p in productos)
            {
                IEnumerable<EntradaLote> entradas = p.getEntradasLotes();
                foreach (EntradaLote e in entradas)
                {
                    Usuario r = e.Registrador;
                    string nombreCompleto = r.Nombres + r.Apellidos;

                    listaEntradas.Add(new EntradaDetallada(e.Codigo, e.FechaHoraRegistro,
                        e.Ubicacion, e.Origen, e.CantidadInicial, e.Observaciones,
                        p.codigo, p.nombre, r.Codigo, nombreCompleto));
                }
            }

            return listaEntradas;
        }

        /**
         * Método agrega una nueva entrada al Contexto
         */
        public static void AddEntrada(string codigoProducto, EntradaLote entrada, AccesoDatos accesoDatos)
        {
            Producto p = Producto.getProducto(codigoProducto, accesoDatos);
            p.addEntradaLote(entrada);
        }

        /**
         * Método que retorna la lista de Entradas Filtradas por un dato de la Entrada.
         */
        public static IEnumerable<EntradaDetallada> FiltrarEntradas(String datoEntrada, AccesoDatos accesoDatos)
        {
            List<EntradaDetallada> listaEntradas = new List<EntradaDetallada> { };

            IEnumerable<Producto> productos = Producto.getProductos(accesoDatos);
            foreach (Producto p in productos)
            {
                IEnumerable<EntradaLote> entradas = p.getEntradasLotes();
                foreach (EntradaLote e in entradas)
                {
                    if (e.Codigo == datoEntrada || e.Ubicacion == datoEntrada ||
                        e.Origen == datoEntrada || p.nombre == datoEntrada)
                    {
                        Usuario r = e.Registrador;
                        string nombreCompleto = r.Nombres + r.Apellidos;

                        listaEntradas.Add(new EntradaDetallada(e.Codigo, e.FechaHoraRegistro,
                            e.Ubicacion, e.Origen, e.CantidadInicial, e.Observaciones,
                            p.codigo, p.nombre, r.Codigo, nombreCompleto));
                    }

                }
            }

            return listaEntradas;
        }
    }
}
