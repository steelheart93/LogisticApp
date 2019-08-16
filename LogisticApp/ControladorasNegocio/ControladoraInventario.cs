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
    public class ControladoraInventario : ControllerBase
    {
        private readonly <dbcontext> _context;

        public ControladoraInventario(<dbcontext> context)
        {
            _context = context;
        }

        public JsonResult getInventario()
        {
            return _context.Productos.ToList();
        }

        public JsonResult filtrarInventario(string datosProducto)
        {
            return _context.SalidaExistencias.find(datosProducto);
        }
    }
}
