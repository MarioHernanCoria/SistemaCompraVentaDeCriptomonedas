using SistemaCompraVentaDeCriptomonedas.Enums;

namespace SistemaCompraVentaDeCriptomonedas.DTOs
{
    public class ExtraerRequestDto
    {
        public TipoCuentaEnum Tipo { get; set; }
        public double Monto { get; set; }
        public string NumeroCuenta { get; set; }
        public string EmailUsuario { get; set; }
    }
}