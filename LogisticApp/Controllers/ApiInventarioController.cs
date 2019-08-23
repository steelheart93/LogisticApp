using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticApp.ControladorasNegocio;
using LogisticApp.Entidades;
using LogisticApp.Excepciones;
using LogisticApp.Persistencia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticApp.Controllers
{
    [Route("api/inventario")]
    [ApiController]
    public class ApiInventarioController : ControllerBase
    {
        private readonly AccesoDatos accesoDatos;

        public ApiInventarioController(AccesoDatos accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }


        // GET logisticapp.com/api/inventario
        [HttpGet]
        public ActionResult<IEnumerable<InventarioDetallado>> GetInventario()
        {
            return ControladoraInventario.getInventario(accesoDatos).ToList();
        }

        // GET logisticapp.com/api/inventario/filtrar "<datoProducto>"
        [HttpGet("filtrar")]
        public ActionResult<IEnumerable<InventarioDetallado>> FiltrarUsuarios([FromBody] String datoUsuario)
        {
            return ControladoraInventario.filtrarInventario(datoUsuario, accesoDatos).ToList();
        }
       
    }
}