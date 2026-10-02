using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppForSEII.API.Models;

public class Material
{
    public Material()
    {
    }
    public Material(string id, string nombrematerial, int cantidad, decimal preciomaterial, string idTipoMaterial, string idTipoDeporte)
    {
        IdMaterial = id;
        Cantidad = cantidad;
        NombreMaterial = nombrematerial;
        PrecioMaterial = preciomaterial;
        IdTipoMaterial = idTipoMaterial;
        IdTipoDeporte = idTipoDeporte;
    }

    public int Cantidad {get;set;}

    [Key]
    [StringLength(50)]
    public string IdMaterial {get;set;}

    [StringLength(50)]
    public string NombreMaterial {get;set;}

    [Column(TypeName = "decimal(20,2)")]
    public decimal PrecioMaterial {get;set;}

    // Relación 1 a N
    public IList<MaterialAlquilado> MaterialesAlquileres { get; set; } = new List<MaterialAlquilado>();

    // Claves foráneas (Foreign Keys)
    public TipoMaterial TipoMaterial { get; set; }
    [ForeignKey("IdTipoMaterial")]
    public string IdTipoMaterial { get; set; } 

    public TipoDeporte TipoDeporte { get; set; }
    [ForeignKey("IdTipoDeporte")]
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