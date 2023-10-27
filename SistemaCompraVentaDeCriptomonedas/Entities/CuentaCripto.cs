using SistemaCompraVentaDeCriptomonedas.DTOs;

namespace SistemaCompraVentaDeCriptomonedas.Entities
{
    public class CuentaCripto : Cuenta
    {
        public string UUID { get; set; } = Guid.NewGuid().ToString();
        public string NombreCripto { get; set; }

    }
}
