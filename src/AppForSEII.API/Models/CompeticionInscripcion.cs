using Microsoft.AspNetCore.Identity;

namespace AppForSEII.API.Models;

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

    public string? ProblemasFisicos { get; set; }


    // Métodos adicionales

}
