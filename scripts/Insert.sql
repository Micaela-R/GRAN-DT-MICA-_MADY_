
USE `5to_rosita_fresita` ;
INSERT INTO `Equipo` (`idEquipo`, `Cantidad`, `Nombre`)
VALUES
(1, 11, 'Equipo A'),
(2, 11, 'Equipo B');

INSERT INTO `Puntuacion` (`idPuntuacion`, `idFutbolistas`, `Puntaje`, `Fecha`, `Cargado_Por`)
VALUES
(1, 1, 8.5, '2025-09-23', 'Administrador'),
(2, 2, 7.3, '2025-09-23', 'Administrador');


INSERT INTO `FutbolistaPlantilla` (`idFutbolista`, `idPlantilla`)
VALUES
(1, 1),
(2, 2)


INSERT INTO `TipoDeJugador` (`idTipoDeJugador`, `Tipo`, `idFutbolistas`)
VALUES
(1, 'Delantero', 'F001'),
(2, 'Defensor', 'F002'),
(3, 'Centrocampista', 'F003');


INSERT INTO `Futbolistas`
(`idFutbolistas`, `Nombre`, `Apodo`, `Nacimiento`, `idEquipo`, `idTipoDeJugador`, `Cotizacion`, `Creado_por`,
`TipoDeJugador_idTipoDeJugador`, `TipoDeJugador_idFutbolistas`, `Equipo_idEquipo`, `Puntuacion_Fecha`, `Puntuacion_idFutbolistas`, `Puntuacion_idPuntuacion`)
VALUES
(1, 'Juan Pérez', 'El Tigre', '1990-06-15', 1, 1, 50000.00, 'Admin', 1, 'F001', 1, '2025-09-23', 1, 1),
(2, 'Carlos Gómez', 'El Gato', '1992-03-10', 2, 2, 40000.00, 'Admin', 2, 'F002', 2, '2025-09-23', 2, 2);


INSERT INTO `Usuario` (`idUsuario`, `Email`, `Nombre`, `Apellido`, `Nacimiento`, `Contrasena`, `Plantillas_idPlantilla`, `Plantillas_idUsuario`, `Tipo`)
VALUES
(1, 'juan.perez@example.com', 'Juan', 'Pérez', '1990-06-15', 'haspassword123', 1, 'U001', 'Admin'),
(2, 'carlos.gomez@example.com', 'Carlos', 'Gómez', '1992-03-10', 'haspassword456', 2, 'U002', 'User');


INSERT INTO `FutbolistaPlantilla` (`idFutbolista`, `idPlantilla`)
VALUES
(1, 1),
(2, 2);


