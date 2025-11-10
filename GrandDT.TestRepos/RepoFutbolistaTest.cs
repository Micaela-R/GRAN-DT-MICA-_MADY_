using GrandDT.TestRepos;
using GranDT;
using GranDT.Core.Futbol;
using GranDT.Core.Repos;
using GranDT.ReposDapper;

namespace GranDT.TestRepos;

public class RepoFutbolistaTest : RepoTest
{
    IRepoFutbolista repo;

    public RepoFutbolistaTest() : base() => repo = new RepoFutbolista(Conexion);

    [Fact]

    public void AltaFutbolista()
    {
        var Messi = new Futbolista("Lionel", "Messi", (1987, 6, 24), equipo,
                                    tipoDeJugador, puntuaciones, 100000000, "Test"
        =;)

        Assert.Equal(0, Messi.IdFutbolista);
        repo.AltaFutbolista(Messi);
        Assert.NotEqual(0, Messi.IdFutbolista);
    }

    [Fact]
    public void ObtenerFutbolistas_OK()
    {
        var futbolistas = repo.ObtenerFutbolistas();

        Assert.NotNull(futbolistas);
        Assert.True(futbolistas.Any(),
            "La lista de futbolistas está vacía, verifica que existan registros en la tabla Futbolistas.");

        var primero = futbolistas.First();

        Assert.NotEqual(0, primero.IdFutbolista);
        Assert.False(string.IsNullOrEmpty(primero.Nombre), "El campo Nombre no debe estar vacío.");
        Assert.NotEqual(default(DateTime), primero.Nacimiento);
    }

    [Fact]

    public void ObtenerTipoJugadores_OK()
    {
        var tipos = repo.ObtenerTipoJugadores();

        Assert.NotNull(tipos);  // La consulta no debe devolver null
        Assert.True(tipos.Any(),
            "La lista de tipos de jugadores está vacía. Asegúrate de que existan registros en la tabla TipoDeJugador.");

        var primero = tipos.First();

        Assert.NotEqual(0, primero.IdTipoDeJugador);
        Assert.False(string.IsNullOrEmpty(primero.Tipo), "El campo Tipo no debe estar vacío.");
    }
}