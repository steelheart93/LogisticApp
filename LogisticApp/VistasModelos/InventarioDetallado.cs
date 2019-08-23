using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogisticApp.Entidades
{
    public class InventarioDetallado
    {
        public string codigo;
        public string nombre;
        public int stockActual;
        public string diasCobertura;
        public IEnumerable<EntradaLote> lotes;
        public InventarioDetallado(string codigo, string nombre, int stockActual, string diasCobertura, IEnumerable<EntradaLote> lotes)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.stockActual = stockActual;
            this.diasCobertura = diasCobertura;
            this.lotes = lotes;
        }
    }
}