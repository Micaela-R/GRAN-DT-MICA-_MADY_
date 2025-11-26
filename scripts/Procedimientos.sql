USE `5to_rosita_fresita` ;

-- Procedimiento para dar de alta al usuario en base a su email y contrasena

DELIMITER $$

DROP PROCEDURE IF EXISTS alta_usuario $$
CREATE PROCEDURE alta_usuario (
   IN p_Email VARCHAR(45),
   IN p_Contrasena VARCHAR(255),
   IN p_Nombre VARCHAR(45),
   IN p_Apellido VARCHAR(45),
   IN p_Nacimiento DATE,
   OUT idUsuario INT
)
BEGIN
   
   -- Insertar usuario con contrasena encriptada
   INSERT INTO Usuario 
            (Email, Nombre, Apellido, Nacimiento, Contrasena, Tipo) 
      VALUES ( p_Email, p_Nombre, p_Apellido, p_Nacimiento, p_Contrasena, 'Usuario'
   );
   
   SET idUsuario = LAST_INSERT_ID();
END $$

-- Otro procedimiento para que en base del email y la contrasena si existe te da una fila o null
DELIMITER $$

DROP PROCEDURE IF EXISTS validar_usuario $$
CREATE PROCEDURE validar_usuario (
   IN p_Email VARCHAR(45),
   IN p_Contrasena VARCHAR(255)
)
BEGIN
   -- Seleccionamos el usuario si existe y la contrasena coincide
   SELECT idUsuariogit
   WHERE Email = p_Email
   AND Contrasena = SHA2(p_Contrasena, 256)
   LIMIT 1;
END $$

-- alta futbolista 

DELIMITER $$

DROP PROCEDURE IF EXISTS alta_futbolista $$
CREATE PROCEDURE alta_futbolista (
   IN p_idEquipo INT,
   IN p_idTipoDeJugador INT,
   IN p_Nombre VARCHAR(45),
   IN p_Apodo VARCHAR(45),
   IN p_Nacimiento DATE,
   IN p_Cotizacion DECIMAL(8,2),
   IN p_Creado_por VARCHAR(45),
   OUT idFutbolista INT
)
BEGIN
   INSERT INTO Futbolistas 
      (idEquipo, idTipoDeJugador, Nombre, Apodo, Nacimiento, Cotizacion, Creado_por)
   VALUES 
      (p_idEquipo, p_idTipoDeJugador, p_Nombre, p_Apodo, p_Nacimiento, p_Cotizacion, p_Creado_por);

   SET idFutbolista = LAST_INSERT_ID();
END $$