public class ClaseDeportiva
{
    public IList<ClaseInscrita> ClasesInscritas { get; set; }  //Relación con la clase ClaseInscrita

    [Required]
    [StringLength(200)]
    public String Descripcion { get; set; }

    [Required]
    public DateTime FechaHora { get; set; }

    [Key]  //Añado la anotación [Key] por si acaso
    public int Id { get; set; }  //Primary key de la tabla ClaseDeportiva

    [StringLength(100)]
    public String? Lugar { get; set; }

    [Required]
    [StringLength(50)]
    public String Monitor { get; set; }

    [Required]
    [StringLength(50)]
    public String Nivel { get; set; }  

    [Required]
    public Int32 PlazasDisponibles { get; set; }

    [Required]
    public Decimal PrecioUnitario { get; set; }

    public TipoDeporte tipoDeporte { get; set; }  //Relación con la clase TipoDeporte

    [ForeignKey("TipoDeporte")]
    public Int32 TipoDeporteId { get; set; }  //Foreign key de la relación con la clase TipoDeporte

    public ClaseDeportiva()  //Constructor para inicializar una lista vacía de ClasesInscritas
    {
        ClasesInscritas = new List<ClaseInscrita>();
    }
}