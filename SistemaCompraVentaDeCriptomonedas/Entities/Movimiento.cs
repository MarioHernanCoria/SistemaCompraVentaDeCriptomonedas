namespace SistemaCompraVentaDeCriptomonedas.Entities
{
    public class Movimiento
    {
        public int Id { get; set; }
        public MovimientoCuenta MovimientaCuenta { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public MovimientoUsuario MovimientoUsuario { get; set; }
    }
}
