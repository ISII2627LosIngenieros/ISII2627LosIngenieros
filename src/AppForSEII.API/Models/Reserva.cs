using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AppForSEII.API.Models;

public class Reserva
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string NombreCliente { get; set; }

    [Required]
    public string Apellidos { get; set; }

    [Required]
    public string Dni { get; set; }

    [Required]
    public DateTime FechaReserva { get; set; }

    [Required]
    public string MetodoPago { get; set; }

    [Required]
    [Precision(10, 2)]
    public decimal PrecioTotal { get; set; }
}