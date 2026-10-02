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
        ClasesInscritas = new List<ClaseInscrita>();
        CompeticionInscripciones = new List<CompeticionInscripcion>();
    }

    [Required(ErrorMessage = "Es obligatorio introducir el apellido del usuario.")]
    [StringLength(50)]
    public String ApellidosUsuario {get; set;}

    [Required(ErrorMessage = "El DNI es obligatorio.")]
    [StringLength(10)]
    public String DNI {get; set;}

    [Required(ErrorMessage = "Es obligatorio introducir el nombre del usuario.")]
    [StringLength(50)]
    public String NombreUsuario {get; set;}

    [Required(ErrorMessage = "Es obligatorio introducir el teléfono del usuario.")]
    [StringLength(20)]
    public String Telefono {get; set;}

    // Relación con la clase intermedia CompeticionInscripcion
    public IList<CompeticionInscripcion> CompeticionInscripciones { get; set; }

    //Constructores de los dos casos de uso
    //Caso de uso 4: Inscripción a una clase deportiva
    public Inscripcion(ClaseInscrita claseInscrita, ApplicationUser cliente, string datosPago, DateTime fechaInscripcion, int id, MetodoPago metodoPago, decimal precioTotal)
    {
        ClasesInscritas = new List<ClaseInscrita> { claseInscrita };
        Cliente = cliente;
        DatosPago = datosPago;
        FechaInscripcion = fechaInscripcion;
        Id = id;
        MetodoPago = metodoPago;
        PrecioTotal = precioTotal;
    }

    //Caso de uso 3: Inscribirse a una competición
    public Inscripcion(ApplicationUser cliente, string fechaInscripcion, int id, MetodoPago metodoPago, decimal precioTotal)
    {
        ClasesInscritas = new List<ClaseInscrita>();
        Cliente = cliente;
        FechaInscripcion = DateTime.Parse(fechaInscripcion);
        Id = id;
        MetodoPago = metodoPago;
        PrecioTotal = precioTotal;
    }
}

