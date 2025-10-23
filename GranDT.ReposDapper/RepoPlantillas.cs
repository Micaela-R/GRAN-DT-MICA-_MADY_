using System.Data;
using Dapper;
using GranDT.Core;
using GranDT.Core.Repos;

namespace GranDT.ReposDapper
{
public class RepoPlantillas : Repo, IRepoPlantillas
    {
        public RepoPlantillas(IDbConnection conexion) : base(conexion)
        {
        }

        // Obtener las plantillas de un usuario específico con futbolistas y posiciones
        public void ObtenerPlantillasPorUsuario(int idUsuario)
        {
            var sql = @"
                SELECT 
                    p.idPlantilla, 
                    p.Nombre AS PlantillaNombre, 
                    p.idUsuario,
                    f.idFutbolistas, 
                    f.Nombre AS FutbolistaNombre, 
                    f.Apodo, 
                    f.Nacimiento,
                    td.idTipoDeJugador, 
                    td.Tipo AS Posicion
                FROM Plantillas p
                LEFT JOIN FutbolistaPlantilla fp ON fp.idPlantilla = p.idPlantilla
                LEFT JOIN Futbolistas f ON f.idFutbolistas = fp.idFutbolista
                LEFT JOIN TipoDeJugador td ON td.idTipoDeJugador = f.idTipoDeJugador
                WHERE p.idUsuario = @idUsuario
                ORDER BY p.idPlantilla, f.idFutbolistas";

            var plantillasConFutbolistas = new Dictionary<int, FutbolistaPlantilla();

            // Ejecutar la consulta y construir los objetos
            var resultados = Conexion.Query<FutbolistaPlantilla, FutbolistaConPosicion, FutbolistaPlantilla>(
                sql,
                (plantilla, futbolistaConPosicion) =>
                {
                    if (!plantillasConFutbolistas.ContainsKey(plantilla.idPlantilla))
                    {
                        plantillasConFutbolistas[plantilla.idPlantilla] = plantilla;
                    }

                    plantillasConFutbolistas[plantilla.idPlantilla].Futbolistas.Add(futbolistaConPosicion);
                    return plantilla;
                },
                new { idUsuario }, // parámetro para filtrar por el idUsuario
                splitOn: "idFutbolistas, idTipoDeJugador"
            );

            return plantillasConFutbolistas.Values;
        }
    }
}