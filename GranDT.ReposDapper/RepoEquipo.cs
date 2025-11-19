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
        var parametros = new DynamicParameters();

            parametros.Add("@p_idEquipo", equipo.idEquipo);
            parametros.Add("@p_Nombre", equipo.Nombre);
            parametros.Add("@p_Cantidad", equipo.Cantidad);

            try
            {
                Conexion.Execute("alta_equipo", parametros, commandType: CommandType.StoredProcedure);
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
                var equipos = Conexion.Query<Equipo>("traer_equipos", commandType: CommandType.StoredProcedure);
                return equipos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer los equipos.", ex);
            }
    }
}