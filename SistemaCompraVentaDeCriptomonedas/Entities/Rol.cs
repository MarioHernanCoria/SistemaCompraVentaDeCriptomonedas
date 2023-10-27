using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SistemaCompraVentaDeCriptomonedas.DTOs;
using System;
using SistemaCompraVentaDeCriptomonedas.Enums;

namespace SistemaCompraVentaDeCriptomonedas.Entities
{
    public class Rol
    {
        public Rol(RolDto dto)
        {
            Descripcion = dto.Descripcion;
            Tipo = dto.Tipo;
            Activo = true;
        }
        public Rol(RolDto dto, int id)
        {
            Id = id;
            Tipo = dto.Tipo;
            Descripcion = dto.Descripcion;
            Activo = true;
        }

        public Rol()
        {

        }

        public int Id { get; set; }
        [Required]
        public RolEnum  Tipo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public bool Activo { get; set; } = true;

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
