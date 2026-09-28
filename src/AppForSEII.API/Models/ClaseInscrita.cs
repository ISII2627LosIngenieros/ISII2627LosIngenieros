using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace AppForSEII.API.Models;

public class ClaseInscrita
{
    public ClaseDeportiva ClaseDeportiva { get; set; }  
    public Int32 ClaseDeportivaId { get; set; }  
    public Int32 Id { get; set; }  //Primary key de la tabla ClaseInscrita
    public Inscripcion Inscripcion { get; set; }
    public Int32 InscripcionId { get; set; }  //Foreign key de la relación con la clase Inscripcion
    public String? Observaciones { get; set; }
    public Int32 PlazasReservadas { get; set; }
    public Decimal Precio { get; set; }

    public ClaseInscrita()
    {
        
    }
}