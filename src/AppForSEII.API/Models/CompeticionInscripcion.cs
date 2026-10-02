using Microsoft.AspNetCore.Identity;

namespace AppForSEII.API.Models;

[PrimaryKey(nameof(CompeticionId), nameof(InscripcionId))] // es una clase intermedia, sus claves primarias son las claves foráneas de las otras dos tablas
public class CompeticionInscripcion
{
    public CompeticionInscripcion()
    {
    }
    public CompeticionInscripcion(int competicionId, int inscripcionId, string problemasFisicos)
    {
        CompeticionId = competicionId;
        InscripcionId = inscripcionId;
        ProblemasFisicos = problemasFisicos;
    }


    public Competicion Competicion { get; set; } = null!;   // el objeto Competicion asociado a esta inscripción en la competición
                                                            // con esto se pueden ver los datos de la competición desde la inscripción
                                                            // el =null!; es para indicar que no puede ser nulo, ya que es obligatorio tener una competición asociada a la inscripción

    [ForeignKey(nameof(Competicion))]
    public int CompeticionId { get; set; }

    public Inscripcion Inscripcion { get; set; } = null!;   // igual que para la competición

    [ForeignKey(nameof(Inscripcion))]
    public int InscripcionId { get; set; }

    [StringLength(100)]
    public string? ProblemasFisicos { get; set; }


    // Métodos adicionales

}
