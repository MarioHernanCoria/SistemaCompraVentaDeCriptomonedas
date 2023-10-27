using SistemaCompraVentaDeCriptomonedas.Entities;
using SistemaCompraVentaDeCriptomonedas.Enums;

namespace SistemaCompraVentaDeCriptomonedas.DTOs
{
    public class UsuarioRequestDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public List<Rol>? Roles { get; set; }
        public List<Cuenta>? Cuentas { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public GeneroEnum Genero { get; set; }
        public EstadoCivilEnum EstadoCivil { get; set; }
    }
}
