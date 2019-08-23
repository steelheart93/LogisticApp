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
        private ControladoraUsuarios()
        {

        }

        public static IEnumerable<Usuario> getUsuarios(AccesoDatos accesoDatos)
        {
            return Usuario.getUsuarios(accesoDatos); //chulito
        }

        /*
        public Usuario GetUsuario(string Codigo)
        {
            return Usuario.GetUsuario(Codigo);
        }*/

        public static void addUsuario(Usuario usuario, AccesoDatos accesoDatos)
        {
            Usuario.addUsuario(usuario, accesoDatos);
        }

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

        public static void modificarUsuario(Usuario usuario, AccesoDatos accesoDatos)
        {
            Usuario.actualizarUsuario(usuario, accesoDatos);
        }

        public static void desactivarUsuario(string codigo, AccesoDatos accesoDatos)
        {
            Usuario.desactivarUsuario(codigo, accesoDatos);
        }
    }
}
