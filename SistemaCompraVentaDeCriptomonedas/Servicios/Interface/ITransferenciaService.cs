using Microsoft.AspNetCore.Mvc;
using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces;

namespace SistemaCompraVentaDeCriptomonedas.Servicios.Interface
{
    public interface ITransferenciaService : IGenericService<TransferirRequestDto>
    {
      
    }
}
