using SistemaCompraVentaDeCriptomonedas.Enums;

namespace SistemaCompraVentaDeCriptomonedas.DTOs
{
    public class CuentaFiduciariaDto
    {
        public string CBU { get; set; }
        public string Alias { get; set; }
        public string NumeroCuenta { get; set; }
        public double Saldo { get; set; }
        public TipoCuentaEnum Tipo { get; set; }

    }
}
