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
    [Route("api/pronosticos")]
    [ApiController]
    public class ApiPronosticosController : ControllerBase
    {
        private readonly AccesoDatos accesoDatos;

        public ApiPronosticosController(AccesoDatos accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }


        // GET logisticapp.com/api/pronosticos
        [HttpGet]
        public ActionResult GetPronosticosVentas(string codigoProducto, DateTime fechaInicial, DateTime fechafinal)
        {
            return ControladoraPronosticosVentas.getPronosticosVentas(codigoProducto, fechaInicial, fechafinal, accesoDatos);
        }

        
    }
}