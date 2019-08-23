using System;
using System.Collections.Generic;
using LogisticApp.Entidades;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogisticApp.VistasModelos;

namespace LogisticApp.ControladorasNegocio
{
    public class ControladoraProductos : ControllerBase
    {

        ///<summary>
        ///Consulta en la tabla productos de la base de datos todos los productos
        /// </summary>
        /// <returns>Retorna todos los productos de la base de datos</returns>
        public static IEnumerable<ProductoDetallado> getProductos()
        {
            IEnumerable<Producto> productos = Producto.getProductos();
            List<ProductoDetallado> listaProductos = new List<ProductoDetallado> {};
            foreach (Producto p in productos)
            {
                listaProductos.Add(new ProductoDetallado(p.codigo, p.nombre, p.stockTotal,p.familia, p.descripcion,p.activo));
                
            }
            return listaProductos;

        }

        ///<summary>
        ///Agrega a la base de datos en la tabla producto un nuevo producto
        /// </summary>
        /// <param name="producto">producto a ingresar</param>
        /// <returns>Retorna el objeto producto ingresado</returns>
        public static void agregarProducto(Producto producto)
        {
            Producto.addProducto(producto);
        }

        ///<summary>
        ///Consulta en la tabla productos de la base de datos un producto en especifico
        /// </summary>
        /// <param name="datoProducto">codigo o nombre o familia del producto deseado</param>
        /// <returns>Retorna el objeto producto que se busca</returns>
        public static IEnumerable<ProductoDetallado> filtrarProductos(string datoProducto)
        {
            IEnumerable<Producto> productos = Producto.getProductos();
            List<ProductoDetallado> listaProducto = new List<ProductoDetallado> { };

            foreach (Producto p in productos)
            {
                if (p.codigo.Equals(datoProducto) || p.nombre.Equals(datoProducto) || p.familia.Equals(datoProducto))
                {
                    listaProducto.Add(new ProductoDetallado(p.codigo, p.nombre, p.stockTotal, p.familia, p.descripcion, p.activo));
                }
                
            }
            return listaProducto;

        }

        ///<summary>
        ///Actualiza en la base de datos en la tabla producto un producto
        /// </summary>
        /// <param name="producto">producto a ser actualizado</param>
        public static void modificarProducto(Producto producto)
        {
            Producto.actualizarProducto(producto);
        }

        ///<summary>
        ///Desactiva el atributo activo de un producto
        /// </summary>
        /// <param name="codigo">codigo del producto a desactivar</param>
        public static void desactivarProducto(string codigoProducto)
        {
            Producto.desactivarProducto(codigoProducto);
        }
    }
}