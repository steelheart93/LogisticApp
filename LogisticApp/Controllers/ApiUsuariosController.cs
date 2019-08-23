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
    [Route("api/usuarios")]
    [ApiController]
    public class ApiUsuariosController : ControllerBase
    {
        private readonly AccesoDatos accesoDatos;

        public ApiUsuariosController(AccesoDatos accesoDatos)
        {
            this.accesoDatos = accesoDatos;
        }


        // GET logisticapp.com/api/usuarios
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return ControladoraUsuarios.getUsuarios(accesoDatos).ToList();
        }

        // POST logisticapp.com/api/usuarios { "Codigo": "...", ... }
        [HttpPost]
        public ActionResult AddUsuario(Usuario usuario)
        {
            try
            {
                ControladoraUsuarios.addUsuario(usuario, accesoDatos);
            }
            catch (UsuarioYaExisteException ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

        // GET logisticapp.com/api/usuarios/filtrar "<datoUsuario>"
        [HttpGet("filtrar")]
        public ActionResult<IEnumerable<Usuario>> FiltrarUsuarios([FromBody] String datoUsuario)
        {
            return ControladoraUsuarios.filtrarUsuarios(datoUsuario, accesoDatos).ToList();
        }

        // PUT logisticapp.com/api/usuarios { "Codigo": "...", ... }
        [HttpPut]
        public ActionResult ModificarUsuario(Usuario usuario)
        {
            try
            {
                ControladoraUsuarios.modificarUsuario(usuario, accesoDatos);
            }
            catch (UsuarioYaExisteException ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

        // DELETE logisticapp.com/api/usuarios "<codigoUsuario>"
        [HttpDelete]
        public ActionResult EliminarUsuario([FromBody] string codigoUsuario)
        {
            try
            {
                ControladoraUsuarios.desactivarUsuario(codigoUsuario, accesoDatos);
            }
            catch (UsuarioNoExisteException ex)
            {
                return BadRequest(ex.Message);
            }
            
            return NoContent();
        }
    }
}