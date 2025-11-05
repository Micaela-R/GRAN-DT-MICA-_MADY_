-- Active: 1756318445900@@127.0.0.1@3306@5to_rosita_fresita
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

-- Trigger antes de insertar al Titular 
DELIMITER $$

DROP TRIGGER IF EXISTS befInsTitular $$

CREATE TRIGGER befTitular BEFORE INSERT ON Titular FOR EACH ROW
BEGIN
    DECLARE mensaje VARCHAR(128);

    IF (EXISTS (SELECT *
                FROM Suplente
                WHERE idFutbolista = NEW.idFutbolista
                AND idPlantilla = NEW.idPlantilla
    )) THEN
        SET mensaje = CONCAT( 'Error: El futbolista con id ', NEW.idFutbolista,
                              ' ya figura como SUPLENTE en la plantilla ', NEW.idPlantilla, '.');
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = mensaje;
    END IF;
END $$

-- Trigger antes de insertar o elegir a los Seplentes

DELIMITER $$

DROP TRIGGER IF EXISTS befInsSuplente $$

CREATE TRIGGER befSuplente BEFORE INSERT ON Suplente FOR EACH ROW
BEGIN
    DECLARE mensaje VARCHAR(128);

    IF (EXISTS(SELECT *
              FROM Titular
              WHERE idFutbolista = NEW.idFutbolista
              AND idPlantilla = NEW.idPlantilla
    )) THEN
        SET mensaje = CONCAT('Error: El futbolista con id ', NEW.idFutbolista,
                            ' ya figura como TITULAR en la plantilla ', NEW.idPlantilla, '.');
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = mensaje;
    END IF;
END $$

