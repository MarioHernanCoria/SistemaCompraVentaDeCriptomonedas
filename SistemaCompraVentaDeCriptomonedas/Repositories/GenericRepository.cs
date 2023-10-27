using Microsoft.EntityFrameworkCore;
using MiNET.Entities;
using SistemaCompraVentaDeCriptomonedas.DataAccess;
using SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces;

namespace SistemaCompraVentaDeCriptomonedas.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);

        }

        public virtual async Task<bool> Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Update(T Entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
