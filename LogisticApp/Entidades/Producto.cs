using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticApp.Entidades
{
    public class Producto
    {

        [Key]
        [Required]
        public string codigo { get; private set; }
        [Required]
        public string nombre { get; set; }
        public int stockTotal { get; private set; }
        public string familia { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; private set;}
        public virtual ICollection<EntradaLote> entradaLote { get; set; }

        public Producto(string codigo, string nombre, string familia, string descripcion)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.stockTotal = 0;
            this.familia = familia;
            this.descripcion = descripcion;
            this.estado = true;
        }

        public static IEnumerable<Producto> getProductos()
        {
            return null;
        }

        public static Producto getProducto(string codigo)
        {
            return null;
        }

        public static Producto addProducto(Producto producto)
        {
            return null;
        }

        public static void actualizarProducto(Producto producto)
        {

        }

        public static void desactivarProducto(string codigo)
        {

        }

        public IEnumerable<EntradaLote> getEntradasLotes()
        {
            return null;
        }

        public IEnumerable<EntradaLote> getLotesActuales()
        {
            return null;
        }

        public IEnumerable<SalidaExistencia> getSalidasExistencias()
        {
            return null;
        }

        public void desactivar()
        {
            this.estado = false;
        }

        public void calcularStockTotal()
        {
            
        }

        public void addEntradaLote(EntradaLote entradaLote)
        {

        }

        public void addSalidaExistencia(SalidaExistencia salidaExistencia)
        {

        }

        public Dictionary<string, double> getIndicesRotacion(DateTime fechaInicial, DateTime fechaFinal)
        {
            return null;
        }

        public double getDiasCobertura(DateTime fechaInicial, DateTime fechaFinal)
        {
            return 0;
        }

        public Dictionary<string, double> getPronosticoVentas(DateTime fechaInicial, DateTime fechaFinal)
        {
            return null;
        }

    }
}