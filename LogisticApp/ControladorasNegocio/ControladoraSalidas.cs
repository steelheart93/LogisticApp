using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticApp.Entidades;

namespace LogisticApp.ControladorasNegocio
{
    public class ControladoraSalidas : ControllerBase
    {
        /// <summary>
        /// Obtiene todas los registros de salidas de productos
        /// </summary>
        /// <returns>salidas de productos(JsonResult)</returns>
        public IEnumerable<SalidaDetallada> getSalidas()
        {
            IEnumerable<Producto> productos = Producto.getProductos();
            IEnumerable<SalidaExistencia> salidas;
            List<SalidaDetallada> listaSalidas = new List<SalidaDetallada> {};
            foreach (Producto p in productos)
            {
                salidas = p.getSalidasExistencias();
                foreach (SalidaExistencia s in salidas)
                {
                    listaSalidas.Add(new SalidaDetallada(s.codigo, s.fechaHoraRegistro, s.destino, s.observaciones, p.codigo, p.nombre, s.lotesSalida, s.registrador));
                }
            }
            return listaSalidas;
        }
        /// <summary>
        /// Añade un registro de salida en el producto indicado
        /// </summary>
        /// <param name="codigoProducto">Código del producto al que se le agregará la salida</param>
        /// <param name="salida">Registro de la salida con todos los datos necesarios</param>
        public void addSalida(string codigoProducto, SalidaExistencia salida)
        {
            Producto p = Producto.getProducto(codigoProducto);
            p.addSalidaExistencia(salida);
        }
        /// <summary>
        /// Obtiene los lotes existentes para el producto referenciado
        /// </summary>
        /// <param name="codigoProducto">Código del producto del que se desea obtener los lotes</param>
        /// <returns>Lotes del producto referenciado(IEnumerable<EntradaLote>)</returns>
        public IEnumerable<EntradaLote> getLotesProducto(string codigoProducto)
        {
            Producto p = Producto.getProducto(codigoProducto);
            return p.getEntradasLotes();
        }
        /// <summary>
        /// Filtra las salidas mediante un dato de texto entrante que puede ser el código de la salida, código o nombre del producto
        /// </summary>
        /// <param name="datoSalida">dato por medio del cual se hace el filtrado</param>
        /// <returns>Lista de salidas que coinciden con la búsqueda(JsonResult)</returns>
        public IEnumerable<SalidaDetallada> filtrarSalidas(string datoSalida)
        {
            IEnumerable<Producto> productos = Producto.getProductos();
            IEnumerable<SalidaExistencia> salidas;
            List<SalidaDetallada> listaSalidas = new List<SalidaDetallada> { };
            foreach (Producto p in productos)
            {
                salidas = p.getSalidasExistencias();
                foreach (SalidaExistencia s in salidas)
                {
                    if (s.codigo == datoSalida || p.nombre == datoSalida || p.codigo == datoSalida)
                    {
                        listaSalidas.Add(new SalidaDetallada(s.codigo, s.fechaHoraRegistro, s.destino, s.observaciones, p.codigo, p.nombre, s.lotesSalida, s.registrador));
                    }                    
                }
            }
            return listaSalidas;
        }
    }
}
