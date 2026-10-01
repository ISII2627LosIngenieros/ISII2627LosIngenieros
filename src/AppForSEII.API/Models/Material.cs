using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppForSEII.API.Models;

public class Material
{
    public Material()
    {
    }
    public Material(string id, string nombrematerial, int cantidad, decimal preciomaterial)
    {
        IdMaterial = id;
        Cantidad = cantidad;
        NombreMaterial = nombrematerial;
        PrecioMaterial = preciomaterial;
    }

    public int Cantidad {get;set;}

    [Key]
    [StringLength(50)]
    public string IdMaterial {get;set;}

    [StringLength(50)]
    public string? NombreMaterial {get;set;}

    [Column(TypeName = "decimal(20,2)")]
    public decimal PrecioMaterial {get;set;}

    // Relación 1 a N
    public ICollection<MaterialAlquilado> HistorialAlquileres { get; set; } = new List<MaterialAlquilado>();

    // Claves foráneas (Foreign Keys) explícitas para EF Core
    public TipoMaterial TipoMaterial { get; set; }
    public string IdTipoMaterial { get; set; } 

    public TipoDeporte TipoDeporte { get; set; }
    public string IdTipoDeporte { get; set; }
        

    // --- Métodos ---
    public override bool Equals(object? obj) 
    { 
        return obj is Material otro && IdMaterial == otro.IdMaterial; 
    }

    public override int GetHashCode() 
    { 
        return IdMaterial.GetHashCode(); 
    }
}