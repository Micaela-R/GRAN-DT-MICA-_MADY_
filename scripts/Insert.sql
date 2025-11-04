USE `5to_rosita_fresita`;

SELECT 'Agregando Usuarios' AS Estado;

INSERT INTO
    `Usuario` (
        `idUsuario`,
        `Email`,
        `Nombre`,
        `Apellido`,
        `Nacimiento`,
        `Contrasena`,
        `Tipo`
    )
VALUES (
        1,
        'juan.perez@example.com',
        'Juan',
        'Pérez',
        '1990-06-15',
        'haspassword123',
        'Admin'
    ),
    (
        2,
        'carlos.gomez@example.com',
        'Carlos',
        'Gómez',
        '1992-03-10',
        'haspassword456',
        'User'
    );


SELECT 'Agregando Equipo' AS Estado;

INSERT INTO
    `Equipo` (
        `idEquipo`,
        `Cantidad`,
        `Nombre`
    )
VALUES (1, 11, 'Equipo A'),
    (2, 11, 'Equipo B');

    SELECT 'Agregando TipoDeJugador' AS Estado;

INSERT INTO
    `TipoDeJugador` (
        `idTipoDeJugador`,
        `Tipo`,
        `idFutbolista`
    )
VALUES (1, 'Delantero', 'F001'),
    (2, 'Defensor', 'F002'),
    (3, 'Centrocampista', 'F003');

SELECT 'Agregando Futbolistas' AS Estado;

INSERT INTO
    `Futbolistas` (
        `idFutbolista`,
        `Nombre`,
        `Apodo`,
        `Nacimiento`,
        `idEquipo`,
        `idTipoDeJugador`,
        `Cotizacion`,
        `Creado_por`,
        `TipoDeJugador_idTipoDeJugador`,
        `TipoDeJugador_idFutbolista`,
        `Equipo_idEquipo`,
        `Puntuacion_Fecha`,
        `Puntuacion_idFutbolista`,
        `Puntuacion_idPuntuacion`
    )
VALUES (
        1,
        'Juan Pérez',
        'El Tigre',
        '1990-06-15',
        1,
        1,
        50000.00,
        'Admin',
        1,
        'F001',
        1,
        '2025-09-23',
        1,
        1
    ),
    (
        2,
        'Carlos Gómez',
        'El Gato',
        '1992-03-10',
        2,
        2,
        40000.00,
        'Admin',
        2,
        'F002',
        2,
        '2025-09-23',
        2,
        2
    );

SELECT 'Agregando Plantillas' AS Estado;   

INSERT INTO
`Plantillas`(
    `idPlantilla`,
    `Nombre`,
    `idUsuario`
)
VALUES (
        1,
        'Cancha A',
        1
    ),
    (
        2,
        'Cancha B',
        2
    );

SELECT 'Agregando Puntuacion' AS Estado;  

INSERT INTO
    `Puntuacion` (
        `idPuntuacion`,
        `idFutbolista`,
        `Puntaje`,
        `Fecha`,
        `Cargado_Por`
    )
VALUES (
        1,
        1,
        8.5,
        '2025-09-23',
        'Administrador'
    ),
    (
        2,
        2,
        7.3,
        '2025-09-23',
        'Administrador'
    );

