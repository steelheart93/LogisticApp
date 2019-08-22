using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogisticApp.Entidades
{
    public class SalidaDetallada
    {
        public string codigo;
        public DateTime fechaHoraRegistro;
        public string destino;
        public string observaciones;
        public string codigoProducto;
        public string nombreProducto;
        public Dictionary<EntradaLote, int> lotesSalida;
        public Usuario registrador;
        public SalidaDetallada(string codigo, DateTime fechaHoraRegistro, string destino, string observaciones, string codigoProducto, string nombreProducto, Dictionary<EntradaLote, int> lotesSalida, Usuario registrador)
        {
            this.codigo = codigo;
            this.fechaHoraRegistro = fechaHoraRegistro;
            this.destino = destino;
            this.observaciones = observaciones;
            this.codigoProducto = codigoProducto;
            this.nombreProducto = nombreProducto;
            this.lotesSalida = lotesSalida;
            this.registrador = registrador;
        }
    }
}