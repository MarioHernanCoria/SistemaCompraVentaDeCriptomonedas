using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Entities;
using SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces;

namespace SistemaCompraVentaDeCriptomonedas.Servicios
{
    public interface IUsuarioService : IGenericService<Usuario>
    {
        Task<bool> AddAccountToUser(AgregarCuentaRequestDto request);
        Task<bool> AddAccountToUser(object data);
        Task<Usuario> GetByEmail(string emailUsuario);
        Task<bool> UsuarioEx(string Email);
    }
}
