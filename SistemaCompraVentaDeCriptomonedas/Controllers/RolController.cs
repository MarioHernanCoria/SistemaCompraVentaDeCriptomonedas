using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Entities;
using SistemaCompraVentaDeCriptomonedas.Infrastructure;
using SistemaCompraVentaDeCriptomonedas.Services.Interfaces;
using System.Net;

namespace SistemaCompraVentaDeCriptomonedas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RolController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
		///  Devuelve todos los Roles
		/// </summary>
		/// <returns>retorna un statusCode 200 todos los Roles</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Roles = await _unitOfWork.RolRepository.GetAll();

            return ResponseFactory.CreateSuccessResponse(200, Roles);
        }


        /// <summary>
		///  Devuelve un Rol
		/// </summary>
		/// <returns>retorna un statusCode 200 un Rol</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Rol = await _unitOfWork.RolRepository.GetById(id);
            if (Rol == null)
            {
                return ResponseFactory.CreateSuccessResponse(404, "Perfil no encontrado!");
            }
            return ResponseFactory.CreateSuccessResponse(200, Rol);
        }


        /// <summary>
		///  Elimina un Rol
		/// </summary>
		/// <returns> retorna Rol eliminado o un 500</returns>
        [HttpDelete("{id}")]
        [Authorize(Policy = "ADMINISTRADOR")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.RolRepository.Delete(id);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el perfil");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
            }
        }
    }
}
