namespace SistemaCompraVentaDeCriptomonedas.Entities
{
    public class MovimientoUsuario
    {
        public int Id { get; set; }
        public Usuario UsuarioOrigen { get; set; }
        public Usuario UsuarioDestino { get; set; }
        public int UsuarioOrigenId { get; internal set; }
        public int UsuarioDestinoId { get; internal set; }
    }
}