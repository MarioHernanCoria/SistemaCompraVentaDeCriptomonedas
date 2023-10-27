using AutoMapper;
using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Entities;
using SistemaCompraVentaDeCriptomonedas.Infrastructure;
using SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces;

namespace SistemaCompraVentaDeCriptomonedas.Servicios
{
    public class UsuarioServices : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IMapper _mapper;

        public UsuarioServices(IUsuarioRepository usuarioRepository,
                               ICuentaRepository cuentaRepository,
                               IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _cuentaRepository = cuentaRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddAccountToUser(AgregarCuentaRequestDto request)
        {
            var usuario = await _usuarioRepository.GetByEmail(request.Email);

        
            if (request.Cuenta.CuentaCripto == null && request.Cuenta.CuentaFiduciaria == null)
                return false;

            if (request.Cuenta.CuentaCripto != null && request.Cuenta.CuentaFiduciaria != null)
                return false;


            if (request.Cuenta.CuentaCripto != null)
            {
                var cuentaCripto = _mapper.Map<CuentaCripto>(request.Cuenta.CuentaCripto);
                //var cuenta = await _cuentaRepository.GetById(request.Cuenta.CuentaCripto.UUID);
                //if (cuenta != null)
                //{
                //    return false;
                //}

                return await _usuarioRepository.AddAccountToUser(usuario, cuentaCripto);
            }
            else
            {
                var cuentaFidu = _mapper.Map<CuentaFiduciaria>(request.Cuenta.CuentaFiduciaria);
                //var cuenta = await _cuentaRepository.GetById(request.Cuenta.CuentaFiduciaria.NumeroCuenta);
                //if (cuenta != null)
                //{
                //    return false;
                //}
                return await _usuarioRepository.AddAccountToUser(usuario, cuentaFidu);
            }
        }

        public Task<bool> AddAccountToUser(object data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetByEmail(string emailUsuario)
        {
            return await _usuarioRepository.GetByEmail(emailUsuario);
        }

        public Task<Usuario> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UsuarioEx(string Email)
        {
            throw new NotImplementedException();
        }
    }
}
