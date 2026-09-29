public class ClaseDeportiva
{
    //public iList<ClaseInscrita> ClasesInscritas { get; set; }  //Relación con la clase ClaseInscrita
    public String descripcion { get; set; }
    public DateTime FechaHora { get; set; }
    public int Id { get; set; }  //Primary key de la tabla ClaseDeportiva
    public String? lugar { get; set; }
    public String monitor { get; set; }
    public Int32 plazasDisponibles { get; set; }
    public Decimal precioUnitario { get; set; }
    //public TipoDeporte tipoDeporte { get; set; }  //Relación con la clase TipoDeporte
    public Int32 TipoDeporteId { get; set; }  //Foreign key de la relación con la clase TipoDeporte
}