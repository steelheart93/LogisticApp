using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticApp.Entidades;
using LogisticApp.Persistencia;

namespace LogisticApp.ControladorasNegocio
{
    public class ControladoraUsuarios
    {
        /// <summary>
        /// Constructor privado de la clase
        /// </summary>
        private ControladoraUsuarios()
        {

        }

        /// <summary>
        /// Consulta todos los usuarios en la base de datos
        /// </summary>
        /// <param name="accesoDatos"></param>
        /// <returns>Retorna la lista de usuarios</returns>
        public static IEnumerable<Usuario> getUsuarios(AccesoDatos accesoDatos)
        {
            return Usuario.getUsuarios(accesoDatos); //chulito
        }

        /*
        public Usuario GetUsuario(string Codigo)
        {
            return Usuario.GetUsuario(Codigo);
        }*/

        /// <summary>
        /// Método para agregar un usuario a la base de datos
        /// </summary>
        /// <param name="usuario"> El usuario a ingresar</param>
        /// <param name="accesoDatos"></param>
        public static void addUsuario(Usuario usuario, AccesoDatos accesoDatos)
        {
            Usuario.addUsuario(usuario, accesoDatos);
        }

        /// <summary>
        /// Método para filtrar usuarios por un dato especifico
        /// </summary>
        /// <param name="datoUsuario"> Dato a buscar del usuario </param>
        /// <param name="accesoDatos"></param>
        /// <returns> El usuario con la coincidencia del dato buscado </returns>
        public static IEnumerable<Usuario> filtrarUsuarios(string datoUsuario, AccesoDatos accesoDatos)
        {
            //Usuario.filtrarUsuario(datoUsuario);
            string dato = datoUsuario.ToLower();
            return from usuario in Usuario.getUsuarios(accesoDatos)
                   where usuario.Codigo.Contains(dato)
                    || usuario.Documento.Contains(dato)
                    || usuario.Nombres.ToLower().Contains(dato)
                    || usuario.Apellidos.ToLower().Contains(dato)
                   select usuario;
                   
        }

        /// <summary>
        /// Método para modificar un usuario
        /// </summary>
        /// <param name="usuario"> Usuario a modificar </param>
        /// <param name="accesoDatos"></param>
        public static void modificarUsuario(Usuario usuario, AccesoDatos accesoDatos)
        {
            Usuario.actualizarUsuario(usuario, accesoDatos);
        }

        /// <summary>
        /// Método para desactivar el atributo Activo de un usuario
        /// </summary>
        /// <param name="codigo"> Código del usuario a desactivar </param>
        /// <param name="accesoDatos"></param>
        public static void desactivarUsuario(string codigo, AccesoDatos accesoDatos)
        {
            Usuario.desactivarUsuario(codigo, accesoDatos);
        }
    }
}
