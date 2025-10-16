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
        var david = new Usuario()
        {
            Nombre = "David",
            Apellido = "Ascensor",
            Email = "123456@gmail.com",
            Nacimiento = new DateTime(2007, 01, 15)
        };

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
}
