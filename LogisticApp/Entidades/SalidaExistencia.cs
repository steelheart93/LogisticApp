using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticApp.Entidades
{
    public class SalidaExistencia
    {
        public string codigo { get; }
        public DateTime fechaHoraRegistro { get; }
        public string destino { get; }
        public string observaciones { get; }

        public Dictionary<EntradaLote, int> lotesSalida { get; }
        public Usuario registrador { get; }

        public int getCantidadSalida()
        {
            int cantidadSalida = 0;
            foreach (KeyValuePair<EntradaLote, int> kvp in lotesSalida)
            {
                cantidadSalida += kvp.Value;
            }
            return cantidadSalida;
        }
    }
}