USE `5to_rosita_fresita`;
-- Procedimiento para dar de alta al usuario en base a su email y contrasena

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
   
   -- Insertar usuario con contrasena encriptada
   INSERT INTO Usuario 
            (Email, Nombre, Apellido, Nacimiento, Contrasena, Tipo) 
      VALUES ( p_Email, p_Nombre, p_Apellido, p_Nacimiento, p_Contrasena, 'Usuario'
   );
   
   SET idUsuario = LAST_INSERT_ID();
END $$

-- Otro procedimiento para que en base del email y la contrasena si existe te da una fila o null
DELIMITER $$

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