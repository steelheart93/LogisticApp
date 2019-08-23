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
    [Route("api/productos")]
    [ApiController]
    public class ApiProductosController : ControllerBase
    {
        private readonly AccesoDatos accesoDatos;

        public ApiProductosController(AccesoDatos accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }


        // GET logisticapp.com/api/productos
        [HttpGet]
        public ActionResult<IEnumerable<ProductoDetallado>> GetProductos()
        {
            return ControladoraProductos.getProductos(accesoDatos).ToList();
        }

        // POST logisticapp.com/api/productos { "Codigo": "...", ... }
        [HttpPost]
        public ActionResult AddProducto(Producto producto)
        {
            try
            {
                ControladoraProductos.agregarProducto(producto, accesoDatos);
            }
            catch (ProductoYaExisteException ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

        // GET logisticapp.com/api/productos/filtrar "<datoProducto>"
        [HttpGet("filtrar")]
        public ActionResult<IEnumerable<ProductoDetallado>> FiltrarProducto([FromBody] String datoProducto)
        {
            return ControladoraProductos.filtrarProductos(datoProducto, accesoDatos).ToList();
        }

        // PUT logisticapp.com/api/productos { "Codigo": "...", ... }
        [HttpPut]
        public ActionResult ModificarProducto(Producto producto)
        {
            try
            {
                ControladoraProductos.modificarProducto(producto, accesoDatos);
            }
            catch (ProductoYaExisteException ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

        // DELETE logisticapp.com/api/productos "<codigoProductos>"
        [HttpDelete]
        public ActionResult EliminarProductos([FromBody] string codigoProducto)
        {
            try
            {
                ControladoraProductos.desactivarProducto(codigoProducto, accesoDatos);
            }
            catch (ProductoNoExisteException ex)
            {
                return BadRequest(ex.Message);
            }
            
            return NoContent();
        }
    }
}