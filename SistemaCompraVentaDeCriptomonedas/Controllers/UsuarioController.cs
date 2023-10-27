using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.DTOs.Template;
using SistemaCompraVentaDeCriptomonedas.Entities;
using SistemaCompraVentaDeCriptomonedas.Helpers;
using SistemaCompraVentaDeCriptomonedas.Infrastructure;
using SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces;
using SistemaCompraVentaDeCriptomonedas.Services.Interfaces;
using SistemaCompraVentaDeCriptomonedas.Servicios;
using System.Net;

namespace SistemaCompraVentaDeCriptomonedas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUnitOfWork unitOfWork,
                                 IMapper mapper,
                                 IUsuarioService usuarioService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        /// <summary>
		///  Devuelve todos los Usuarios
		/// </summary>
		/// <returns>retorna un statusCode 200 todos los Usuarios</returns>
        [HttpGet]
        [Authorize(Policy = "ADMINISTRADOR")]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();
            int pageToShow = 1;

            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateUsuarios = PaginateHelper.Paginate(usuarios, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateUsuarios);
        }

        /// <summary>
		/// Devuelve el Usuario solicitado 
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Retorna 200 si se obtuvo usuario por id o 500 si no existe usuario con ese id</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetById(id);
            if (usuario == null)
            {
                return ResponseFactory.CreateErrorResponse(404, "No se encontro ningun usuario con ese id ");
            }

            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, usuario);
        }

        /// <summary>
		///  Registra un nuevo Usuario
		/// </summary>
		/// <returns>retorna Usuario registrado con un statusCode 200</returns>
        [HttpPost("crear")]
        public async Task<IActionResult> Create([FromBody] RequestDto<UsuarioRequestDto> request)
        {
            var usuarioDto = request.Data;
            var usuario = _mapper.Map<Usuario>(usuarioDto);

            usuario.Clave = PasswordEncryptHelper.EncryptPassword(usuarioDto.Clave, usuarioDto.Email);

            var result = await _unitOfWork.UsuarioRepository.Create(usuario);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(404, "No se encontro ningun usuario con ese id ");
            }
            await _unitOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(200, usuario);
        }

        /// <summary>
		///  Agrega una cuenta Usuario
		/// </summary>
		/// <returns>retorna un Usuario actualizado o un statusCode 201</returns>

        [HttpPost("agregarCuentaUsuario")]
        public async Task<IActionResult> AddAccountToUser(RequestDto<AgregarCuentaRequestDto> request)
        {

            var result = await _usuarioService.AddAccountToUser(request.Data);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo crear el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(201, "Usuario registrado con exito!");

            }
        }

        /// <summary>
		///  Elimina un Usuario
		/// </summary>
		/// <returns> retorna Usuario eliminado o un 500</returns>
        /// 
        [HttpDelete("{id}")]
        [Authorize(Policy = "ADMINISTRADOR")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.UsuarioRepository.Delete(id);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Eliminado");

            }

        }
    }
}
