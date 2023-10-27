using SistemaCompraVentaDeCriptomonedas.Entities;
using System.ComponentModel.DataAnnotations;

namespace SistemaCompraVentaDeCriptomonedas.DTOs
{
    public class AgregarCuentaRequestDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public CuentaDto Cuenta { get; set; }
    }
}