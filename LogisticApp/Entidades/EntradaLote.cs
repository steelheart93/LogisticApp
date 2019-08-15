using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticApp.Entidades
{
    public class EntradaLote
    {
        private Usuario registrador { get; set; }
        private string codigo { get; set; }
        private int cantidadInicial { get; set; }
        private int cantidadActual { get; set; }
        private string origen { get; set; }
        private DateTime fechaExpiracion { get; set; }
        private DateTime fechaHoraRegistro { get; set; }
        private string ubicacion { get; set; }
        private string observaciones { get; set; }
    }
}
