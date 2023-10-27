using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Helpers;
using SistemaCompraVentaDeCriptomonedas.Infrastructure;
using SistemaCompraVentaDeCriptomonedas.Services.Interfaces;

namespace SistemaCompraVentaDeCriptomonedas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {

        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }

        /// <summary>
		///  Se loguea el usuario
		/// </summary>
		/// <returns>el token del usuario</returns>
        /// 
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AuthenticateDto dto)
        {
            var usuarioCredentials = await _unitOfWork.UsuarioRepository.AuthenticateCredentials(dto);
            if (usuarioCredentials is null) return Unauthorized("Las credenciales son incorrectas");

            var token = _tokenJwtHelper.GenerateToken(usuarioCredentials);

            var usuario = new UsuarioLoginDto()
            {
                Nombre = usuarioCredentials.Nombre,
                Email = usuarioCredentials.Email,
                Token = token

            };

            return Ok(usuario);

        }

    }
}
