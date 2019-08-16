using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogisticApp.Entidades
{
    public class Producto
    {

        [Key]
        public string codigo { get; private set; }
        public string nombre { get; set; }
        public int stockTotal { get; private set; }
        public string familia { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; private set;}
        public ICollection<EntradaLote> entradas { get; private set; }
        public ICollection<SalidaExistencia> salidas { get; private set; }

        // TODO: revisar si se usa este constructor
        public Producto(string codigo, string nombre, string familia, string descripcion)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.stockTotal = 0;
            this.familia = familia;
            this.descripcion = descripcion;
            this.activo = true;
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

        /// <summary>
        /// asdfkjasdñlkfjñlsff
        /// </summary>
        /// <param name="codigo">el código del producto a desactivar</param>
        public static void desactivarProducto(string codigo)
        {
            Producto producto = getProducto(codigo);
            producto.desactivar();
            actualizarProducto(producto);
        }

        public IEnumerable<EntradaLote> getEntradasLotes()
        {
            return entradas;
        }

        public IEnumerable<EntradaLote> getLotesActuales()
        {
            return from lote in entradas
                   where lote.cantidadActual > 0
                   select lote;
        }

        public IEnumerable<SalidaExistencia> getSalidasExistencias()
        {
            return salidas;
        }

        public void desactivar()
        {
            this.activo = false;
        }

        /* Ya no es necesario
        public void calcularStockTotal()
        {
            
        }*/

        public void addEntradaLote(EntradaLote entradaLote)
        {
            entradas.Add(entradaLote);
            stockTotal += entradaLote.cantidadActual;
        }

        public void addSalidaExistencia(SalidaExistencia salidaExistencia)
        {
            salidas.Add(salidaExistencia);
            // TODO: verificar que la cantidad de salida no supere la cantidad actual de producto
            //stockTotal -= salidaExistencia.cantidad;
        }

        public Dictionary<string, double> getIndicesRotacion(DateTime fechaInicial, DateTime fechaFinal)
        {
            // recuerde verificar que el periodo comprendido entre fecha inicial y final sea
            // válido para este método
            return null;
        }

        // TODO: Juan Pablo
        public double getDiasCobertura(DateTime fechaInicial, DateTime fechaFinal)
        {
            return 0;
        }

        // TODO: Elisa
        public Dictionary<string, double> getPronosticoVentas(DateTime fechaInicial, DateTime fechaFinal)
        {
            return null;
        }

    }
}