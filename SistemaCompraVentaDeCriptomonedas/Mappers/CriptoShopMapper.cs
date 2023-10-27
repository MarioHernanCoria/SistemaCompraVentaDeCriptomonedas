using AutoMapper;
using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Entities;

namespace SistemaCompraVentaDeCriptomonedas.Mappers
{
    public class CriptoShopMapper : Profile
    {
        public CriptoShopMapper()
        {
            CreateMap<CuentaDto, Cuenta>();
            CreateMap<CuentaFiduciariaDto, CuentaFiduciaria>();
            CreateMap<CuentaCriptoDto, CuentaCripto>();
            CreateMap<Cuenta, CuentaFiduciaria>();
            CreateMap<Cuenta, CuentaCripto>();
            CreateMap<UsuarioRequestDto, Usuario>();
            CreateMap<RolDto, Rol>();

            CreateMap<ExtraerRequestDto, DepositarRequestDto>().
                ForMember(dst => dst.Monto, src => src.MapFrom(x => x.Monto * -1));

            CreateMap<TransferirRequestDto, TransferirDto>();
               
            

        }
    }
}
