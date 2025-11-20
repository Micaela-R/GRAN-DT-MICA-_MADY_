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
            Cantidad = 25
        };

        Assert.Equal(0, equipo.idEquipo);
        repo.AltaEquipo(equipo);
        Assert.NotEqual(0, equipo.idEquipo);
    }

    [Fact]
    public void Traer_Equipos()
    {
        var equipos = repo.TraerEquipos();

        Assert.NotNull(equipos);
        Assert.True(equipos.Any(),"La lista de equipos está vacía, verifica que existan registros en la tabla Equipos.");

        var primero = equipos.First();

        Assert.NotEqual(0, primero.idEquipo);
        Assert.False(string.IsNullOrEmpty(primero.Nombre), "El campo Nombre no debe estar vacío.");
        Assert.True(primero.Cantidad > 0, "La cantidad debe ser mayor que cero.");
    }

}
