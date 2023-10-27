using SistemaCompraVentaDeCriptomonedas.Enums;

namespace SistemaCompraVentaDeCriptomonedas.DTOs
{
    public class RolDto
    {
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public RolEnum Tipo { get; internal set; }
        public int UsuarioId { get; internal set; }
    }
}
