using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Entities;

namespace SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces
{
    public interface ICuentaRepository : IGenericRepository<Cuenta>
    {
        Task<bool> Transferir(TransferirDto trans);

        Task<Cuenta> GetById(string id);

        Task<MovimientosResponseDto> ConsultarMovimientos(MovimientosRequestDto mov);
        Task<bool> Depositar(DepositarRequestDto depDto);
        Task<bool> Extraer(ExtraerRequestDto exDto);
        Task<double> GetSaldo(string email);
    }
}
