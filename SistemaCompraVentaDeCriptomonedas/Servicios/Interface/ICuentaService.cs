using Microsoft.AspNetCore.Mvc;
using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Entities;
using SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces;

namespace SistemaCompraVentaDeCriptomonedas.Servicios.Interface
{
    public interface ICuentaService : IGenericService<Cuenta>
    {
        Task<bool> Depositar(DepositarRequestDto depDto);
        Task<bool> Extraer(ExtraerRequestDto depDto);
        Task<List<Cuenta>> GetAll();
        Task<bool> Transferir(TransferirRequestDto data);
        Task<Cuenta> GetById(string id);
        Task<MovimientosResponseDto> ConsultarMovimientos(MovimientosRequestDto data);
        Task<double> GetSaldo(SaldoRequestDto data);
        
    }
}
