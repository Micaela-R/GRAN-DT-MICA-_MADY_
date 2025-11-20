namespace GranDT.Core.Futbol;

public class Puntuacion
{

    public int idPuntuacion { get; set; }

    public int idFutbolista { get; set; }

    public float Puntaje { get; set; }

    public byte Fecha { get; set; }

    public string Cargador_por { get; set; } = string.Empty;
}