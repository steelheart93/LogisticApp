using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogisticApp.Entidades
{
    public class Usuario
    {
        public enum PerfilUsuario { Operario, Supervisor, Administrador };

        [Key]
        public string Codigo { get; private set; }
        public string Documento { get; set; }
        public string Contraseña { get; set; }
        // TODO: pensar si se puede cambiar realmente el perfil
        public PerfilUsuario Perfil { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        [EmailAddress]
        public string Correo { get; set; }
        // TODO: revisar si esta validación funciona con los teléfonos de Colombia bella querida
        //[Phone]
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; private set; }

        private Usuario()
        {

        }

        public static IEnumerable<Usuario> getUsuarios()
        {
            return null;
        }

        public static Usuario GetUsuario(string Codigo)
        {
            return null;
        }

        public static void addUsuario(Usuario usuario)
        {

        }

        public static void actualizarUsuario(Usuario usuario)
        {

        }

        public static void modificarUsuario(Usuario usuario)
        {

        }

        public static void desactivarUsuario(string CodigoUsuario)
        {
            GetUsuario(CodigoUsuario).desactivar();
        }

        public void desactivar()
        {
            Activo = false;
        }


    }
}
