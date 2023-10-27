using SistemaCompraVentaDeCriptomonedas.DTOs;

namespace SistemaCompraVentaDeCriptomonedas.Servicios
{
    public interface ICurrencyChangeService
    {
        double GetCurrencyChange(ConvertirRequestDto convertir);
    }
}
