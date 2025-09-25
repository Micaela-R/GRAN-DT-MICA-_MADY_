using System.Data;

namespace GranDT.ReposDapper;

public abstract class Repo
{
    protected IDbConnection Conexion { get; private set; }
    public Repo(IDbConnection conexion) => Conexion = conexion;
}