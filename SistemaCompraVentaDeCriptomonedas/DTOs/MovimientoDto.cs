using MiNET.Utils;
using SistemaCompraVentaDeCriptomonedas.Entities;

namespace SistemaCompraVentaDeCriptomonedas.DTOs
{
    public class MovimientoDto
    {
        public int UsuarioId {  get; set; }
        public int CuentaFiduciariaOrigen { get; set; }
        public UUID CuentaCriptoOrigen { get; set; }
        public int CuentaFiduciariaDestino { get; set; }
        public UUID CuentaCriptoDestino { get; set; }
        public decimal Saldo { get; set; }
        public decimal MontoIngresado { get; set; }
    }
}
