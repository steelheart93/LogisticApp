using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticApp.VistasModelos
{

    public class ProductoDetallado
    {
        public string codigo;
        public string nombre;
        public int stockTotal;
        public string familia;
        public string descripcion;
        public bool activo;

        ///<summary>
        ///Constructor parametrizado
        /// </summary>
        public ProductoDetallado(string codigo, string nombre, int stockTotal, string familia, string descripcion, bool activo)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.stockTotal = stockTotal;
            this.familia = familia;
            this.descripcion = descripcion;
            this.activo = activo;
        }
    }
}
