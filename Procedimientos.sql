USE `5to_rosita_fresita` ;
-- Procedimiento para dar de alta al usuario en base a su email y contraseña

DELIMITER $$

CREATE PROCEDURE alta_usuario (
   IN p_Email VARCHAR(45),
   IN p_Contrasena VARCHAR(255),
   IN p_Nombre VARCHAR(45),
   IN p_Apellido VARCHAR(45),
   IN p_Nacimiento DATE,
   OUT idUsuario INT
)
BEGIN
   
   -- Insertar usuario con contraseña encriptada
   INSERT INTO Usuario (
      Email, Nombre, Apellido, Nacimiento, Contrasena,
      Plantillas_idPlantilla, Plantillas_idUsuario, Tipo
   ) VALUES (
      p_Email, p_Nombre, p_Apellido, p_Nacimiento, p_Contrasena,
      0, '0', 'Usuario'
   );
   
   SET idUsuario = LAST_INSERT_ID();
END $$

-- Otro procedimiento para que en base del email y la contraseña si existe te da una fila o null

DELIMITER $$

CREATE PROCEDURE validar_usuario (
   IN p_Email VARCHAR(45),
   IN p_Contraseña VARCHAR(255)
)
BEGIN
   -- Seleccionamos el usuario si existe y la contraseña coincide
   SELECT idUsuario, Email, Nombre, Apellido, Nacimiento, Tipo
   FROM Usuario
   WHERE Email = p_Email
   AND Contraseña = SHA2(p_Contraseña, 256)
   LIMIT 1;
END $$

-- dar de alta un futbolista

DROP PROCEDURE IF EXISTS alta_futbolista;
DELIMITER $$

CREATE PROCEDURE alta_futbolista (
   IN p_idEquipo INT,
   IN p_idTipoDeJugador INT,
   IN p_Nombre VARCHAR(45),
   IN p_Apodo VARCHAR(45),
   IN p_Nacimiento DATE,
   IN p_Cotizacion DECIMAL(8,2),
   IN p_Creado_por VARCHAR(45)
)
BEGIN
   INSERT INTO Futbolistas (
      idEquipo,
      idTipoDeJugador,
      Nombre,
      Apodo,
      Nacimiento,
      Cotizacion,
      Creado_por
   )
   VALUES (
      p_idEquipo,
      p_idTipoDeJugador,
      p_Nombre,
      p_Apodo,
      p_Nacimiento,
      p_Cotizacion,
      p_Creado_por
   );
END $$

