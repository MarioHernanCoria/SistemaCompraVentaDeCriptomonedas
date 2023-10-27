using SistemaCompraVentaDeCriptomonedas.Enums;

namespace SistemaCompraVentaDeCriptomonedas.Entities
{
    public class CuentaFiduciaria : Cuenta
    {
        public int Id { get; set; }
        public string CBU { get; set; }
        public string Alias { get; set; }
        public string NumeroCuenta { get; set; }
        public TipoCuentaEnum Tipo { get; set; }

    }
}
