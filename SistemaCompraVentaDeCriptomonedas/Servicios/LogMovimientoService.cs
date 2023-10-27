using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Entities;
using SistemaCompraVentaDeCriptomonedas.Enums;
using SistemaCompraVentaDeCriptomonedas.Helpers;
using SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces;

namespace SistemaCompraVentaDeCriptomonedas.Repositories
{
    public class LogMovimientoService : ILogMovimientoService
    {
        private readonly ILogMovimientoRepository _movRepository;

        public LogMovimientoService(ILogMovimientoRepository movRepository) 
        {
            _movRepository = movRepository;
        }

        public async Task<bool> Create(LogMovimiento entity)
        {
            return await _movRepository.Create(entity);
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LogMovimiento>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<LogMovimiento>> GetByEmail(string emailUsuario)
        {
            return await _movRepository.GetByEmail(emailUsuario);
        }

        public Task<LogMovimiento> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LogDeposito(DepositarRequestDto depDto)
        {
            var log = new LogMovimiento()
            {
                Monto = depDto.Monto,
                EmailUsuario = depDto.EmailUsuario,
                TipoMovimiento = TipoMovimientoEnum.DEPOSITO,
                Fecha = DateTime.Now,
                NumeroCuenta = depDto.NumeroCuenta
            };

            return await _movRepository.Create(log);
        }

        public Task<bool> LogTransferencia(Movimiento mov)
        {
            var log = new LogTransferencia()
            {
                Monto = mov.Monto,
                EmailUsuario = mov.MovimientoUsuario.UsuarioOrigen.Email,
                EmailDestino = mov.MovimientoUsuario.UsuarioDestino.Email,
                NumeroCuenta = mov.MovimientaCuenta.CuentaOrigen.Discriminator == Constantes.CUENTACRIPTO ? 
                               ((CuentaCripto)mov.MovimientaCuenta.CuentaOrigen).UUID :
                               ((CuentaFiduciaria)mov.MovimientaCuenta.CuentaOrigen).NumeroCuenta,
                NumeroCuentaDestino = mov.MovimientaCuenta.CuentaDestino.Discriminator == Constantes.CUENTACRIPTO ?
                                      ((CuentaCripto)mov.MovimientaCuenta.CuentaDestino).UUID :
                                      ((CuentaFiduciaria)mov.MovimientaCuenta.CuentaDestino).NumeroCuenta,
                TipoMovimiento = TipoMovimientoEnum.DEPOSITO,
                Fecha = DateTime.Now
            };

            return _movRepository.Create(log);
        }

        public Task<bool> Update(LogMovimiento entity)
        {
            throw new NotImplementedException();
        }
    }
}