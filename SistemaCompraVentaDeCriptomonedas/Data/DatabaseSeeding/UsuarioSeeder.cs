using Microsoft.EntityFrameworkCore;
using SistemaCompraVentaDeCriptomonedas.Entities;
using SistemaCompraVentaDeCriptomonedas.Enums;
using SistemaCompraVentaDeCriptomonedas.Helpers;
using System.ComponentModel.DataAnnotations;

namespace SistemaCompraVentaDeCriptomonedas.DataAccess.DatabaseSeeding
{
    public class UsuarioSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    Id = 1,
                    Tipo = RolEnum.ADMINISTRADOR,
                    Descripcion = "ADMINISTRADOR",
                    Activo = true,
                    UsuarioId = 1
                },
                new Rol
                {
                    Id = 2,
                    Tipo = RolEnum.CLIENTE,
                    Descripcion = "CLIENTE",
                    Activo = true,
                    UsuarioId = 1
                },
                new Rol
                {
                    Id = 3,
                    Tipo = RolEnum.OPERADOR,
                    Descripcion = "OPERADOR",
                    Activo = true,
                    UsuarioId = 2
                },
                new Rol
                {
                    Id = 4,
                    Tipo = RolEnum.ANALISTA,
                    Descripcion = "ANALISTA",
                    Activo = true,
                    UsuarioId = 2
                },
                new Rol
                {
                    Id = 5,
                    Tipo = RolEnum.AUDITOR,
                    Descripcion = "AUDITOR",
                    Activo = true,
                    UsuarioId = 3
                },  
                new Rol
                {
                    Id = 6,
                    Tipo = RolEnum.USUARIO,
                    Descripcion = "USUARIO",
                    Activo = true,
                    UsuarioId = 1
                },
                 new Rol
                 {
                     Id = 7,
                     Tipo = RolEnum.USUARIO,
                     Descripcion = "USUARIO",
                     Activo = true,
                     UsuarioId = 2
                 },
                  new Rol
                  {
                      Id = 8,
                      Tipo = RolEnum.USUARIO,
                      Descripcion = "USUARIO",
                      Activo = true,
                      UsuarioId = 3
                  }
              );


           modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nombre = "Mario",
                    Apellido = "Coria",
                    Dni = 42863574,
                    Email = "mariocoria@gmail.com",
                    Clave = PasswordEncryptHelper.EncryptPassword("1111", "mariocoria@gmail.com"),
                    //Roles = new List<Rol> { new Rol {Tipo = RolEnum.ADMINISTRADOR , Descripcion = "ADMINISTRADOR", Activo = true } },
                    FechaNacimiento = new DateTime(2000, 1, 11),
                    Genero = GeneroEnum.MASCULINO,
                    EstadoCivil = EstadoCivilEnum.SOLTERO
                },
                new Usuario 
                {
                    Id = 2,
                    Nombre = "Alicia",
                    Apellido = "Coria",
                    Dni = 78627162,
                    Email = "aliciacoria@gmail.com",
                    Clave = PasswordEncryptHelper.EncryptPassword("9999", "aliciacoria@gmail.com"),
                    //Roles = new List<Rol> { new Rol {Tipo = RolEnum.CLIENTE, Descripcion = "CLIENTE", Activo = true } },
                    FechaNacimiento = new DateTime(1969, 8, 8),
                    Genero = GeneroEnum.FEMENINO,
                    EstadoCivil = EstadoCivilEnum.SOLTERO
                },
                new Usuario
                {
                    Id = 3,
                    Nombre = "Edwin",
                    Apellido = "Gonzales",
                    Dni = 60312412,
                    Email = "edwingonzales@gmail.com",
                    Clave = PasswordEncryptHelper.EncryptPassword("4444", "edwingonzales@gmail.com"),
                    //Roles = new List<Rol> { new Rol { Tipo = RolEnum.CLIENTE, Descripcion = "CLIENTE", Activo = true } },
                    FechaNacimiento = new DateTime(1969, 8, 8),
                    Genero = GeneroEnum.MASCULINO,
                    EstadoCivil = EstadoCivilEnum.SOLTERO
                },
                new Usuario
                {
                    Id = 4,
                    Nombre = "Sergio",
                    Apellido = "Solana",
                    Dni = 25364734,
                    Email = "sergiosolana@gmail.com",
                    Clave = PasswordEncryptHelper.EncryptPassword("2345", "sergiosolana@gmail.com"),
                    //Roles = new List<Rol> { new Rol {Tipo = RolEnum.CLIENTE, Descripcion = "CLIENTE", Activo = true } },
                    FechaNacimiento = new DateTime(1950, 8, 8),
                    Genero = GeneroEnum.MASCULINO,
                    EstadoCivil = EstadoCivilEnum.CASADO
                },
                new Usuario
                {
                    Id = 5,
                    Nombre = "Marina",
                    Apellido = "Silla",
                    Dni = 64392547,
                    Email = "marinasilla@gmail.com",
                    Clave = PasswordEncryptHelper.EncryptPassword("12345", "marinasilla@gmail.com"),
                    //Roles = new List<Rol> { new Rol {Tipo = RolEnum.CLIENTE, Descripcion = "CLIENTE", Activo = true } },
                    FechaNacimiento = new DateTime(1963, 8, 8),
                    Genero = GeneroEnum.FEMENINO,
                    EstadoCivil = EstadoCivilEnum.VIUDA
                },
                new Usuario
                {
                    Id = 6,
                    Nombre = "Claudia",
                    Apellido = "Vargas",
                    Dni = 09743265,
                    Email = "claudiavargas@gmail.com",
                    Clave = PasswordEncryptHelper.EncryptPassword("4567", "claudiavargas@gmail.com"),
                    //Roles = new List<Rol> { new Rol {Tipo = RolEnum.CLIENTE, Descripcion = "CLIENTE", Activo = true } },
                    FechaNacimiento = new DateTime(1962, 8, 8),
                    Genero = GeneroEnum.FEMENINO,
                    EstadoCivil = EstadoCivilEnum.SOLTERO
                },
                new Usuario
                {
                    Id = 7,
                    Nombre = "Raquel",
                    Apellido = "Vargas",
                    Dni = 36598645,
                    Email = "raquelvargas@gmail.com",
                    Clave = PasswordEncryptHelper.EncryptPassword("3423", "raquelvargas@gmail.com"),
                    //Roles = new List<Rol> { new Rol {Tipo = RolEnum.CLIENTE, Descripcion = "CLIENTE", Activo = true } },
                    FechaNacimiento = new DateTime(1939, 8, 8),
                    Genero = GeneroEnum.FEMENINO,
                    EstadoCivil = EstadoCivilEnum.SOLTERO
                },
                new Usuario
                {
                    Id = 8,
                    Nombre = "Ana",
                    Apellido = "Coria",
                    Dni = 25463548,
                    Email = "anacoria@gmail.com",
                    Clave = PasswordEncryptHelper.EncryptPassword("1236", "anacoria@gmail.com"),
                    //Roles = new List<Rol> { new Rol {Tipo = RolEnum.CLIENTE, Descripcion = "CLIENTE", Activo = true } },
                    FechaNacimiento = new DateTime(1930, 8, 8),
                    Genero = GeneroEnum.FEMENINO,
                    EstadoCivil = EstadoCivilEnum.CASADO
                },
                new Usuario
                {
                    Id = 9,
                    Nombre = "Emilia",
                    Apellido = "America",
                    Dni = 26473645,
                    Email = "emiliaamerica@gmail.com",
                    Clave = PasswordEncryptHelper.EncryptPassword("3456", "emiliaamerica@gmail.com"),
                    //Roles = new List<Rol> { new Rol {Tipo = RolEnum.CLIENTE, Descripcion = "CLIENTE", Activo = true } },
                    FechaNacimiento = new DateTime(2000, 8, 8),
                    Genero = GeneroEnum.FEMENINO,
                    EstadoCivil = EstadoCivilEnum.SOLTERO
                },
                new Usuario
                {
                    Id = 10,
                    Nombre = "Dario",
                    Apellido = "Corbalan",
                    Dni = 36475635,
                    Email = "dariocorbalan@gmail.com",
                    Clave = PasswordEncryptHelper.EncryptPassword("2313", "dariocorbalan@gmail.com"),
                    //Roles = new List<Rol> { new Rol {Tipo = RolEnum.CLIENTE, Descripcion = "CLIENTE", Activo = true } },
                    FechaNacimiento = new DateTime(1980, 8, 8),
                    Genero = GeneroEnum.MASCULINO,
                    EstadoCivil = EstadoCivilEnum.SOLTERO
                },
                new Usuario
                {
                    Id = 11,
                    Nombre = "Fernando",
                    Apellido = "Corbalan",
                    Dni = 40265736,
                    Email = "fernandocorbalan@gmail.com",
                    Clave = PasswordEncryptHelper.EncryptPassword("2313", "afernandocorbalan@gmail.com"),
                    //Roles = new List<Rol> { new Rol {Tipo = RolEnum.CLIENTE, Descripcion = "CLIENTE", Activo = true } },
                    FechaNacimiento = new DateTime(2003, 8, 8),
                    Genero = GeneroEnum.MASCULINO,
                    EstadoCivil = EstadoCivilEnum.SOLTERO
                },
                new Usuario
                {
                    Id = 12,
                    Nombre = "Brian",
                    Apellido = "Solan",
                    Dni = 35465768,
                    Email = "briansolana@gmail.com",
                    Clave = PasswordEncryptHelper.EncryptPassword("1231", "riansolana@gmail.com"),
                    //Roles = new List<Rol> { new Rol {Tipo = RolEnum.CLIENTE, Descripcion = "CLIENTE", Activo = true } },
                    FechaNacimiento = new DateTime(1990, 8, 8),
                    Genero = GeneroEnum.MASCULINO,
                    EstadoCivil = EstadoCivilEnum.VIUDA
                },
                new Usuario
                {
                    Id = 13,
                    Nombre = "Mariana",
                    Apellido = "Correa",
                    Dni = 24354623,
                    Email = "marianacorrea@gmail.com",
                    Clave = PasswordEncryptHelper.EncryptPassword("8888", "marianacorrea@gmail.com"),
                    //Roles = new List<Rol> { new Rol {Tipo = RolEnum.CLIENTE, Descripcion = "CLIENTE", Activo = true } },
                    FechaNacimiento = new DateTime(1998, 8, 8),
                    Genero = GeneroEnum.FEMENINO,
                    EstadoCivil = EstadoCivilEnum.SOLTERO
                },
                new Usuario
                {
                    Id = 14,
                    Nombre = "Pablo",
                    Apellido = "Vargas",
                    Dni = 97869785,
                    Email = "pablovargas@gmail.com",
                    Clave = PasswordEncryptHelper.EncryptPassword("0987", "pablovargas@gmail.com"),
                    //Roles = new List<Rol> { new Rol {Tipo = RolEnum.CLIENTE, Descripcion = "CLIENTE", Activo = true } },
                    FechaNacimiento = new DateTime(2005, 8, 8),
                    Genero = GeneroEnum.MASCULINO,
                    EstadoCivil = EstadoCivilEnum.SOLTERO


              });
        }

    }
}
