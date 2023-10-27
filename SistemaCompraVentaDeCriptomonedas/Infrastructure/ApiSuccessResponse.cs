using System.Net;

namespace SistemaCompraVentaDeCriptomonedas.Infrastructure
{
    public class ApiSuccessResponse
    {
        public int Status { get; set; }
        public object? Data { get; set; }
    }
}
