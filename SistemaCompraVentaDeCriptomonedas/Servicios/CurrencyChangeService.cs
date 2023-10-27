using SistemaCompraVentaDeCriptomonedas.DTOs;

namespace SistemaCompraVentaDeCriptomonedas.Servicios
{
    public class CurrencyChangeService : ICurrencyChangeService
    {
        public double GetCurrencyChange(ConvertirRequestDto convertir)
        {
            string from = convertir.MonedaOrigen;
            string to = convertir.MonedaDestino;

            //Simulación el tipo de cambio , desde un servicio externo.
            return from switch
            {
                "USD" => to switch
                {
                    "ARS" => 980,
                    "BTC" => 0.0001,
                    "ETH" => 0.001,
                    _ => 0,
                },
                "ARS" => to switch
                {
                    "USD" => 0.01,
                    "BTC" => 0.0000001,
                    "ETH" => 0.000001,
                    _ => 0,
                },
                "BTC" => to switch
                {
                    "USD" => 10000,
                    "ARS" => 1000000,
                    "ETH" => 10,
                    _ => (double)0,
                },
                "ETH" => to switch
                {
                    "USD" => 1000,
                    "ARS" => 100000,
                    "BTC" => 0.1,
                    _ => 0,
                },
                _ => 0,
            };
        }
    }
}
