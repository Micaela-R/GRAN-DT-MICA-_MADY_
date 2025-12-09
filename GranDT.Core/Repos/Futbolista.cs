namespace GranDT.Core;

public class Futbolistas
{
    public int idFutbolista { get; set; } = int.MinValue;
    public uint idEquipo { get; set; } = uint.MinValue;
    public uint idTipoJugador { get; set; } = uint.MinValue;

    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string? Apodo { get; set; } 
    public DateTime FechadeNacimiento { get; set; } = DateTime.MinValue;
    public decimal Cotizacion { get; set; }= decimal.Zero;

    public int Nota { get; set; }

    public Equipo? Equipo { get; set; } 
    public TipoJugador? TipoJugador { get; set; }
    public IEnumerable<Puntuacion> Puntuaciones { get; set; } = [];
    
    public string? NombreCompleto {get;}

}