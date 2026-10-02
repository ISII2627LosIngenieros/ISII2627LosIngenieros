using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppForSEII.API.Models;

public class Pista
{
    public Pista()
    {
        PistasReservadas = new List<PistaReservada>();
    }

    [Key]
    public int IdPista { get; set; }

    [Required]
    public string NombrePista { get; set; }

    public int NPersonas { get; set; }

    [Precision(10, 2)]
    public decimal Precio { get; set; }

    public int Stock { get; set; }

    [ForeignKey(nameof(TipoDeporte))]
    public int IdTipoDeporte { get; set; }

    public TipoDeporte TipoDeporte { get; set; }

    public IList<PistaReservada> PistasReservadas { get; set; }

    //Constructor
    public Pista(int idPista, string nombrePista, int nPersonas, decimal precio, int stock, int idTipoDeporte)
    {
        IdPista = idPista;
        NombrePista = nombrePista;
        NPersonas = nPersonas;
        Precio = precio;
        Stock = stock;
        IdTipoDeporte = idTipoDeporte;
    }
}