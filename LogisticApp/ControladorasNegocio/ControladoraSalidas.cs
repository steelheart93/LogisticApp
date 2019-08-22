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
            List<SalidaDetallada> listaSalidas = new List<SalidaDetallada>
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

        public JsonResult filtrarSalidas()
        {
            return _context.SalidaExistencias.find();
        }

        public void addSalida(string codigoProducto, SalidaExistencia salida)
        {
            _context.Productos.addSalidaExistencia(salida);
            _context.SaveChanges();
        }
    }
}
