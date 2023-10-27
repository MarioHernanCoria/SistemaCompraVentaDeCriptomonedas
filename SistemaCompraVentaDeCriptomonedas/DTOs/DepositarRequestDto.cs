using SistemaCompraVentaDeCriptomonedas.Entities;
using SistemaCompraVentaDeCriptomonedas.Enums;

namespace SistemaCompraVentaDeCriptomonedas.DTOs
{
    public class DepositarRequestDto
    {
        public TipoCuentaEnum Tipo { get; set; }
        public double Monto { get; set; }
        public string NumeroCuenta { get; set; }
        public string EmailUsuario { get; set; }
    }
}