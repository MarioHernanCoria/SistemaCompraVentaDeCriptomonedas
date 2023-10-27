using SistemaCompraVentaDeCriptomonedas.Repositories;

namespace SistemaCompraVentaDeCriptomonedas.Services.Interfaces
{
    public interface IUnitOfWork
    {
        public CuentaRepository CuentaRepository { get; }
        public UsuarioRepository UsuarioRepository { get; }
        public RolRepository RolRepository { get; }
        Task<int> Complete();
    }
}