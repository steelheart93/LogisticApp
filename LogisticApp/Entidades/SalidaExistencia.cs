using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogisticApp.Entidades
{
    public class SalidaExistencia
    {
        [Key]
        public string codigo { get; private set; }
        public DateTime fechaHoraRegistro { get; private set; }
        public string destino { get; private set; }
        public string observaciones { get; private set; }

        public Dictionary<EntradaLote, int> lotesSalida { get; private set; }
        public Usuario registrador { get; private set; }

        /// <summary>
        /// Método usado para obtener la cantidad de productos totales de una salida
        /// </summary>        /// 
        /// <returns>cantidad de productos totales de la salida(int)</returns>
        public int getCantidadSalida()
        {
            int cantidadSalida = 0;
            foreach (KeyValuePair<EntradaLote, int> kvp in lotesSalida)
            {
                cantidadSalida += kvp.Value;
            }
            //return (from salida in lotesSalida select salida.Value).Sum();
            return cantidadSalida;
        }
    }
}