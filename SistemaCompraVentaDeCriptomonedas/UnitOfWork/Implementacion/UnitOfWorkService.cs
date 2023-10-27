using SistemaCompraVentaDeCriptomonedas.DataAccess;
using SistemaCompraVentaDeCriptomonedas.Repositories;
using SistemaCompraVentaDeCriptomonedas.Services.Interfaces;

namespace SistemaCompraVentaDeCriptomonedas.Services.Implementacion
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public CuentaRepository CuentaRepository { get; }
        public UsuarioRepository UsuarioRepository { get; }
        public RolRepository RolRepository { get; }

        public UnitOfWorkService(AppDbContext context)
        {
            _context = context;
            //CuentaRepository = new CuentaRepository(_context);
            UsuarioRepository = new UsuarioRepository(_context);
            RolRepository = new RolRepository(_context);
        }

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }
    }
}
