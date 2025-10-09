namespace GranDT.Core.Futbol;

public class Futbolista
{

    public int idFutbolistas { get; set; }

    public string Nombre { get; set; }
    public string Apodo { get; set; }
    public DateTime Nacimiento { get; set; }
    public int idEquipo { get; set; }
    public int idTipoDeJugador { get; set; }
    public decimal Cotizacion { get; set; }
    public string Creado_por { get; set; }
    public int TipoDeJugadorr_idTipoDeJugador { get; set; }
    public int TipoDeJugadorr_idFutbolista { get; set; }
    public int Equipo_idEquipo { get; set; }
}