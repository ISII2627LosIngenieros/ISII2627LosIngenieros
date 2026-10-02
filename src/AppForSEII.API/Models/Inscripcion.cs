using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace AppForSEII.API.Models;

//Definición de la enumeración MetodoPago que representa los diferentes métodos de pago disponibles para una inscripción.
public enum MetodoPago
{
    Bizum,
    Efectivo,
    Tarjeta,
    Transferencia,
    Metalico
}
public class Inscripcion
{
    public IList<ClaseInscrita> ClasesInscritas { get; set; }  //Foreign key de la relación con la clase ClaseInscrita
    [Required]
    public ApplicationUser Cliente { get; set; }
    
    [Required(ErrorMessage = "Los datos de pago son obligatorios.")]
    [StringLength(100)]
    public String DatosPago { get; set; }

    [Required]
    public DateTime FechaInscripcion { get; set; }
    
    [Key]  //Añado la anotación por si acaso
    public Int32 Id { get; set; }   //Primary key de la tabla Inscripcion

    [Required(ErrorMessage = "El método de pago es obligatorio.")]
    public MetodoPago MetodoPago { get; set; }

    [Required]
    public Decimal PrecioTotal { get; set; }

    public Inscripcion()
    {
        //ClasesInscritas = new List<ClaseInscrita>();
    }

    [Required]
    [StringLength(50)]
    public String ApellidosUsuario {get; set;}

    [Required]
    [StringLength(10)]
    public String DNI {get; set;}

    [Required]
    [StringLength(50)]
    public String NombreUsuario {get; set;}

    [Required]
    public Int32 Telefono {get; set;}
}


