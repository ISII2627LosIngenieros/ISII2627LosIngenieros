using Microsoft.AspNetCore.Identity;

namespace AppForSEII.API.Models;

public class TipoMaterial
{
    //Constructorees
    public TipoMaterial()
    {
    }
    public TipoMaterial(string idtipomaterial, string nametipomaterial)
    {
        IdTipoMaterial = idtipomaterial;
        NameTipoMaterial = nametipomaterial;
    }

    //Creación de variables
    [StringLength(30)]
    public string IdTipoMaterial {get;set;}

    [StringLength(50)]
    public string? NameTipoMaterial {get;set;}

    //Metodos que puede realizar la clase
    // Relación 1 a N con Material
    public ICollection<Material> Materiales { get; set; } = new List<Material>();

    // Comparación basada en el ID del TipoMaterial
    public override bool Equals(object? obj) 
    { 
        return obj is TipoMaterial otro && IdTipoMaterial == otro.IdTipoMaterial; 
    }

    public override int GetHashCode() 
    { 
        return IdTipoMaterial.GetHashCode(); 
    }
}