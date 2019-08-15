using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticApp.ControladorasNegocio
{
    public class ControladoraUsuarios
    {
        public IEnumerable<Usuario> getUsuarios()
        {
            return Usuario.getUsuarios();
        }

        public Usuario GetUsuario(string Codigo)
        {
            return Usuario.getUsuario(codigo);
        }

        public void addUsuario(Usuario usuario)
        {
            Usuario.addUsuario(usuario);
        }

        public IEnumerable<Usuario> filtrarUsuarios(string datoUsuario)
        {
            Usuario.filtrarUsuario(datoUsuario);
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
