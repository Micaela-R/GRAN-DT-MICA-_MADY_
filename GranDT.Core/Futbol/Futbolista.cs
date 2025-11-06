namespace GranDT.Core.Futbol;

public class Futbolista
{
    public int IdFutbolista { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apodo { get; set; } = string.Empty;
    public DateTime Nacimiento { get; set; }
    public Equipo Equipo { get; set; }
    public TipoDeJugador TipoDeJugador { get; set; }
    public IEnumerable<Puntuacion> Puntuaciones { get; set; } = [];
    public decimal Cotizacion { get; set; }
    public string Creado_por { get; set; } = string.Empty;
    public Futbolista(string nombre, string? apodo,
                        DateTime nacimiento, Equipo equipo,
                        TipoDeJugador tipoDeJugador, IEnumerable<Puntuacion> puntuaciones,
                        decimal cotizacion, string creado_por,
                        int idFutbolista = 0)
    {
        IdFutbolista = idFutbolista;
        Nombre = nombre;
        Apodo = apodo;
        Nacimiento = nacimiento;
        Equipo = equipo;
        TipoDeJugador = tipoDeJugador;
        Puntuaciones = puntuaciones;
        Cotizacion = cotizacion;
        Creado_por = creado_por;
    }

}