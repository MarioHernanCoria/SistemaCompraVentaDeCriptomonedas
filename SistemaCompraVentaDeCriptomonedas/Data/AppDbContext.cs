using Microsoft.EntityFrameworkCore;
using SistemaCompraVentaDeCriptomonedas.DataAccess.DatabaseSeeding;
using SistemaCompraVentaDeCriptomonedas.Entities;

namespace SistemaCompraVentaDeCriptomonedas.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<CuentaCripto> CuentasCriptos { get; set; }
        public DbSet<CuentaFiduciaria> CuentasFiduciarias { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<MovimientoCuenta> MovimientoCuentas { get; set; }
        public DbSet<MovimientoUsuario> MovimientoUsuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<LogMovimiento> LogMovimientos { get; set; }
        public DbSet<LogTransferencia> LogTransferencias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<MovimientoCuenta>()
                        .HasOne(ur => ur.CuentaOrigen)
                        .WithMany()
                        .HasForeignKey(ur => ur.CuentaOrigenId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MovimientoCuenta>()
                       .HasOne(ur => ur.CuentaDestino)
                       .WithMany()
                       .HasForeignKey(ur => ur.CuentaDestinoId)
                       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MovimientoUsuario>()
                      .HasOne(ur => ur.UsuarioOrigen)
                      .WithMany()
                      .HasForeignKey(ur => ur.UsuarioOrigenId)
                      .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MovimientoUsuario>()
                      .HasOne(ur => ur.UsuarioDestino)
                      .WithMany()
                      .HasForeignKey(ur => ur.UsuarioDestinoId)
                      .OnDelete(DeleteBehavior.Restrict);


            var seeders = new List<IEntitySeeder>
            {
                new UsuarioSeeder(),
                
            };
            foreach (var seeder in seeders)
            {
                seeder.SeedDataBase(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
