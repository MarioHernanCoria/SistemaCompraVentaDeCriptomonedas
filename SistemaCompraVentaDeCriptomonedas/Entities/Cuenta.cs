using SistemaCompraVentaDeCriptomonedas.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCompraVentaDeCriptomonedas.Entities
{
    public class Cuenta
    {
        public int Id { get; set; }
        public double Saldo { get; set; }
        public string Discriminator { get; set; }
    
    }
}
