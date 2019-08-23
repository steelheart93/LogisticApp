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
    public class Producto
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int stockTotal { get; private set; }
        public string familia { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; private set;}
        public ICollection<EntradaLote> entradas { get; private set; }
        public ICollection<SalidaExistencia> salidas { get; private set; }


        private Producto()
        {
            this.activo = true;
        }

        ///<summary>
        ///Constructor parametrizado
        /// </summary>
        public Producto(string codigo, string nombre, string familia, string descripcion)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.stockTotal = 0;
            this.familia = familia;
            this.descripcion = descripcion;
            this.activo = true;
        }


        ///<summary>
        ///Consulta en la tabla productos de la base de datos todos los productos
        /// </summary>
        /// <returns>Retorna todos los productos de la base de datos</returns>
        public static IEnumerable<Producto> getProductos(AccesoDatos accesoDatos)
        {
            return accesoDatos.Productos.Where(p => p.activo);
        }


        ///<summary>
        ///Consulta en la tabla productos de la base de datos un producto en especifico
        /// </summary>
        /// <param name="codigo">codigo del producto deseado</param>
        /// <returns>Retorna el objeto producto que se busca</returns>
        public static Producto getProducto(string codigo, AccesoDatos datos)
        {
            Producto producto = datos.Productos.Find(codigo);
            if (producto == null)
            {
                throw new ProductoNoExisteException(codigo);
            }
            return producto;
        }

        ///<summary>
        ///Agrega a la base de datos en la tabla producto un nuevo producto
        /// </summary>
        /// <param name="producto">producto a ingresar</param>
        /// <returns>Retorna el objeto producto ingresado</returns>
        public static void addProducto(Producto producto, AccesoDatos accesoDatos)
        {
            try
            {
                getProducto(producto.codigo, accesoDatos);
                throw new ProductoYaExisteException(producto.codigo);
            } catch (ProductoNoExisteException) { }
            accesoDatos.Productos.Add(producto);
            accesoDatos.SaveChanges();
        }

        ///<summary>
        ///Actualiza en la base de datos en la tabla producto un producto
        /// </summary>
        /// <param name="producto">producto a ser actualizado</param>
        public static void actualizarProducto(Producto productoNuevo, AccesoDatos accesoDatos)
        {
            Producto productoAntiguo = getProducto(productoNuevo.codigo, accesoDatos); // Si no existe arroja exepción.
            productoAntiguo.copiarse(productoNuevo);
            accesoDatos.Entry(productoAntiguo).State = EntityState.Modified;
            accesoDatos.SaveChanges();
        }

        ///<summary>
        ///Desactiva el atributo activo de un producto
        /// </summary>
        /// <param name="codigo">codigo del producto a desactivar</param>
        public static void desactivarProducto(string codigo, AccesoDatos accesoDatos)
        {
            Producto producto = getProducto(codigo, accesoDatos);
            producto.desactivar();
            accesoDatos.Entry(producto).State = EntityState.Modified;
            accesoDatos.SaveChanges();
        }

        ///<summary>
        ///Copia cada parametro de un nuevo producto al actual
        /// </summary>
        /// <param name="otro">Producto a ser copiado</param>
        public void copiarse(Producto otro)
        {
            this.codigo = otro.codigo;
            this.nombre = otro.nombre;
            this.stockTotal = otro.stockTotal;
            this.familia = otro.familia;
            this.descripcion = otro.descripcion;
            this.activo = otro.activo;
            this.entradas = otro.entradas;
            this.salidas = otro.salidas;
    }

        ///<summary>
        ///Consulta todas las entradas asociadas al producto
        /// </summary>
        /// <returns>retorna todas las entradas del producto</returns>
        public IEnumerable<EntradaLote> getEntradasLotes()
        {
            return entradas;
        }

        ///<summary>
        ///Consulta todos los lotes que tengan como minimo 1 producto
        /// </summary>
        /// <returns>retorna todos los lotes del producto</returns>
        public IEnumerable<EntradaLote> getLotesActuales()
        {
            return from lote in entradas
                   where lote.CantidadActual > 0
                   select lote;
        }

        ///<summary>
        ///Consulta todas las salidas de existencias del producto
        /// </summary>
        /// <returns>retorna todas las salidas del producto</returns>
        public IEnumerable<SalidaExistencia> getSalidasExistencias()
        {
            return salidas;
        }

        ///<summary>
        ///Desactiva el producto
        /// </summary>
        public void desactivar()
        {
            this.activo = false;
        }

        ///<summary>
        ///Agrega una nueva entrada del producto
        /// </summary>
        /// <param name="entradaLote">Lote a ingresar a base de datos</param>
        public void addEntradaLote(EntradaLote entradaLote)
        {
            entradas.Add(entradaLote);
            stockTotal += entradaLote.CantidadActual;
        }

        ///<summary>
        ///Agrega una nueva salida del producto
        /// </summary>
        /// <param name="salidaExistencia">Engresa la salida deseada</param>
        public void addSalidaExistencia(SalidaExistencia salidaExistencia)
        { 
            if (this.stockTotal >= salidaExistencia.getCantidadSalida())
            {
                salidas.Add(salidaExistencia);
                this.stockTotal -= salidaExistencia.getCantidadSalida();
            }
            else
            {
                throw new CantidadNoValidaException(salidaExistencia.getCantidadSalida());
            }
        }

        ///<summary>
        ///Consulta el indice de rotación de un producto entre un pediodo determinado
        /// </summary>
        /// <param name="fechaFinal">fecha final del periodo deseado</param>
        /// <param name="fechaInicial">fecha inicial del periodo deseado</param>
        /// <returns>retorna el periodo y el indice calculado</returns>
        public Dictionary<string, double> getIndicesRotacion(DateTime fechaInicial, DateTime fechaFinal)
        {
            // recuerde verificar que el periodo comprendido entre fecha inicial y final sea
            // válido para este método
            return null;
        }


        ///Consulta los dias de cobertura del producto
        /// </summary>
        /// <param name="fechaFinal">fecha final del periodo deseado</param>
        /// <param name="fechaInicial">fecha inicial del periodo deseado</param>
        /// <returns>retorna calculo de los días de cobertura</returns>
        public double getDiasCobertura()
        {
            DateTime fechaInicial = new DateTime();
            DateTime fechaFinal = new DateTime();
            Boolean primeraVez = true;
            double vendidos = 0;
            double dias = 1;
            double stockTotal = 0;
            double ventasDiarias = 1;
            double respuesta = 0;
            foreach (SalidaExistencia salida in this.salidas)
            {
                if (primeraVez)
                {
                    fechaInicial = salida.fechaHoraRegistro;
                    fechaFinal = salida.fechaHoraRegistro;
                }                
                if (salida.fechaHoraRegistro < fechaInicial)
                {
                    fechaInicial = salida.fechaHoraRegistro;
                }
                if (salida.fechaHoraRegistro > fechaFinal)
                {
                    fechaFinal = salida.fechaHoraRegistro;
                }
                vendidos += salida.getCantidadSalida();
            }
            stockTotal = (double)this.stockTotal;
            TimeSpan ts = fechaFinal - fechaInicial;
            dias = ts.Days;
            if (dias > 0)
            {
                ventasDiarias = vendidos / dias;
            }
            if (ventasDiarias > 0)
            {
                respuesta = stockTotal / ventasDiarias;
            }
            return respuesta;
        }

        ///<summary>
        ///Realiza un pronostico de las futuras ventas
        /// </summary>
        /// <param name="fechaFinal">fecha final del periodo deseado</param>
        /// <param name="fechaInicial">fecha inicial del periodo deseado</param>
        /// <returns>retorna indicadores y valores pronosticados</returns>
        // TODO: Elisa
        public Dictionary<string, double> getPronosticoVentas(DateTime fechaInicial, DateTime fechaFinal)
        {
            int resultado = DateTime.Compare(fechaInicial, fechaFinal);
            
            Dictionary<string, double> ventas = new Dictionary<string, double>();
            double suma=0;
            int meses=0;
            
            if (resultado>=0)
            {
                throw new PeriodoNoValidoException(fechaInicial, fechaFinal);
            }

            foreach (SalidaExistencia salida in this.salidas)
            {
                if(salida.fechaHoraRegistro >= fechaInicial && salida.fechaHoraRegistro <= fechaFinal)
                {
                    string mesAno = salida.fechaHoraRegistro.Month.ToString()+salida.fechaHoraRegistro.Year.ToString();
                    if(ventas.Contains(mesAno)){
                        ventas[mesAno] = ventas[mesAno] + salida.getCantidadSalida();
                    }
                    else{
                        ventas.Add(mesAno,salida.getCantidadSalida);
                        meses+=1;
                    }
                    suma+=salida.getCantidadSalida;
                }
            }            

            ventas.Add(fechaFinal.AddMonths(1).Month.ToString()+fechaFinal.Year.ToString(),(suma/meses));

            return ventas;
        }

    }
}