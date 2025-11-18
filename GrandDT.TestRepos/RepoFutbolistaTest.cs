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

    public void ObtenerFutbolistasPorTipo_ExistenFutbolistas_DeberiaDevolverlos()
    {
        int idTipo = 2;

        Conexion.Execute("INSERT INTO TipoDeJugador (idTipoDeJugador, Tipo) VALUES (2, 'Medio')");

        Conexion.Execute("INSERT INTO Equipo (idEquipo, Nombre, Cantidad) VALUES (10, 'Boca', 25)");

        Conexion.Execute(@"
        INSERT INTO Futbolistas 
        (idFutbolista, Nombre, Apodo, Nacimiento, idEquipo, idTipoDeJugador, Cotizacion, Creado_por)
        VALUES
        (1, 'Juan', 'El 10', '1990-01-01', 10, 2, 5000000, 'admin'),
        (2, 'Pedro', 'Pedrito', '1992-05-10', 10, 2, 4200000, 'admin')
        ");

        Conexion.Execute(@"
        INSERT INTO Puntuacion (idPuntuacion, idFutbolista, Fecha, Puntos)
        VALUES
        (100, 1, '2024-01-01', 8),
        (101, 1, '2024-01-08', 6),
        (200, 2, '2024-01-01', 7)
        ");

        var repo = new RepoFutbolista(Conexion);
        var resultado = repo.ObtenerFutbolistasPorTipo(idTipo).ToList();

        Assert.NotEmpty(resultado);
        Assert.Equal(2, resultado.Count);

        var f1 = resultado.First(f => f.IdFutbolista == 1);
        Assert.Equal("Juan", f1.Nombre);
        Assert.Equal("Medio", f1.TipoDeJugador.Tipo);
        Assert.Equal("Boca", f1.Equipo.Nombre);
        Assert.True(f1.Puntuaciones.Any());

        var f2 = resultado.First(f => f.IdFutbolista == 2);
        Assert.Equal("Pedro", f2.Nombre);
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
        int idFutbolista = 2; // debe existir en tu BD, pero sin puntuaciones asociadas

        var resultado = repo.ObtenerFutbolista(idFutbolista);

        Assert.NotNull(resultado);
        Assert.Equal(idFutbolista, resultado.IdFutbolista);
        Assert.NotNull(resultado.Nombre);
        Assert.Empty(resultado.Puntuaciones);
    }

    [Fact]

    public void ObtenerDetalleFutbolista_ConPuntuaciones()
    {
        int idFutbolista = 1; // debe existir en tu BD con puntuaciones cargadas

        var resultado = repo.ObtenerFutbolista(idFutbolista);

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