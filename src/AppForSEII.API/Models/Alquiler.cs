using System.ComponentModel.DataAnnotations;
namespace AppForSEII.API.Models;

public class Alquiler
{
    //Constructorees
   public Alquiler()
    {
    }

    public Alquiler(string apellidosusuario, string dni, DateTime fechaalquiler, string idalquiler, string materialalquilado, string metodopago, string nombreusuario, string numerotelefono, decimal preciototal)
    {
        ApellidosUsuario = apellidosusuario;
        DNI = dni;
        FechaAlquiler = fechaalquiler;
        IdAlquiler = idalquiler;
        MaterialAlquilado = materialalquilado;
        MetodoPago = metodopago;
        NombreUsuario = nombreusuario;
        NumeroTelefono = numerotelefono;
        PrecioTotal = preciototal;
    }

    //Creación de variables
    [StringLength(50)]
    public string ApellidosUsuario { get; set; }

    [StringLength(50)]
    public string DNI { get; set; }

    public DateTime FechaAlquiler {get;set;}

    [Required]
    [StringLength(50)]
    public string IdAlquiler { get; set; }

    [StringLength(50)]
    public string MaterialAlquilado { get; set; }

    [StringLength(50)]
    public string MetodoPago { get; set; }

    [StringLength(50)]
    public string NombreUsuario { get; set; }

    [StringLength(20)]
    public string? NumeroTelefono {get;set;}

    [Column(TypeName = "decimal(20,2)")]
    public decimal PrecioTotal {get;set;}

    //Metodos que puede realizar la clase
    // Relación 1 a N con Material
    public IList<MaterialAlquilado> MaterialesAlquilados { get; set; }

    // Comparación basada en el ID del Alquiler
    public override bool Equals(object? obj) 
    { 
        return obj is Alquiler otro && IdAlquiler == otro.IdAlquiler; 
    }

    public override int GetHashCode() 
    { 
        return IdAlquiler.GetHashCode(); 
    }
}