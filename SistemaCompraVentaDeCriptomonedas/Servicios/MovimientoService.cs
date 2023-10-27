using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Infrastructure;
using SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces;
using SistemaCompraVentaDeCriptomonedas.Servicios.Interface;
using System.Net;

namespace SistemaCompraVentaDeCriptomonedas.Servicios
{
    public class MovimientoService : ResponseFactory/*,  IMovimientoService*/
    {
        //private readonly IMovimientoRepository _movRepository;
        //private readonly IMapper _mapper;

        //public MovimientoService(IMovimientoRepository movRepository,
        //                         IMapper mapper)
        //{
        //    _movRepository = movRepository;
        //    _mapper = mapper;
        //}

        //public Task<IActionResult> ConsultarUltimosMovimientos()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IActionResult> Transferir(TransferirRequestDto transDto)
        //{
        //    try
        //    {
        //        var trans = _mapper.Map<TransferirRequest>(transDto);

        //        var response = await _movRepository.Transferir(trans);

        //        if (response.IsSuccess)
        //        {
        //            var responseDto = _mapper.Map<TransferirResponseDto>(response);
        //            return CreateSuccessResponse(HttpStatusCode.OK, responseDto);
        //        }
        //        else
        //        {
        //            return CreateErrorResponse(HttpStatusCode.BadRequest, response.Message);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return CreateErrorResponse(HttpStatusCode.InternalServerError, $"Internal server error: {ex.Message}");
        //    }
        //}
    }
}
