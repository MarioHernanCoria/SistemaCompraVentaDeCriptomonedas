using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SistemaCompraVentaDeCriptomonedas.Infrastructure
{
    public class ResponseFactory 
    {
        public static IActionResult CreateSuccessResponse(int statusCode, object? data)
        {
            var response = new ApiSuccessResponse()
            {
                Status = statusCode,
                Data = data
            };

            return new ObjectResult(response)
            {
                StatusCode = statusCode,
            };
        }

        public static IActionResult CreateErrorResponse(int statusCode, params string[] errors)
        {
            var response = new ApiErrorResponse()
            {
                Status = statusCode,
                Error = new List<ApiErrorResponse.ResponseError>()
            };

            foreach (var error in errors)
            {
                response.Error.Add(new ApiErrorResponse.ResponseError() { Error = error });
            }

           return new ObjectResult(response)
           {
                StatusCode = statusCode,
           };
        }
    }
}
