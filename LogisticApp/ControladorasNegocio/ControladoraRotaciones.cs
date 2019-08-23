using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticApp.ControladorasNegocio
{
    public class ControladoraRotaciones
    {
        private ControladoraRotaciones()
        {

        }
        /*
        public JsonResult GetIndicesRotacion(DateTime fecha)
        {
            
        }
        */

        public JsonResult filtrarIndicesRotacion(DateTime fecha, string datoProducto)
        {
            return null;
        }

        public JsonResult getIndicesRotacionProducto(string codigoProducto, DateTime fechaInicial, DateTime fechaFinal)
        {
            return null;
        }
    }
}
