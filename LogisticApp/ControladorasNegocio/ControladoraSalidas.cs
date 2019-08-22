using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticApp.Entidades;
using LogisticApp.VistasModelos;

namespace LogisticApp.ControladorasNegocio
{
    public class ControladoraSalidas : ControllerBase
    {
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

        public void addSalida(string codigoProducto, SalidaExistencia salida)
        {
            Producto p = Producto.getProducto(codigoProducto);
            p.addSalidaExistencia(salida);
        }

        public IEnumerable<EntradaLote> getLotesProducto(string codigoProducto)
        {
            Producto p = Producto.getProducto(codigoProducto);
            return p.getEntradasLotes();
        }

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
