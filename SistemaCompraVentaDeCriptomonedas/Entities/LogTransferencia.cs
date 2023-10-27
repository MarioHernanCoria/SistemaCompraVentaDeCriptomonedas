using SistemaCompraVentaDeCriptomonedas.Enums;

namespace SistemaCompraVentaDeCriptomonedas.Entities
{
    public class LogTransferencia : LogMovimiento
    {
        public int Id { get; set; }
        public string EmailDestino { get; set; }
        public string NumeroCuentaDestino { get; set; }
       
    }
}