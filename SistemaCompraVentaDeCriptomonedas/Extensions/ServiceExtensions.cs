using FluentValidation;
using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Entities;
using SistemaCompraVentaDeCriptomonedas.Repositories;
using SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces;
using SistemaCompraVentaDeCriptomonedas.Services.Implementacion;
using SistemaCompraVentaDeCriptomonedas.Services.Interfaces;
using SistemaCompraVentaDeCriptomonedas.Servicios;
using SistemaCompraVentaDeCriptomonedas.Servicios.Interface;
using SistemaCompraVentaDeCriptomonedas.Validator;

namespace SistemaCompraVentaDeCriptomonedas.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddService(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, UnitOfWorkService>();
            services.AddScoped<ICuentaService, CuentaService>();
            services.AddScoped<IRolesServices, RolesServices>();
            services.AddScoped<IUsuarioService, UsuarioServices>();
            services.AddScoped<ILogMovimientoService, LogMovimientoService>();

            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILogMovimientoRepository, LogMovimientoRepository>();
            services.AddScoped<ICurrencyChangeService, CurrencyChangeService>();

            services.AddScoped<IValidator<TransferirRequestDto>, TransferirRequestDtoValidator>();

        }

    }
}
