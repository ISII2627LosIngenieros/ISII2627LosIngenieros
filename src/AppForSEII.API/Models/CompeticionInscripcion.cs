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


    public int CompeticionId { get; set; }

    public int InscripcionId { get; set; }

    [StringLength(100)]
    public string? ProblemasFisicos { get; set; }


    // Métodos adicionales

}
