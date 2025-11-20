using System.Data;
using Dapper;
using GranDT.Core.Futbol;
using GranDT.Core.Repos;

namespace GranDT.ReposDapper;

public class RepoEquipo : Repo, IRepoEquipo
{
    public RepoEquipo(IDbConnection conexion) : base(conexion)
    {
    }

    public void AltaEquipo(Equipo equipo)
    {
        var sql = @"
        INSERT INTO Equipo (Nombre)
        VALUES (@Nombre);
        SELECT last_insert_id();
        ";

        try
        {
            int nuevoId = Conexion.ExecuteScalar<int>(sql, new
        {
            Nombre = equipo.Nombre
        });

            equipo.idEquipo = nuevoId;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al dar de alta el equipo.", ex);
        }
    }

    public IEnumerable<Equipo> TraerEquipos()
    {
        try
        {
            var sql = "SELECT IdEquipo, Nombre, Ciudad, FechaFundacion FROM Equipo";

            var equipos = Conexion.Query<Equipo>(sql);
            return equipos;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al traer los equipo.", ex);
        }
    }
}