using SistemaCompraVentaDeCriptomonedas.DTOs.Template;
using SistemaCompraVentaDeCriptomonedas.Entities;

namespace SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> GetByEmail(string email);

        Task<bool> Create(Usuario request);

        Task<bool> AddAccountToUser(Usuario usuario, Cuenta cuenta);
    }
}
