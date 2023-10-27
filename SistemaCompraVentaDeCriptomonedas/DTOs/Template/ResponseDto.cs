using SistemaCompraVentaDeCriptomonedas.Infrastructure;

namespace SistemaCompraVentaDeCriptomonedas.DTOs.Template
{
    public class ResponseDto<TResponse> 
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public TResponse Data { get; set; }

    }
}
