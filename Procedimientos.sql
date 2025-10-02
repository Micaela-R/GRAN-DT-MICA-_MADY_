USE `5to_rosita_fresita`;
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