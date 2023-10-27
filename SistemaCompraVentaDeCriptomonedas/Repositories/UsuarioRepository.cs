using Microsoft.EntityFrameworkCore;
using MiNET.Blocks;
using SistemaCompraVentaDeCriptomonedas.DataAccess;
using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Entities;
using SistemaCompraVentaDeCriptomonedas.Helpers;
using SistemaCompraVentaDeCriptomonedas.Repositories.Interfaces;

namespace SistemaCompraVentaDeCriptomonedas.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<bool> Update(Usuario updateUsuario)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == updateUsuario.Id);
            if (usuario == null) { return false; }

            usuario.Nombre = updateUsuario.Nombre;
            usuario.Email = updateUsuario.Email;
            usuario.Clave = updateUsuario.Clave;
            usuario.Activo = updateUsuario.Activo;

            _context.Usuarios.Update(usuario);
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var usuario = await _context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            return true;
        }

        public async Task<Usuario?> AuthenticateCredentials(AuthenticateDto dto)
        {
            var encryptedPassword = PasswordEncryptHelper.EncryptPassword(dto.Clave, dto.Email);
            var usuario = await _context.Usuarios
                .SingleOrDefaultAsync(x => x.Email == dto.Email && x.Clave == encryptedPassword);

            return usuario;
        }

        public async Task<Usuario> GetByEmail(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
     
        }
        public async Task<bool> Create(Usuario usuario)
        {
            try
            {
                await _context.AddAsync(usuario);
                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                //TODO: Loguear
                return false;
            }

        }

        public async Task<bool> AddAccountToUser(Usuario usuario, Cuenta cuenta)
        {
        
            usuario.Cuentas.Add(cuenta);
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UsuarioEx(object email)
        {
            return await _context.Usuarios.AnyAsync(x => x.Email == email);
        }
    }
}
