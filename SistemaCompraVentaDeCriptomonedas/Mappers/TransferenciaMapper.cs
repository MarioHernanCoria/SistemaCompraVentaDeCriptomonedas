using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Entities;

namespace SistemaCompraVentaDeCriptomonedas.Mappers
{
    public static class TransferenciaMapper
    {
        public static TransferirDto Map(TransferirRequestDto input)
        { 
            var output = new TransferirDto();
            output.EmailDestino = input.EmailDestino;
            output.Monto = input.Monto;
            output.TipoCuenta = input.TipoCuenta;
            output.EmailOrigen = input.EmailOrigen;
            output.CuentaOrigen = CuentaMapper.Map(input.CuentaOrigen);      
            output.CuentaDestino = CuentaMapper.Map(input.CuentaDestino);
            return output;
        }
    }
}
