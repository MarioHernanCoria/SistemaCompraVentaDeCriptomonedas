namespace SistemaCompraVentaDeCriptomonedas.DTOs
{
    public class CuentaCriptoDto
    {
         public string UUID { get; set; } = Guid.NewGuid().ToString();
         public string NombreCripto { get; set; }
         public double  Saldo { get; set; }
    }
}
