using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticApp.Entidades;

namespace LogisticApp.ControladorasNegocio
{
    public class ControladoraUsuarios
    {
        private ControladoraUsuarios()
        {

        }

        public static IEnumerable<Usuario> getUsuarios()
        {
            return Usuario.getUsuarios(); //chulito
        }

        public Usuario GetUsuario(string Codigo)
        {
            return Usuario.GetUsuario(Codigo);
        }

        public void addUsuario(Usuario usuario)
        {
            Usuario.addUsuario(usuario);
        }

        public IEnumerable<Usuario> filtrarUsuarios(string datoUsuario)
        {
            //Usuario.filtrarUsuario(datoUsuario);
            string dato = datoUsuario.ToLower();
            return from usuario in Usuario.getUsuarios()
                   where usuario.Codigo.Contains(dato)
                    || usuario.Documento.Contains(dato)
                    || usuario.Nombres.ToLower().Contains(dato)
                    || usuario.Apellidos.ToLower().Contains(dato)
                   select usuario;
                   
        }

        public void modificarUsuario(Usuario usuario)
        {
            Usuario.modificarUsuario(usuario);
        }

        public void desactivarUsuario(string codigo)
        {
            Usuario.desactivarUsuario(codigo);
        }
    }
}
