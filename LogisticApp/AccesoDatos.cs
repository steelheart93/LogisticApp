using LogisticApp.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticApp.Persistencia
{
    public class AccesoDatos : DbContext
    {
        public AccesoDatos(DbContextOptions<AccesoDatos> opciones) : base(opciones) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        //public DbSet<EntradaLote> Entradas { get; set; }
        //public DbSet<SalidaExistencia> Salidas { get; set; }
    }
}
