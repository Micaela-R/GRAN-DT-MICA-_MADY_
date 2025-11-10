using GranDT.Core.Futbol;

namespace GranDT.Core;

public class Plantilla
{
    public Plantilla(int idUsuario, string nombre, int idPlantilla = 0)
    {
        IdPlantilla = idPlantilla;
        Nombre = nombre;
        IdUsuario = idUsuario;
    }

    public int IdPlantilla { get; set; }

    public string Nombre { get; set; }

    public int IdUsuario { get; set; }
    public IEnumerable<Futbolista> Titulares { get; set; } = [];

    public IEnumerable<Futbolista> Suplentes { get; set; } = [];
}