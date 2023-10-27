using SistemaCompraVentaDeCriptomonedas.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaCompraVentaDeCriptomonedas.DTOs
{
    public class TransferirRequestDto
    {
        [Required]
        public string EmailOrigen { get; set; }
        [Required]
        public string EmailDestino { get; set; }
        [Required]
        public CuentaDto CuentaOrigen { get; set; }
        [Required]
        public CuentaDto CuentaDestino { get; set; }
        [Required]
        public double Monto { get; set; }
        [Required]
        public DiscriminadorCuentaEnum TipoCuenta { get; set; }
    }
}