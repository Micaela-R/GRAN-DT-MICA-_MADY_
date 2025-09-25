USE `5to_rosita_fresita` ;
DELIMITER $$
DROP CREATE TRIGGER encriptar_contraseña_before_insert
CREATE TRIGGER encriptar_contraseña_before_insert
BEFORE INSERT ON Usuario
FOR EACH ROW
BEGIN
 -- Verificamos que la contraseña no esté ya encriptada (opcional)
   SET NEW.Contrasena = SHA2(NEW.Contraseña, 256);
END $$
}