using SistemaCompraVentaDeCriptomonedas.Entities;
using SistemaCompraVentaDeCriptomonedas.Servicios;

namespace SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces
{
    public interface ILogMovimientoRepository : IGenericRepository<LogMovimiento>
    {
       Task<List<LogMovimiento>> GetByEmail(string emailUsuario);
    }
}
