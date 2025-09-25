USE `5to_rosita_fresita` ;
-- Procedimiento para dar de alta al usuario en base a su email y contraseña

DELIMITER $$
CREATE PROCEDURE alta_usuario (
   IN p_Email VARCHAR(45),
   IN p_Contraseña VARCHAR(255),
   IN p_Nombre VARCHAR(45),
   IN p_Apellido VARCHAR(45),
   IN p_Nacimiento DATE
)
BEGIN
   DECLARE v_Existe INT DEFAULT 0;
   DECLARE v_Mensaje VARCHAR(255);
   -- Verificar si ya existe un usuario con ese email
   SELECT COUNT(*) INTO v_Existe FROM Usuario WHERE Email = p_Email;
   IF v_Existe > 0 THEN
       SET v_Mensaje = 'Error: El email ya está registrado.';
       SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = v_Mensaje;
   ELSE
       -- Insertar usuario con contraseña encriptada
       INSERT INTO Usuario (
           Email, Nombre, Apellido, Nacimiento, Contraseña,
           Plantillas_idPlantilla, Plantillas_idUsuario, Tipo
       ) VALUES (
          p_Email, p_Nombre, p_Apellido, p_Nacimiento, SHA2(p_Contraseña, 256),
           0, '0', 'usuario'
       );
       SET v_Mensaje = 'Usuario registrado exitosamente.';
       SELECT v_Mensaje AS Mensaje;
   END IF;
END $$









Otro procedimiento para que en base del email y la contraseña si existe te da una fila o null

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

