using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticApp.ControladorasNegocio;
using LogisticApp.Entidades;
using LogisticApp.Excepciones;
using LogisticApp.Persistencia;
using LogisticApp.VistasModelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticApp.Controllers
{
    [Route("api/entradas")]
    [ApiController]
    public class ApiEntradasController : ControllerBase
    {
        private readonly AccesoDatos accesoDatos;

        public ApiEntradasController(AccesoDatos accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }


        // GET logisticapp.com/api/entradas
        [HttpGet]
        public ActionResult<IEnumerable<EntradaDetallada>> GetUsuarios()
        {
            return ControladoraEntradas.GetEntradas(accesoDatos).ToList();
        }

        // POST logisticapp.com/api/entradas { "Codigo": "...", ... }
        [HttpPost("{codigoProducto}")]
        public ActionResult AddSalida(string codigoProducto, EntradaLote entrada)
        {
            ControladoraEntradas.AddEntrada(codigoProducto, entrada, accesoDatos);
            return NoContent();
        }

        // GET logisticapp.com/api/entradas/filtrar "<datoEntrada>"
        [HttpGet("filtrar")]
        public ActionResult<IEnumerable<EntradaDetallada>> FiltrarSalidas([FromBody] String datoEntrada)
        {
            return ControladoraEntradas.FiltrarEntradas(datoEntrada, accesoDatos).ToList();
        }
    }
}