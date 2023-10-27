namespace SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<bool> Update(T entity);
        public Task<bool> Delete(int id);
        public Task<bool> Create(T entity);

    }
}
