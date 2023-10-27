using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.DTOs.Template;
using SistemaCompraVentaDeCriptomonedas.Entities;
using SistemaCompraVentaDeCriptomonedas.Helpers;
using SistemaCompraVentaDeCriptomonedas.Infrastructure;
using SistemaCompraVentaDeCriptomonedas.Servicios;
using SistemaCompraVentaDeCriptomonedas.Servicios.Interface;

namespace SistemaCompraVentaDeCriptomonedas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;
        private readonly ICurrencyChangeService _currencyChangeService;
        private readonly IMapper _mapper;

        public CuentaController(ICuentaService cuentaService,
                                ICurrencyChangeService currencyChangeService,
                                IMapper mapper)
        {
            _cuentaService = cuentaService;
            _currencyChangeService = currencyChangeService;
            _mapper = mapper;
        }

        /// <summary>
		///  Devuelve todos las cuentas
		/// </summary>
		/// <returns>retorna un statusCode 200 todos los Usuarios</returns>
        [Authorize(Policy = "ADMINISTRADOR")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var cuentas = await _cuentaService.GetAll();
            int pageToShow = 1;

            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateCuentas = PaginateHelper.Paginate(cuentas, pageToShow, url);

            return Ok(paginateCuentas);
        }

        /// <summary>
		/// Devuelve transferencia Exitosa
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Retorna 200 si se pudo hacer la transferencia o 500 si no se pudo realizar la transferencia</returns>

        [HttpPost("transferir")]
        public async Task<IActionResult> Transferir([FromBody] RequestDto<TransferirRequestDto> transDto)
        {
            var result = await _cuentaService.Transferir(transDto.Data);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo hacer la transferencia");
            }
            else
            {
                return ResponseFactory.CreateSuccessResponse(201, "Transferencia Exitosa");
            }
        }

        /// <summary>
		///  Convierte una moneda a otra(Por ejemplo de Peso a Dolares)
		/// </summary>
		/// <returns>retorna un statusCode 200 todos los Usuarios</returns>
        [HttpPost("convertir")]
        public async Task<IActionResult> Convertir([FromBody] RequestDto<ConvertirRequestDto> convDto)
        {
            var result = _currencyChangeService.GetCurrencyChange(convDto.Data);

            if (result == 0)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo obtener la tasa de conversión");
            }
            else
            {
                return ResponseFactory.CreateSuccessResponse(200,result);
            }
        }

        /// <summary>
        /// Devuelve La consulta del saldo de la cuenta del cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se pudo hacer la consulta o 500 si no se pudo realizar la consulta</returns>

        [HttpPost("ConsultaSaldo")]
        public async Task<IActionResult> GetSaldo([FromBody] RequestDto<SaldoRequestDto> saldo)
        {
            try
            {
                var result = await _cuentaService.GetSaldo(saldo.Data);

                return ResponseFactory.CreateSuccessResponse(200, result);

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, ex.Message);
            }
        }

        /// <summary>
		/// Devuelve deposito realizado
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Retorna 200 si se pudo hacer el deposito o 500 si no se pudo realizar el deposito</returns>
        [HttpPost("depositar")]
        public async Task<IActionResult> Depositar([FromBody] RequestDto<DepositarRequestDto> depDto)
        {
            var result = await _cuentaService.Depositar(depDto.Data);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo hacer el deposito");
            }
            else
            {
                return ResponseFactory.CreateSuccessResponse(201, "Deposito Exitoso");
            }
        }

        /// <summary>
		/// Devuelve que la extraccion del dinero de la cuenta del cliente
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Retorna 200 si se pudo hacer la extraccion o 500 si no se pudo realizar la extraccion</returns>
        [HttpPost("extraer")]
        public async Task<IActionResult> Extraer([FromBody] RequestDto<ExtraerRequestDto> exDto)
        {
            if (exDto is null)
            {
                ResponseFactory.CreateErrorResponse(500, "El request no puede ser nulo.");
            }

            var result = await _cuentaService.Extraer(exDto.Data);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo hacer la extracción");
            }
            else
            {
                return ResponseFactory.CreateSuccessResponse(201, "Extracción realizada");
            }
        }

        /// <summary>
		/// Devuelve los movimientos de la cuenta del cliente
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Retorna 200 si se pudo hacer la consulta de los movimientos o 500 si no se pudo realizar la consulta</returns>
        [HttpPost("movimientos")]
        public async Task<IActionResult> Movimientos([FromBody] RequestDto<MovimientosRequestDto> movDto)
        {
         
            var result = await _cuentaService.ConsultarMovimientos(movDto.Data);

            if (result == null)
            {
                return ResponseFactory.CreateErrorResponse(500, $"No se pudo mostrar movimiento del usaurio {movDto.Data.EmailUsuario}");
            }
            else
            {
                return ResponseFactory.CreateSuccessResponse(200, result);
            }
        }

        /// <summary>
		/// Devuelve la creacion de la cuenta del cliente
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Retorna 200 si se pudo crear la cuenta o 500 si no se pudo realizar la creacion de la cuenta</returns>
        [HttpPost("crear")]
        public async Task<IActionResult> Create([FromBody] CuentaDto cuentaDto)
        {
            bool result = false;

            if (cuentaDto.CuentaCripto == null && cuentaDto.CuentaFiduciaria == null)
                return ResponseFactory.CreateErrorResponse(400, "No se puede crear una cuenta sin tipo de cuenta");

            if (cuentaDto.CuentaCripto != null && cuentaDto.CuentaFiduciaria != null)
                return ResponseFactory.CreateErrorResponse(400, "Solo es permitito un tipo de cuenta");

            if (cuentaDto.CuentaCripto != null) 
            {
                var cuenta = _mapper.Map<CuentaCripto>(cuentaDto.CuentaCripto);
                result = await _cuentaService.Create(cuenta);
            }
            else
            {
                var cuenta = _mapper.Map<CuentaFiduciaria>(cuentaDto.CuentaFiduciaria);
                result = await _cuentaService.Create(cuenta);
            }

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo crear la cuenta");
            }
            else
            {
                return ResponseFactory.CreateSuccessResponse(200, "Creado");

            }
        }

        /// <summary>
        ///  Actualiza una cuenta
        /// </summary>
        /// <returns>retorna una cuenta actualizada o un statusCode 201</returns>
        [HttpPut("{id}")]
        //[Authorize(Policy = "ADMINISTRADOR")]
        public async Task<IActionResult> Update([FromRoute] int id, CuentaDto cuentaDto)
        {
            var cuenta = _mapper.Map<Cuenta>(cuentaDto);

            var result = await _cuentaService.Update(cuenta);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar la cuenta");
            }
            else
            {
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");

            }
        }

        /// <summary>
        ///  Elimina una cuenta
        /// </summary>
        /// <returns>retorna una cuenta eliminada o un statusCode 201</returns>
        [HttpDelete("{id}")]
        [Authorize(Policy = "ADMINISTRADOR")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _cuentaService.Delete(id);

            if (!result)
            {
                return Ok("No se pudo eliminar la cuenta");
            }
            else
            {
                return Ok("Eliminado");

            }

        }
    }
}
