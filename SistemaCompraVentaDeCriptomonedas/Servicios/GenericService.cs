using Microsoft.EntityFrameworkCore;
using SistemaCompraVentaDeCriptomonedas.DataAccess;
using SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces;

namespace SistemaCompraVentaDeCriptomonedas.Repositories
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly AppDbContext _context;

        public GenericService(AppDbContext context)
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
