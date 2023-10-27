using SistemaCompraVentaDeCriptomonedas.Enums;

namespace SistemaCompraVentaDeCriptomonedas.DTOs
{
    public class LogMovimientoDto
    {
        public int Id { get; set; }
        public string EmailUsuario { get; set; }
        public string NumeroCuenta { get; set; }
        public string EmailDestino { get; set; }
        public string NumeroCuentaDestino { get; set; }
        public double Monto { get; set; }
        public TipoCuentaEnum TipoCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public TipoMovimientoEnum TipoMovimiento { get; set; }
    }
}