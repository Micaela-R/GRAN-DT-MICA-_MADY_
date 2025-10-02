using System.Data;
using GranDT.Core.Futbol;
using GranDT.Core.Repos;

namespace GranDT.ReposDapper;

public class RepoFutbolista : Repo, IRepoFutbolista
{
    public RepoFutbolista(IDbConnection conexion) : base(conexion)
    {
    }

    public void AltaFutbolista(Futbolista futbolista)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Futbolista> ObtenerFutbolistas()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TipoDeJugador> ObtenerTipoJugadores()
    {
        throw new NotImplementedException();
    }
}
