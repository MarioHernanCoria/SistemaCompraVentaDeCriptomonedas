using SistemaCompraVentaDeCriptomonedas.Entities;
using SistemaCompraVentaDeCriptomonedas.Enums;

namespace SistemaCompraVentaDeCriptomonedas.DTOs
{
    public class MovimientosResponseDto
    {
        public string EmailUsuario { get; set; }

        public List<LogMovimientoDto> Movimientos { get; set; }
    }

  

}