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

    // Fecha, Lugar y Nombre se han definido como string vacío en caso de que no se pase ninguno por el constructor
    [Required]
    [StringLength(50)]
    public string Fecha {get;set;} = string.Empty;

    [Required]
    [StringLength(50)]
    public string Lugar {get;set;} = string.Empty;

    [Required]
    [StringLength(50)]
    public string Nombre {get;set;} = string.Empty;
    
    public int Plazas {get;set;}

    public decimal Precio {get;set;}

    // Métodos adicionales

}
