using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AppForSEII.API.Models;

public class Reserva
{
    public ApplicationUser Cliente { get; set; }  //Para usar datos de esta clase
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime FechaReserva { get; set; }

    [Required]
    public string MetodoPago { get; set; }

    [Required]
    [Precision(10, 2)]
    public decimal PrecioTotal { get; set; }

    //Constructor
    public Reserva()
    {
    }

    public Reserva(ApplicationUser cliente, int id, DateTime fechaReserva, string metodoPago, decimal precioTotal)
    {
        Cliente = cliente;
        Id = id;
        FechaReserva = fechaReserva;
        MetodoPago = metodoPago;
        PrecioTotal = precioTotal;
    }
}