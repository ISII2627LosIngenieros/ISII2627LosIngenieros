using System.ComponentModel.DataAnnotations;

namespace AppForSEII.API.Models;

public class Reserva
{
    public Reserva()
    {
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string NombreCliente { get; set; }

    [Required]
    public string Apellidos { get; set; }

    [Required]
    public string Dni { get; set; }

    public DateTime FechaReserva { get; set; }

    [Required]
    public string MetodoPago { get; set; }

    public decimal PrecioTotal { get; set; }

    

}