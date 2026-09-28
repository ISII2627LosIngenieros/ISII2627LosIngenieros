using Microsoft.AspNetCore.Identity;

namespace AppForSEII.API.Models;

public class TipoDeporte
{
    public TipoDeporte()
    {
    }
    public TipoDeporte(string id, string nombre, string competicion, string pistas)
    {
        Id = id;
        Nombre = nombre;
        Competiciones = competicion;
        Pistas = pistas;
    }

    [StringLength(50)]
    public string Competiciones {get;set;}

    [Key]
    [StringLength(50)]
    public string Id {get;set;}

    [StringLength(50)]
    public string Nombre {get;set;}

    [StringLength(50)]
    public string Pistas {get;set;}

    // Relación 1 a N
    public ICollection<Material> Materiales { get; set; } = new List<Material>();

    // --- Métodos ---
    public override bool Equals(object? obj) 
    { 
        return obj is TipoDeporte otro && Id == otro.Id; 
    }

    public override int GetHashCode() 
    { 
        return Id.GetHashCode(); 
    }
}
