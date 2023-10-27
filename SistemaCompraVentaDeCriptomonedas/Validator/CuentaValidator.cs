using FluentValidation;
using FluentValidation.Validators;
using SistemaCompraVentaDeCriptomonedas.DTOs;

namespace SistemaCompraVentaDeCriptomonedas.Validator
{
    internal class CuentaValidator : IPropertyValidator<TransferirRequestDto, CuentaDto>
    {
        public string Name => "CuentaValidator";

        public string GetDefaultMessageTemplate(string errorCode)
        {
            return $"Error al validar Cuenta: {errorCode}";
        }

        public bool IsValid(ValidationContext<TransferirRequestDto> context, CuentaDto value)
        {
            bool response = false;

            if (value.CuentaFiduciaria != null && value.CuentaCripto != null)
                return false;

            if (value.CuentaFiduciaria == null && value.CuentaCripto == null)
                return false;

            if (value.CuentaCripto != null)
            {
                response = ValidateCuentaCripto(value.CuentaCripto);
            }

            if (value.CuentaFiduciaria != null)
            {
                response = ValidateCuentaFiduciaria(value.CuentaFiduciaria);
            }

            return response;
        }

        private bool ValidateCuentaFiduciaria(CuentaFiduciariaDto cuentaFiduciaria)
        {
            return true;
        }

        private bool ValidateCuentaCripto(CuentaCriptoDto cuentaCripto)
        {
            return true;
        }
    }
}