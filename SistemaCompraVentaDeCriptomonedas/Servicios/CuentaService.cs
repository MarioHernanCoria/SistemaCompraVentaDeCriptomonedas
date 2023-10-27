using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Entities;
using SistemaCompraVentaDeCriptomonedas.Enums;
using SistemaCompraVentaDeCriptomonedas.Mappers;
using SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces;
using SistemaCompraVentaDeCriptomonedas.Servicios.Interface;

namespace SistemaCompraVentaDeCriptomonedas.Servicios
{
    public class CuentaService : ICuentaService
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public CuentaService(ICuentaRepository cuentaRepository,
                             IUsuarioService usuarioService,
                             IMapper mapper)
        {
            _cuentaRepository = cuentaRepository;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        public async Task<bool> Create(Cuenta entity)
        {
            return await _cuentaRepository.Create(entity);
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Transferir(TransferirRequestDto transDto)
        {
         
            var trans = TransferenciaMapper.Map(transDto);

            var usuarioOrigen = await _usuarioService.GetByEmail(trans.EmailOrigen);
            if (usuarioOrigen == null)
                return false;

            var usuarioDestino = await _usuarioService.GetByEmail(trans.EmailDestino);
            if (usuarioDestino == null)
                return false;


            trans.UsuarioOrigen = usuarioOrigen;
            trans.UsuarioDestino = usuarioDestino;

            //opciones
            //1- Validar que la cuenta sea del usuario.
            //2- Validar que la cuenta exista.
            //3- Validar que el usuario exista.
            //4- Validar que el usuario sea dueño de la cuenta.
            //5- Validar que el usuario tenga saldo suficiente.
            //6- Validar que el usuario destino exista.
            //7- Validar que la cuenta destino exista.
            //8- Validar que el usuario destino sea dueño de la cuenta destino.
            
            //Tipo de transfenrencias

            //1- Transferencia entre cuentas fiduciarias.
            //2- Transferencia entre cuentas cripto.

            //FALTAN
            //3- Transferencia entre cuentas fiduciarias y cripto.
            //4- Transferencia entre cuentas cripto y fiduciarias.

            
            if (trans.TipoCuenta == DiscriminadorCuentaEnum.CRIPTOMONEDA)
            {
                var cuentaTransOrigen = trans.CuentaOrigen as CuentaCripto;
                var cuentaTransDestino = trans.CuentaDestino as CuentaCripto;
              
                var cuentaOrigen = await _cuentaRepository.GetById(cuentaTransOrigen.UUID);
                if (cuentaOrigen == null)
                {
                    return false;
                }
              
                var cuentaDestino = await _cuentaRepository.GetById(cuentaTransDestino.UUID);
                if (cuentaDestino == null)
                {
                    return false;
                }

                trans.CuentaOrigen.Saldo = cuentaOrigen.Saldo - trans.Monto;
                trans.CuentaOrigen.Id = cuentaOrigen.Id;

                trans.CuentaDestino.Saldo = cuentaDestino.Saldo + trans.Monto;
                trans.CuentaDestino.Id = cuentaDestino.Id;
                
            }
            else
            {
                var cuentaTransOrigen = trans.CuentaOrigen as CuentaFiduciaria;
                var cuentaTransDestino = trans.CuentaDestino as CuentaFiduciaria;

                var cuentaOrigen = await _cuentaRepository.GetById(cuentaTransOrigen.NumeroCuenta);
                if (cuentaOrigen == null)
                {
                    return false;
                }
                var cuentaDestino = await _cuentaRepository.GetById(cuentaTransDestino.NumeroCuenta);
                if (cuentaDestino == null)
                {
                    return false;
                }

              
                trans.CuentaOrigen.Saldo = cuentaOrigen.Saldo - trans.Monto;
                trans.CuentaOrigen.Id = cuentaOrigen.Id;

                trans.CuentaDestino.Saldo = cuentaDestino.Saldo + trans.Monto;
                trans.CuentaDestino.Id = cuentaDestino.Id;
            }


            return await _cuentaRepository.Transferir(trans);
        }

        public async Task<bool> Update(CuentaDto cuentaDto)
        {
            //Valido que exista la cuenta.
            //if(cuentaDto.CuentaCripto != null)
            //     await _unitOfWork.CuentaRepository.GetById(cuentaDto.CuentaCripto.UUID);


            var cuenta = _mapper.Map<Cuenta>(cuentaDto);

            if(!await _cuentaRepository.Update(cuenta))
                return false; 
           
            return true;
        }
        Task<List<Cuenta>> IGenericService<Cuenta>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Cuenta> IGenericService<Cuenta>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Cuenta entity)
        {
            throw new NotImplementedException();
        }

        public Task<Cuenta> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Depositar(DepositarRequestDto depDto)
        {
            //Verifico que exita la cuenta, el usuario, y que el usuario sea dueño de la cuenta.
            //var cuenta = _unitOfWork.CuentaRepository.GetById(depDto.NumeroCuenta);
            //if (cuenta == null)
            //    return await Task.FromResult(false);

            var usuario = await _usuarioService.GetByEmail(depDto.EmailUsuario);
            if (usuario == null)
                return await Task.FromResult(false);

            //Validar que la cuenta sea del usuario.
            var cuenta = await _cuentaRepository.GetById(depDto.NumeroCuenta);
            if (cuenta == null)
                return await Task.FromResult(false);

            
            if(!await _cuentaRepository.Depositar(depDto))
                return await Task.FromResult(false);

            return await Task.FromResult(true);
        }

        public async Task<MovimientosResponseDto> ConsultarMovimientos(MovimientosRequestDto data)
        {
            //Verifico que exita la cuenta, el usuario, y que el usuario sea dueño de la cuenta.
            //var cuenta = _unitOfWork.CuentaRepository.GetById(depDto.NumeroCuenta);
            //if (cuenta == null)
            //    return await Task.FromResult(false);

            var usuario = await _usuarioService.GetByEmail(data.EmailUsuario);
            if (usuario == null)
                return null;

            //Validar que la cuenta sea del usuario.

            var response = await _cuentaRepository.ConsultarMovimientos(data);

            if ( response == null)
                return null;


            return response;
        }

        public Task<bool> Extraer(ExtraerRequestDto exDto)
        {
            var depDto = _mapper.Map<DepositarRequestDto>(exDto);
            return Depositar(depDto);
        }

        public Task<bool> Transferir(TransferirDto data)
        {
           return _cuentaRepository.Transferir(data);
        }

        public async Task<double> GetSaldo(SaldoRequestDto data)
        {
            //Verificar que exista el usuario
            if(await _usuarioService.GetByEmail(data.Email) == null)
                throw new Exception("El usuario no existe");
           
            return await _cuentaRepository.GetSaldo(data.Email);
        }

        public async Task<List<Cuenta>> GetAll()
        {
            return await _cuentaRepository.GetAll();
        }
    }
}
