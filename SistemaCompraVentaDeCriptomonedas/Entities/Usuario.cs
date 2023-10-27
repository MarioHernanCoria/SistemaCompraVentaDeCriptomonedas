using SistemaCompraVentaDeCriptomonedas.DTOs;
using SistemaCompraVentaDeCriptomonedas.Enums;
using SistemaCompraVentaDeCriptomonedas.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCompraVentaDeCriptomonedas.Entities
{
    public class Usuario
    {
        public Usuario(UsuarioRequestDto dto)
        {
            Nombre = dto.Nombre;
            Apellido = dto.Apellido;
            Dni = dto.Dni;
            Email = dto.Email;
            Clave = PasswordEncryptHelper.EncryptPassword(dto.Clave, dto.Email);
            Roles = dto.Roles;
            FechaNacimiento = dto.FechaNacimiento;
            Genero = dto.Genero;
            EstadoCivil = dto.EstadoCivil;
        }
        public Usuario(UsuarioRequestDto dto, int id)
        {
            Id = id;
            Nombre = dto.Nombre;
            Apellido = dto.Apellido;
            Dni = dto.Dni;
            Email = dto.Email;
            Clave = PasswordEncryptHelper.EncryptPassword(dto.Clave, dto.Email);
            Roles = dto.Roles;
            FechaNacimiento = dto.FechaNacimiento;
            Genero = dto.Genero;
            EstadoCivil = dto.EstadoCivil;
        }
        public Usuario()
        {
            
        }


        public int Id { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int Dni { get; set; }

        public string Email { get; set; }

        public string Clave { get; set; }

        public GeneroEnum Genero { get; set; }

        public EstadoCivilEnum EstadoCivil { get; set; }

        public List<Rol>? Roles { get; set; }

        public List<Cuenta>? Cuentas { get; set; } = new List<Cuenta>();

        [Required]
        public bool Activo { get; set; } = true;
    }
}
