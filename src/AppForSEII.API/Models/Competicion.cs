using Microsoft.AspNetCore.Identity;

namespace AppForSEII.API.Models;

public class Competicion
{
    public Competicion()
    {
    }
    public Competicion(int id, string fecha, string lugar, string nombre, int plazas, decimal precio)
    {
        Id = id;
        Fecha = fecha;
        Lugar = lugar;
        Nombre = nombre;
        Plazas = plazas;
        Precio = precio;
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Fecha {get;set;}

    [Required]
    [StringLength(50)]
    public string Lugar {get;set;}

    [Required]
    [StringLength(50)]
    public string Nombre {get;set;}
    
    [Required]
    public int Plazas {get;set;}

    [Required]
    public decimal Precio {get;set;}

    // Métodos adicionales

}
