using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppForSEII.API.Models;

public class TipoDeporte
{
    public TipoDeporte()
    {
    }
    public TipoDeporte(string id, string nombre, string competicion, string pistas, string materiales, string nombretipodeporte, string? descripcion)
    {
        Id = id;
        Nombre = nombre;
        Competiciones = competicion;
        Pistas = pistas;
        Materiales = materiales;
        NombreTipoDeporte = nombretipodeporte;
        Descripcion = descripcion;
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

    [StringLength(50)]
    public string Materiales {get;set;}

    [StringLength(50)]
    public string NombreTipoDeporte {get;set;}

    [StringLength(50)]
    public string? Descripcion {get;set;}

    // Relación 1 a N
    public IList<Material> Materiales { get; set; }

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
