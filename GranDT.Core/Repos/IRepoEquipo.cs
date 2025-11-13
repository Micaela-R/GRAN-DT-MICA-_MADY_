using GranDT.Core.Futbol;

namespace GranDT.Core.Repos;

public interface IRepoEquipo
{
    void AltaEquipo(Equipo equipo);
    IEnumerable<Equipo> TraerEquipos();
}