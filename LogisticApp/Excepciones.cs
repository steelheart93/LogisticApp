using System;

namespace LogisticApp.Excepciones
{
    public class UsuarioYaExisteException : Exception
    {
        public UsuarioYaExisteException(String codigoUsuario)
            : base($"Ya existe un usuario con código '{codigoUsuario}'.") { }
    }

    public class UsuarioNoExisteException : Exception
    {
        public UsuarioNoExisteException(String codigoUsuario)
            : base($"No existe un usuario con código '{codigoUsuario}'.") { }
    }

    public class ContraseñaIncorrectaException : Exception { }

    public class ProductoYaExisteException : Exception
    {
        public ProductoYaExisteException(String codigoProducto)
            : base($"Ya existe un producto con código '{codigoProducto}'.") { }
    }

    public class ProductoNoExisteException : Exception
    {
        public ProductoNoExisteException(String codigoProducto)
            : base($"No existe un producto con código '{codigoProducto}'.") { }
    }

    public class CantidadNoValidaException : Exception
    {
        public CantidadNoValidaException(double cantidad)
            : base($"Cantidad ({cantidad}) no válida.") { }
    }

    public class PeriodoNoValidoException : Exception
    {
        public PeriodoNoValidoException(DateTime fechaInicial, DateTime fechaFinal)
            : base($"El periodo comprendido entre {fechaInicial} y {fechaFinal} no es válido.") { }
    }

    public class FechaNoValidaException : Exception
    {
        public FechaNoValidaException(DateTime fecha)
            : base($"La fecha ({fecha}) no es válida.") { }
    }

    public class LoteProductoNoExisteException : Exception
    {
        public LoteProductoNoExisteException(String codigoLote)
            : base($"No existe un lote con código '{codigoLote}'.") { }
    }

    public class CantidadSalidaExcedeActualException : Exception
    {
        public CantidadSalidaExcedeActualException(double cantidadSalida, double cantidadActual)
            : base($"La cantidad de salida ({cantidadSalida}) de producto excede a la actual ({cantidadActual}).") { }
    }
}
