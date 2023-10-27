using FluentValidation;
using SistemaCompraVentaDeCriptomonedas.DTOs;

namespace SistemaCompraVentaDeCriptomonedas.Validator
{
    public class TransferirRequestDtoValidator : AbstractValidator<TransferirRequestDto>
    {
        public TransferirRequestDtoValidator()
        {
            RuleFor(x => x.EmailOrigen).NotEmpty().WithMessage("El email del origen no puede estar vacio");
            RuleFor(x => x.EmailDestino).NotEmpty().WithMessage("El email del destino no puede estar vacio");
            //RuleFor(RuleFor(x => x.CuentaOrigen).SetValidator(new CuentaValidator()));
            //RuleFor(RuleFor(x => x.CuentaOrigen).SetValidator(new CuentaValidator()));
            RuleFor(x => x.Monto).NotEmpty().WithMessage("El monto no puede estar vacio");
            RuleFor(x => x.TipoCuenta).NotEmpty().WithMessage("El tipo de cuenta no puede estar vacio");

        }
    }
}
