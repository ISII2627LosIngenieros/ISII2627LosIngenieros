using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppForSEII.API.Models;

public class MaterialAlquilado
{
    public MaterialAlquilado()
    {
    }
    public MaterialAlquilado(string id, string descripcion, int cantidad, decimal precioMaterialAlquilado, string idAlquiler, string idMaterial)
    {
        IdMaterialAlquilado = id;
        Cantidad = cantidad;
        IdAlquiler = idAlquiler;
        IdMaterial = idMaterial;
        Descripcion = descripcion;
        PrecioMaterialAlquilado = precioMaterialAlquilado;
    }

    public int Cantidad {get;set;}

    [Key]
    [StringLength(50)]
    public string IdMaterialAlquilado {get;set;}

    [StringLength(50)]
    public string IdMaterial {get;set;}

    [StringLength(50)]
    public string IdAlquiler {get;set;}

    [StringLength(50)]
    public string? Descripcion {get;set;}

    [Column(TypeName = "decimal(20,2)")]
    public decimal PrecioMaterialAlquilado {get;set;}

    // Propiedad de Relación
    public Alquiler? Alquiler {get;set;}
    public Material? Material {get;set;}

     // --- Métodos ---
    public override bool Equals(object? obj) 
    { 
        return obj is MaterialAlquilado otro && IdMaterialAlquilado == otro.IdMaterialAlquilado; 
    }

    public override int GetHashCode() 
    { 
        return IdMaterialAlquilado.GetHashCode(); 
    }
}