using SistemaCompraVentaDeCriptomonedas.Enums;

namespace SistemaCompraVentaDeCriptomonedas.Entities
{
    public class LogMovimiento
    {
        public int Id { get; set; }
        public string EmailUsuario { get; set; }
        public string NumeroCuenta { get; set; }
        public double Monto { get; set; }
        public string Discriminator { get; set; }
        public TipoCuentaEnum TipoCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public TipoMovimientoEnum TipoMovimiento { get; set; }
    }
}