using Dapper;
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
                new Puntuacion { Fecha = 2, Puntaje = 8 },
                new Puntuacion { Fecha = 1, Puntaje = 9 }
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

    public void ObtenerFutbolistasPorTipo_ExistenFutbolistas_DeberiaDevolverlos()
    {
        var tipo = Conexion.QuerySingle<TipoDeJugador>(
        "SELECT * FROM TipoDeJugador WHERE idTipoDeJugador = 1");

        Assert.NotNull(tipo);

        Conexion.Execute("INSERT INTO Equipo (idEquipo, Nombre) VALUES (3, 'River')");

        Conexion.Execute
            (@"
            INSERT INTO Futbolistas 
            (idFutbolista, Nombre, Apodo, Nacimiento, idEquipo, idTipoDeJugador, Cotizacion, Creado_por)
            VALUES
            (2, 'Juan Pérez', 'El Tigre', '1990-06-15', 2, 2, 50000.00, 'Admin')
            ");

        Conexion.Execute
            (@"
            INSERT INTO Puntuacion (idPuntuacion, idFutbolista, Fecha, Puntos)
            VALUES
            (100, 1, '2024-01-01', 8),
            (101, 2, '2024-01-08', 6)
            ");

        var repo = new RepoFutbolista(Conexion);
        var resultado = repo.ObtenerFutbolistasPorTipo(tipo.IdTipoDeJugador);

        Assert.NotEmpty(resultado);

        var juan = resultado.First();

        Assert.Equal(1, juan.IdFutbolista);
        Assert.Equal("Juan Pérez", juan.Nombre);
        Assert.Equal("El Tigre", juan.Apodo);
        Assert.Equal(new DateTime(1990, 6, 15), juan.Nacimiento);

        Assert.Equal(tipo.Tipo, juan.TipoDeJugador.Tipo);
        Assert.Equal(tipo.IdTipoDeJugador, juan.TipoDeJugador.IdTipoDeJugador);

        Assert.NotNull(juan.Equipo);
        Assert.Equal("River", juan.Equipo.Nombre);

        Assert.True(juan.Puntuaciones.Any());
        Assert.Equal(2, juan.Puntuaciones.Count());
    }

    [Fact]

    public void ObtenerFutbolista_IdNoExiste_DevuelveNull()
    {
        int idInexistente = 9999;

        var resultado = repo.ObtenerFutbolista(idInexistente);

        Assert.Null(resultado);
    }

    [Fact]

    public void ObtenerDetalleFutbolista_SinPuntuaciones()
    {
        int idFutbolista = 2; // debe existir en tu BD

        var carlosG = repo.ObtenerFutbolista(idFutbolista);

        Assert.NotNull(carlosG);
        Assert.Equal(idFutbolista, carlosG.IdFutbolista);
        Assert.NotNull(carlosG.Nombre);
        Assert.Single(carlosG.Puntuaciones);
    }

    [Fact]

    public void ObtenerDetalleFutbolista_ConPuntuaciones()
    {
        int idFutbolista = 1; // debe existir en tu BD con puntuaciones cargadas

        var juanP = repo.ObtenerFutbolista(idFutbolista);

        Assert.NotNull(juanP);
        Assert.Equal(idFutbolista, juanP.IdFutbolista);
        Assert.NotNull(juanP.Nombre);
        Assert.NotEmpty(juanP.Puntuaciones);
        Assert.All(juanP.Puntuaciones, p =>

        {
            Assert.True(p.Puntaje >= 0, "El puntaje debe ser un valor positivo.");
            Assert.NotEqual(default, p.Fecha);
        });
    }


}