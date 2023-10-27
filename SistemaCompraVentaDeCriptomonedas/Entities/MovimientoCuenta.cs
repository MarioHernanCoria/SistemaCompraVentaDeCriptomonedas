namespace SistemaCompraVentaDeCriptomonedas.Entities
{
    public class MovimientoCuenta
    {
        public int Id { get; set; }
        public Cuenta CuentaOrigen { get; set; }
        public Cuenta CuentaDestino { get; set; }
        public int CuentaDestinoId { get; set; }
        public int CuentaOrigenId { get; set; }
    }
}