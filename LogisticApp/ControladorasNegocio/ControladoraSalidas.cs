using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticApp.Entidades;

namespace LogisticApp.ControladorasNegocio
{
    [Route("api/controladorasNegocio")]
    [ApiController]
    public class ControladoraSalidas : ControllerBase
    {
        private readonly <dbcontext> _context;

        public ControladoraSalidas(<dbcontext> context)
        {
            _context = context;
        }

        public JsonResult getSalidas()
        {
            return _context.SalidaExistencias.ToList();
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
