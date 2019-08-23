using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticApp.Entidades
{
    public class SalidaExistencia
    {
        [Key]
        public string codigo { get; private set; }
        public DateTime fechaHoraRegistro { get; private set; }
        public string destino { get; private set; }
        public string observaciones { get; private set; }

        //[NotMapped]
        //public Dictionary<EntradaLote, int> lotesSalida { get; private set; }

        public ICollection<LoteSalida> lotesSalida { get; private set; }
        public Usuario registrador { get; private set; }

        [ForeignKey("registrador")]
        public string codigoRegistrador { get; private set; }

        /// <summary>
        /// Método usado para obtener la cantidad de productos totales de una salida
        /// </summary>        /// 
        /// <returns>cantidad de productos totales de la salida(int)</returns>
        public int getCantidadSalida()
        {
            int cantidadSalida = 0;
            foreach (LoteSalida lote in lotesSalida)
            {
                cantidadSalida += lote.cantidadSalida;
            }
            //return (from salida in lotesSalida select salida.Value).Sum();
            return cantidadSalida;
        }
    }

    public class LoteSalida
    {
        public EntradaLote lote { get; private set; }
        public int cantidadSalida { get; private set; }
    }
}