using System.ComponentModel.DataAnnotations;

namespace SistemaCompraVentaDeCriptomonedas.DTOs
{
    public class CuentaDto
    {
        public CuentaCriptoDto? CuentaCripto { get; set; }
        public CuentaFiduciariaDto? CuentaFiduciaria { get; set; }
    }
}
