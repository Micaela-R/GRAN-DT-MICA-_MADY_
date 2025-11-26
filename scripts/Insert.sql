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
        `Nombre`
    )
VALUES (1, 'Equipo A'),
    (2, 'Equipo B');

    SELECT 'Agregando TipoDeJugador' AS Estado;

INSERT INTO
    `TipoDeJugador` (
        `idTipoDeJugador`,
        `Tipo`
    )
VALUES (1, 'Delantero'),
    (2, 'Defensor'),
    (3, 'Centrocampista'),
    (4, 'Arquero');

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
        `Creado_por`
    )
VALUES (
        1,
        'Juan Pérez',
        'El Tigre',
        '1990-06-15',
        1,
        1,
        50000.00,
        'Admin'
    ),
    (
        2,
        'Carlos Gómez',
        'El Gato',
        '1992-03-10',
        2,
        2,
        40000.00,
        'Admin'
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
        `idFutbolista`,
        `Puntaje`,
        `Fecha`,
        `Cargado_Por`
    )
VALUES (
        1,
        8.5,
        1,
        'Administrador'
    ),
    (
        2,
        7.3,
        2,
        'Administrador'
    );

    SELECT 'Agregando Titular' AS Estado; 

    INSERT INTO `Suplente` (
    `idFutbolista`,
    `idPlantilla`
)
VALUES
    (1, 1),
    (2, 2);

SELECT 'Agregando Titular' AS Estado;

INSERT INTO `Titular` (
    `idFutbolista`,
    `idPlantilla`
)
VALUES
    (1, 2),
    (2, 1);

