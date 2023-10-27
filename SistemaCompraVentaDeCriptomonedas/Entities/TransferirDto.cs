using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Enums;

namespace SistemaCompraVentaDeCriptomonedas.Entities
{
    public class TransferirDto
    {
        public string EmailOrigen { get; set; }
        public string EmailDestino { get; set; }
        public Cuenta CuentaOrigen { get; set; }
        public Cuenta CuentaDestino { get; set; }
        public double Monto { get; set; }
        public DiscriminadorCuentaEnum TipoCuenta { get; set; }
        public Usuario UsuarioOrigen { get; internal set; }
        public Usuario UsuarioDestino { get; internal set; }
    }
}