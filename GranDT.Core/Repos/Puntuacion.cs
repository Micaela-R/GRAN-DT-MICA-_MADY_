using GranDT.Core;

namespace GranDT.Core
{
public class Puntuacion
{

    public int idPuntuacion { get; set; } = int.MinValue;
    public uint idFutbolista { get; set; }
    
    public decimal? Nota { get; set; }

    public DateTime? FechaPartido { get; set; }

    public Futbolistas? Futbolista { get; set; }
 }
} 
