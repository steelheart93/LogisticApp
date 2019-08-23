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
    [Route("api/salidas")]
    [ApiController]
    public class ApiSalidasController : ControllerBase
    {
        private readonly AccesoDatos accesoDatos;

        public ApiSalidasController(AccesoDatos accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }


        // GET logisticapp.com/api/salidas
        [HttpGet]
        public ActionResult<IEnumerable<SalidaDetallada>> GetUsuarios()
        {
            return ControladoraSalidas.getSalidas(accesoDatos).ToList();
        }

        // POST logisticapp.com/api/salidas { "Codigo": "...", ... }
        [HttpPost("{codigoProducto}")]
        public ActionResult AddSalida(string codigoProducto, SalidaExistencia salida)
        {
            ControladoraSalidas.addSalida(codigoProducto, salida, accesoDatos);
            return NoContent();
        }

        // GET logisticapp.com/api/usuarios/filtrar "<datoSalida>"
        [HttpGet("filtrar")]
        public ActionResult<IEnumerable<SalidaDetallada>> FiltrarSalidas([FromBody] String datoSalida)
        {
            return ControladoraSalidas.filtrarSalidas(datoSalida, accesoDatos).ToList();
        }

        // GET logisticapp.com/api/usuarios/lotesProducto "<codigoProducto>"
        [HttpGet("lotesProducto")]
        public ActionResult<IEnumerable<EntradaLote>> getLotesProducto([FromBody] String codigoProducto)
        {
            return ControladoraSalidas.getLotesProducto(codigoProducto, accesoDatos).ToList();
        }

    }
}