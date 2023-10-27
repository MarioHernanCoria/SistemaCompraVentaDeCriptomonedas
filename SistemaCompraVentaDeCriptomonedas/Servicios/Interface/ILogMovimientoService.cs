using Microsoft.EntityFrameworkCore;
using SistemaCompraVentaDeCriptomonedas.DataAccess;
using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Entities;
using SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces;

namespace SistemaCompraVentaDeCriptomonedas.Repositories
{
    public interface ILogMovimientoService : IGenericRepository<LogMovimiento>
    {
        Task<List<LogMovimiento>> GetByEmail(string emailUsuario);
        Task<bool> LogDeposito(DepositarRequestDto depDto);
        Task<bool> LogTransferencia(Movimiento mov);
    }
}