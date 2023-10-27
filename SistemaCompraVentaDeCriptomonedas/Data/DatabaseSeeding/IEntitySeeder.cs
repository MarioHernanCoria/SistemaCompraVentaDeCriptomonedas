using Microsoft.EntityFrameworkCore;

namespace SistemaCompraVentaDeCriptomonedas.DataAccess.DatabaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDataBase(ModelBuilder modelBuilder);
    }
}
