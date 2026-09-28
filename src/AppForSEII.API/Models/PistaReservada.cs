using System.ComponentModel.DataAnnotations;

namespace AppForSEII.API.Models;

public class PistaReservada
{

    [Key]
    public int Id { get; set; }


    [Required]
    public int Cantidad { get; set; }


    [Required]
    public decimal Precio { get; set; }


    public string Observaciones { get; set; }



    public int IdPista { get; set; }

    public Pista Pista { get; set; }



    public int IdReserva { get; set; }

    public Reserva Reserva { get; set; }

}