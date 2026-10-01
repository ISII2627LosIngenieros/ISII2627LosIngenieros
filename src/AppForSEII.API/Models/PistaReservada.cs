using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppForSEII.API.Models;

public class PistaReservada
{
    [Key]
    public int Id { get; set; }

    public int Cantidad { get; set; }

    [Precision(10, 2)]
    public decimal Precio { get; set; }

    public string Observaciones { get; set; }

    [ForeignKey(nameof(Pista))]
    public int IdPista { get; set; }

    public Pista Pista { get; set; }

    [ForeignKey(nameof(Reserva))]
    public int IdReserva { get; set; }

    public Reserva Reserva { get; set; }
}