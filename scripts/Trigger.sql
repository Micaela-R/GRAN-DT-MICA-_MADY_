USE `5to_rosita_fresita`;

DELIMITER $$

DROP TRIGGER IF EXISTS encriptar_contrasena_before_insert $$

CREATE TRIGGER encriptar_contrasena_before_insert 
BEFORE INSERT ON Usuario
FOR EACH ROW
BEGIN
-- Verificamos que la contraseña no esté ya encriptada (opcional)
  SET NEW.Contrasena = SHA2(NEW.Contrasena, 256);
END $$