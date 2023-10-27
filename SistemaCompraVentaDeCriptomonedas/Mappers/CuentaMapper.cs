using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Entities;

namespace SistemaCompraVentaDeCriptomonedas.Mappers
{
    public static class CuentaMapper
    {
        public static Cuenta Map(CuentaDto cuentaDto)
        {
            var destination = new Cuenta();

            if (cuentaDto.CuentaCripto != null)
            {

                destination = new CuentaCripto
                {
                    Saldo = cuentaDto.CuentaCripto.Saldo,
                    NombreCripto = cuentaDto.CuentaCripto.NombreCripto,
                    UUID = cuentaDto.CuentaCripto.UUID,
                    Discriminator = "CuentaCripto"
                };
            }
            else
            {
                destination = new CuentaFiduciaria
                {
                    Saldo = cuentaDto.CuentaFiduciaria.Saldo,
                    CBU = cuentaDto.CuentaFiduciaria.CBU,
                    Alias = cuentaDto.CuentaFiduciaria.Alias,
                    NumeroCuenta = cuentaDto.CuentaFiduciaria.NumeroCuenta,
                    Tipo = cuentaDto.CuentaFiduciaria.Tipo,
                    Discriminator = "CuentaFiduciaria"
                };
            }

            return destination;
        }
    }
}
