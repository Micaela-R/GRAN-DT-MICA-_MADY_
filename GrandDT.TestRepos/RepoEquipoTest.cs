using System.Collections;
using System.ComponentModel;
using GranDT.Core.Futbol;
using GranDT.Core.Repos;
using GranDT.ReposDapper;

namespace GrandDT.TestRepos;

public class RepoEquipoTest : RepoTest
{
    IRepoEquipo repo;

    public RepoEquipoTest() : base() => repo = new RepoEquipo(Conexion);

    [Fact]

    public void AltaEquipo()
    {
        var equipo = new Equipo
        {
            idEquipo = 0,
            Nombre = "PSG",

        };

        Assert.Equal(0, equipo.idEquipo);
        repo.AltaEquipo(equipo);
        Assert.NotEqual(0, actual: equipo.idEquipo);
    }

    [Fact]
    public void Traer_Equipos()
    {
        var equipos = repo.TraerEquipos();

        Assert.NotNull(equipos);
        Assert.Contains(equipos, e => e.Nombre == "Equipo A");

        var primero = equipos.First();

        Assert.NotEqual(0, primero.idEquipo);
        Assert.False(string.IsNullOrEmpty(primero.Nombre), "El campo Nombre no debe estar vacío.");
    }

}
