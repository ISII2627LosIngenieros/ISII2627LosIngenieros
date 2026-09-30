using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace AppForSEII.API.Models;

public class ClaseInscrita
{
    //public ClaseDeportiva ClaseDeportiva { get; set; }  

    [ForeignKey("ClaseDeportiva")]
    public Int32 ClaseDeportivaId { get; set; }  //Foreign key de la relación con la clase ClaseDeportiva

    [Key]  //Añadido el [Key] por si acaso
    public Int32 Id { get; set; }  //Primary key de la tabla ClaseInscrita

    //public Inscripcion Inscripcion { get; set; }

    [ForeignKey("Inscripcion")]
    public Int32 InscripcionId { get; set; }  //Foreign key de la relación con la clase Inscripcion

    [StringLength(200)]
    public String? Observaciones { get; set; }

    [Required]
    public Int32 PlazasReservadas { get; set; }

    [Required]
    public Decimal Precio { get; set; }

    public ClaseInscrita()
    {
        
    }
}