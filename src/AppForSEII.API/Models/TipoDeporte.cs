using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppForSEII.API.Models;

public class TipoDeporte
{
    public TipoDeporte()
    {
    }
    
    [Required]
    [StringLength(50)]
    public string Competicion {get;set;}

    [Key]
    [StringLength(50)]
    public Int32 Id {get;set;}

    [Required]
    [StringLength(50)]
    public string Nombre {get;set;}

    [Required]
    [StringLength(50)]
    public string Pistas {get;set;}

    [Required]
    [StringLength(50)]
    public string NombreTipoDeporte {get;set;}

    [StringLength(50)]
    public string? Descripcion {get;set;}

    // Relación 1 a N
    public IList<Material> ListaMateriales { get; set; }
    public IList<Competicion> Competiciones { get; set; }
    public IList<ClaseDeportiva> ClasesDeportivas { get; set; }

    //Constructores para cada caso de uso
    //Caso de uso 1: reservar pista
    public TipoDeporte(string competicion, int id, List<Material> materiales, string nombre, string nombreTipoDeporte)
    {
        Competicion = competicion;
        Id = id;
        ListaMateriales = materiales;
        Nombre = nombre;
        NombreTipoDeporte = nombreTipoDeporte;
    }

    //Caso de uso 2: Alquilar Material
    public TipoDeporte(int id, string nombreTipoDeporte)
    {
        Id = id;
        NombreTipoDeporte = nombreTipoDeporte;
    }

    //Caso de uso 3: Inscribirse a una competición
    public TipoDeporte(int id, List<Competicion> competiciones, string nombre)
    {
        Id = id;
        Competiciones = competiciones;
    }

    //Caso de uso 4: Inscribirse a clases deportivas
    public TipoDeporte(int id, string? descripcion, List<ClaseDeportiva> clasesDeportivas, string nombre)
    {
        Id = id;
        Descripcion = descripcion;
        ClasesDeportivas = clasesDeportivas;
    }

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
