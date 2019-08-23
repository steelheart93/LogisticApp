using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using LogisticApp.Excepciones;
using LogisticApp.Persistencia;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticApp.Entidades
{
    public class Usuario
    {
        public enum PerfilUsuario { Operario, Supervisor, Administrador };

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Codigo { get; set; }
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

        /// <summary>
        /// Constructor privado de la clase
        /// Inicializa el atributo Activo en true
        /// </summary>
        private Usuario()
        {
            Activo = true;
        }

        /// <summary>
        /// Consulta todos los usuarios en la base de datos
        /// </summary>
        /// <param name="accesoDatos"></param>
        /// <returns>Retorna la lista de usuarios activos</returns>
        public static IEnumerable<Usuario> getUsuarios(AccesoDatos accesoDatos)
        {
            return accesoDatos.Usuarios.Where(u => u.Activo);
        }

        /// <summary>
        /// Consulta un usuario por su código
        /// </summary>
        /// <param name="Codigo"> Código del usuario a consultar</param>
        /// <param name="datos"></param>
        /// <returns> El usuario con el codigo ingresado</returns>
        public static Usuario GetUsuario(string Codigo, AccesoDatos datos)
        {
            Usuario usuario = datos.Usuarios.Find(Codigo);
            if (usuario == null)
            {
                throw new UsuarioNoExisteException(Codigo);
            }
            return usuario;
        }

        /// <summary>
        /// Método para agregar un usuario a la base de datos
        /// </summary>
        /// <param name="usuario"> El usuario a ingresar</param>
        /// <param name="accesoDatos"></param>
        public static void addUsuario(Usuario usuario, AccesoDatos accesoDatos)
        {
            try
            {
                GetUsuario(usuario.Codigo, accesoDatos);
                throw new UsuarioYaExisteException(usuario.Codigo);
            } catch (UsuarioNoExisteException) { }
            accesoDatos.Usuarios.Add(usuario);
            accesoDatos.SaveChanges();
        }

        /// <summary>
        /// Actualiza los datos de un usuario
        /// </summary>
        /// <param name="usuarioNuevo"> Datos actualizados del usuario</param>
        /// <param name="accesoDatos"></param>
        public static void actualizarUsuario(Usuario usuarioNuevo, AccesoDatos accesoDatos)
        {
            Usuario usuarioAntiguo = GetUsuario(usuarioNuevo.Codigo, accesoDatos); // Si no existe arroja exepción.
            usuarioAntiguo.copiarse(usuarioNuevo);
            accesoDatos.Entry(usuarioAntiguo).State = EntityState.Modified;
            accesoDatos.SaveChanges();
        }

        /// <summary>
        /// Método para desactivar el atributo Activo de un usuario
        /// </summary>
        /// <param name="codigo"> Código del usuario a desactivar </param>
        /// <param name="accesoDatos"></param>
        public static void desactivarUsuario(string CodigoUsuario, AccesoDatos accesoDatos)
        {
            Usuario usuario = GetUsuario(CodigoUsuario, accesoDatos);
            usuario.desactivar();
            accesoDatos.Entry(usuario).State = EntityState.Modified;
            accesoDatos.SaveChanges();
        }

        /// <summary>
        /// Asigna false al atributo Activo
        /// </summary>
        public void desactivar()
        {
            Activo = false;
        }

        /// <summary>
        /// Asigna datos actualizados a los atributos del usuario
        /// </summary>
        /// <param name="otro"></param>
        public void copiarse(Usuario otro)
        {
            this.Documento = otro.Documento;
            this.Contraseña = otro.Contraseña;
            this.Perfil = otro.Perfil;
            this.Nombres = otro.Nombres;
            this.Apellidos = otro.Apellidos;
            this.Correo = otro.Correo;
            this.Telefono = otro.Telefono;
            this.Direccion = otro.Direccion;
        }

    }
}
