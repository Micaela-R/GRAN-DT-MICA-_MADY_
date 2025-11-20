using GranDT.Core.Futbol;
using GranDT.Core.Repos;

namespace GranDT.Core.Repos;

public interface IRepoEquipo
{
    void AltaEquipo(Equipo equipo);
    IEnumerable<Equipo> TraerEquipos();
}
