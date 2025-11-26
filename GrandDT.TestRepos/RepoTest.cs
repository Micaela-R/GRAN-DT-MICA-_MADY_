using System.Data;
using MySqlConnector;

namespace GrandDT.TestRepos;

public class RepoTest
{
    protected readonly IDbConnection Conexion;
    private readonly string conexion =
        @"server=localhost;database=5to_rosita_fresita;user id=5to_agbd;pwd=Trigg3rs!;";
    public RepoTest() => Conexion = new MySqlConnection(conexion);
}
