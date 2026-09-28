namespace AppForSEII.API.Models;
public class Pista
{
    [System.ComponentModel.DataAnnotations.Key]
    public int IdPista { get; set; }

    public string NombrePista { get; set; }

    public int NPersonas { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }


    public int IdTipoDeporte { get; set; }

    public TipoDeporte TipoDeporte { get; set; }


    public ICollection<PistaReservada> PistasReservadas { get; set; } = new List<PistaReservada>();
}