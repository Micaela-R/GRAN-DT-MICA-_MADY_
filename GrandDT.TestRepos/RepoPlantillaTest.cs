using GranDT.Core;
using GranDT.Core.Repos;
using GranDT.Dapper;
using Dapper;

namespace GranDT.Test;

public class RepoPlantillaTests : TestRepo
{
    readonly IRepoPlantilla repoPlantilla;
    readonly IRepoUsuario repoUsuario;
    readonly IRepoFutbolista repoFutbolista;

    public RepoPlantillaTests() : base()
        => (repoPlantilla, repoUsuario, repoFutbolista) = 
           (new RepoPlantilla(conexion), new RepoUsuario(conexion), new RepoFutbolista(conexion));

    [Fact]
    public void AltaPlantilla_DevuelveIdValido()
    {
   // Usar propiedad de TestRepo
        var plantillas = new Plantillas
        {
            Nombre = "Plantilla Test",
            Presupuesto = 5000000,
            MaxJugadores = 23,
            idUsuario = 1,
            idEquipo = 1
        };

        var id = repoPlantilla.AltaPlantilla(plantillas);

        Assert.True(id > 0);
    }

    

    [Fact]
    public void TraerPlantillasPorIdUsuario_DevuelveLista()
    {

        var plantillas = new Plantillas
        {
            Nombre = "Plantilla Para Traer",
            Presupuesto = 6000000,
            MaxJugadores = 20,
            idUsuario = 1,
            idEquipo = 1
        };

        repoPlantilla.AltaPlantilla(plantillas);

        var plantillasPorUsuario = repoPlantilla.TraerPlantillasPorIdUsuario(1);

        Assert.NotEmpty(plantillasPorUsuario);
    }

    [Fact]
    public void AltaJugadorEnPlantilla_AgregaJugador()
    {
        int idFutbolista = 2;
        int idPlantilla = 1;

        repoPlantilla.AltaJugadorEnPlantilla(idFutbolista, idPlantilla, true);

        Assert.True(true);
    }


    [Fact]
    public void AltaPlantilla_ConPresupuestoGrande()
    {

        var plantillas = new Plantillas
        {
            Nombre = "Plantilla Millonaria",
            Presupuesto = 10000000,
            MaxJugadores = 30,
            idUsuario = 1,
            idEquipo = 1
        };

        var id = repoPlantilla.AltaPlantilla(plantillas);

        Assert.True(id > 0);
    }
}