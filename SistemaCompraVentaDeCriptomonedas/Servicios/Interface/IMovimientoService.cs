using Microsoft.AspNetCore.Mvc;
using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.DTOs.Template;
using SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces;

namespace SistemaCompraVentaDeCriptomonedas.Servicios.Interface
{
    public interface IMovimientoService : IGenericService<MovimientoDto>
    {
        Task<IActionResult> Transferir(TransferirRequestDto transfer);
        Task<IActionResult> ConsultarUltimosMovimientos();
    }
}