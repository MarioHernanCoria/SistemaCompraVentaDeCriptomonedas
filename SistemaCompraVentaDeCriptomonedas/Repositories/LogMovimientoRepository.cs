using Microsoft.EntityFrameworkCore;
using SistemaCompraVentaDeCriptomonedas.DataAccess;
using SistemaCompraVentaDeCriptomonedas.Entities;
using SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces;

namespace SistemaCompraVentaDeCriptomonedas.Repositories
{
    public class LogMovimientoRepository : ILogMovimientoRepository
    {
        private readonly AppDbContext _context;

        public LogMovimientoRepository(AppDbContext context) 
        {
            this._context = context;
        }

        public async Task<bool> Create(LogMovimiento entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LogMovimiento>> GetAll()
        {
            return await _context.LogMovimientos.ToListAsync();
        }

        public async Task<List<LogMovimiento>> GetByEmail(string emailUsuario)
        {
            var logs = await _context.LogMovimientos.Where(x => x.EmailUsuario == emailUsuario).ToListAsync();

            return logs;
        }

        public Task<LogMovimiento> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(LogMovimiento entity)
        {
            throw new NotImplementedException();
        }
    }
}