using GrandDT.TestRepos;
using GranDT;
using GranDT.Core.Futbol;
using GranDT.Core.Repos;
using GranDT.ReposDapper;
using Microsoft.VisualBasic;

namespace GranDT.TestRepos;

public class RepoFutbolistaTest : RepoTest
{
    IRepoFutbolista repo;

    public RepoFutbolistaTest() : base() => repo = new RepoFutbolista(Conexion);

    [Fact]

    public void AltaFutbolista()
    {
        var equipo = new Equipo { idEquipo = 1, Nombre = "PSG" };
        var tipoDeJugador = new TipoDeJugador { IdTipoDeJugador = 1, Tipo = "Delantero" };
        var puntuaciones = new List<Puntuacion>

            {
                new Puntuacion { Fecha = new DateTime(2024, 3, 1), Puntaje = 8 },
                new Puntuacion { Fecha = new DateTime(2024, 3, 8), Puntaje = 9 }
            };

        var Messi = new Futbolista("Lionel", "Messi", new DateTime(1987, 6, 24),
                                    equipo,tipoDeJugador, puntuaciones, 100000000, "Test");

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

    [Fact]

    public void ObtenerFutbolista_IdNoExiste_DevuelveNull()
    {
        int idInexistente = 9999;

        var resultado = repo.ObtenerFutbolistas(idInexistente);

        Assert.Null(resultado);
    }

    [Fact]

    public void ObtenerDetalleFutbolista_SinPuntuaciones()
    {
        int idFutbolista = 2; // debe existir en tu BD, pero sin puntuaciones asociadas

        var resultado = repo.ObtenerDetalleFutbolista(idFutbolista);

        Assert.NotNull(resultado);
        Assert.Equal(idFutbolista, resultado.IdFutbolista);
        Assert.NotNull(resultado.Nombre);
        Assert.Empty(resultado.Puntuaciones);
    }

    [Fact]

    public void ObtenerDetalleFutbolista_ConPuntuaciones()
    {
        int idFutbolista = 1; // debe existir en tu BD con puntuaciones cargadas

        var resultado = repo.ObtenerDetalleFutbolista(idFutbolista);

        Assert.NotNull(resultado);
        Assert.Equal(idFutbolista, resultado.IdFutbolista);
        Assert.NotNull(resultado.Nombre);
        Assert.NotEmpty(resultado.Puntuaciones);
        Assert.All(resultado.Puntuaciones, p =>

        {
            Assert.True(p.Puntaje >= 0, "El puntaje debe ser un valor positivo.");
            Assert.NotEqual(default(DateTime), p.Fecha);
        });
    }


}