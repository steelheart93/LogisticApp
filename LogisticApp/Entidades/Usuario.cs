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

        private Usuario()
        {
            Activo = true;
        }

        public static IEnumerable<Usuario> getUsuarios(AccesoDatos accesoDatos)
        {
            return accesoDatos.Usuarios.Where(u => u.Activo);
        }

        public static Usuario GetUsuario(string Codigo, AccesoDatos datos)
        {
            Usuario usuario = datos.Usuarios.Find(Codigo);
            if (usuario == null)
            {
                throw new UsuarioNoExisteException(Codigo);
            }
            return usuario;
        }

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

        public static void actualizarUsuario(Usuario usuarioNuevo, AccesoDatos accesoDatos)
        {
            Usuario usuarioAntiguo = GetUsuario(usuarioNuevo.Codigo, accesoDatos); // Si no existe arroja exepción.
            usuarioAntiguo.copiarse(usuarioNuevo);
            accesoDatos.Entry(usuarioAntiguo).State = EntityState.Modified;
            accesoDatos.SaveChanges();
        }

        public static void desactivarUsuario(string CodigoUsuario, AccesoDatos accesoDatos)
        {
            Usuario usuario = GetUsuario(CodigoUsuario, accesoDatos);
            usuario.desactivar();
            accesoDatos.Entry(usuario).State = EntityState.Modified;
            accesoDatos.SaveChanges();
        }

        public void desactivar()
        {
            Activo = false;
        }

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
