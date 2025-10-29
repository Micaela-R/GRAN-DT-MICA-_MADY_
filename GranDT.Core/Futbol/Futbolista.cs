namespace GranDT.Core.Futbol;

public class Futbolista
{

    public int idFutbolistas { get; set; }

    public string Nombre { get; set; } = string.Empty;
    public string Apodo { get; set; } = string.Empty;
    public DateTime Nacimiento { get; set; }
    public int idEquipo { get; set; }
    public int idTipoDeJugador { get; set; }
    public decimal Cotizacion { get; set; }
    public string Creado_por { get; set; } = string.Empty;
    public int TipoDeJugador_idTipoDeJugador { get; set; }
    public int TipoDeJugador_idFutbolista { get; set; }
    public int Equipo_idEquipo { get; set; }
}