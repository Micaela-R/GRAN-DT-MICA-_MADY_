using GrandDT.TestRepos;
using GranDT.Core;
using GranDT.Core.Repos;
using GranDT.ReposDapper;

namespace GranDT.TestRepos;

public class RepoUsuarioTest : RepoTest
{
    IRepoUsuario repo;
    public RepoUsuarioTest() : base() => repo = new RepoUsuario(Conexion);

    [Fact]
    public void AltaUsuario()
    {
        var david = new Usuario(
            nombre: "David",
            apellido: "Ascensor",
            email: "123456@gmail.com",
            nacimiento: new DateTime(2007, 01, 15)
        );

        Assert.Equal(0, david.IdUsuario);
        repo.AltaUsuario(david, "123456");
        Assert.NotEqual(0, david.IdUsuario);
    }

    [Fact]
    public void TraerPorMailPassOK()
    {
        var Email = "carlos.gomez@example.com";
        var Pass = "haspassword456";

        var carlos = repo.UsuarioPorPass(Email, Pass);

        Assert.NotNull(carlos);
        Assert.Equal(Email, carlos.Email);
        Assert.Equal("Carlos", carlos.Nombre);
    }

    [Fact]
    public void TraerUsuarioNull()
    {
        var Email = "123456@gmail.com";
        var Pass = "clave_incorrecta";

        var usuario = repo.UsuarioPorPass(Email, Pass);

        Assert.Null(usuario);
    }

    [Fact]

    public void ObtenerPlantillasSinDetalle_OK()
    {
        int idUsuario = 3; 

        var plantilla = repo.ObtenerPlantillasSinDetalle(idUsuario);

        Assert.NotNull(plantilla);

        Assert.Equal(idUsuario, plantilla.IdUsuario);

        Assert.False(string.IsNullOrEmpty(plantilla.Nombre),
            "El campo Nombre no debe estar vacío.");
    }

    [Fact]
    
    public void ObtenerPlantillaSuperCargada_OK()
    {
        int idPlantilla = 1;

        var plantilla = repo.ObtenerPlantillaSuperCargada(idPlantilla);

        Assert.NotNull(plantilla);
        Assert.Equal(idPlantilla, plantilla.IdPlantilla);

        // Verificamos los datos básicos
        Assert.False(string.IsNullOrEmpty(plantilla.Nombre), "El nombre de la plantilla no debe ser vacío.");
        Assert.True(plantilla.IdUsuario > 0, "La plantilla debe pertenecer a un usuario válido.");

        Assert.NotNull(plantilla.Titulares);
        Assert.NotNull(plantilla.Suplentes);

        if (plantilla.Titulares.Any())
            {
                var titular = plantilla.Titulares.First();
                Assert.NotEqual(0, titular.IdFutbolista);
                Assert.False(string.IsNullOrEmpty(titular.Nombre));
                Assert.NotNull(titular.Equipo);
                Assert.NotNull(titular.TipoDeJugador);
            }

        if (plantilla.Suplentes.Any())
            {
                var suplente = plantilla.Suplentes.First();
                Assert.NotEqual(0, suplente.IdFutbolista);
                Assert.False(string.IsNullOrEmpty(suplente.Nombre));
            }
    }
}
