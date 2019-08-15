using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticApp.Entidades
{
    public class Usuario
    {
        [Key]
        public string Codigo { get; private set; }
        public string Documento { get; private set; }
        public string Contraseña { get; set; }
        public Enum Perfil { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }

        private Usuario()
        {

        }

        public static IEnumerable<Usuario> getUsuarios()
        {

        }

        public static Usuario GetUsuario(string Codigo)
        {
            
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
            
        }

        public void desactivarUsuario()
        {
            Activo = false;
        }


    }
}
