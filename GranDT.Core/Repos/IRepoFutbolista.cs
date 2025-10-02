using GranDT.Core.Futbol;

namespace GranDT.Core.Repos;

public interface IRepoFutbolista
{
    void AltaFutbolista(Futbolista futbolista);
    IEnumerable<Futbolista> ObtenerFutbolistas();
    IEnumerable<TipoDeJugador> ObtenerTipoJugadores();
    
}
