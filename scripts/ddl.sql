-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS = @@UNIQUE_CHECKS, UNIQUE_CHECKS = 0;

SET
    @OLD_FOREIGN_KEY_CHECKS = @@FOREIGN_KEY_CHECKS,
    FOREIGN_KEY_CHECKS = 0;

SET
    @OLD_SQL_MODE = @@SQL_MODE,
    SQL_MODE = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema 5to_rosita_fresita
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `5to_rosita_fresita`;

-- -----------------------------------------------------
-- Schema 5to_rosita_fresita
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `5to_rosita_fresita` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_as_ci;

USE `5to_rosita_fresita`;

-- -----------------------------------------------------
-- Table `Equipo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Equipo` (
    `idEquipo` INT NOT NULL AUTO_INCREMENT,
    `Nombre` VARCHAR(45) NOT NULL,
    PRIMARY KEY (`idEquipo`),
    UNIQUE INDEX `Nombre_UNIQUE` (`Nombre` ASC) VISIBLE
) ENGINE = InnoDB DEFAULT CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_as_ci;

-- -----------------------------------------------------
-- Table `TipoDeJugador`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TipoDeJugador` (
    `idTipoDeJugador` INT NOT NULL,
    `Tipo` VARCHAR(45) NOT NULL,
    PRIMARY KEY (`idTipoDeJugador`),
    UNIQUE INDEX `Tipo_UNIQUE` (`Tipo` ASC) VISIBLE
) ENGINE = InnoDB DEFAULT CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_as_ci;

-- -----------------------------------------------------
-- Table `Futbolistas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Futbolistas` (
    `idFutbolista` INT NOT NULL AUTO_INCREMENT,
    `idEquipo` INT NOT NULL,
    `idTipoDeJugador` INT NOT NULL,
    `Nombre` VARCHAR(45) NOT NULL,
    `Apodo` VARCHAR(45) NOT NULL,
    `Nacimiento` DATE NOT NULL,
    `Cotizacion` DECIMAL(8, 2) NOT NULL,
    `Creado_por` VARCHAR(45) NOT NULL,
    PRIMARY KEY (
        `idFutbolista`,
        `idEquipo`,
        `idTipoDeJugador`
    ),
    INDEX `fk_Futbolistas_Equipo1_idx` (`idEquipo` ASC) VISIBLE,
    INDEX `fk_Futbolistas_TipoDeJugador1_idx` (`idTipoDeJugador` ASC) VISIBLE,
    CONSTRAINT `fk_Futbolistas_Equipo1` FOREIGN KEY (`idEquipo`) REFERENCES `Equipo` (`idEquipo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT `fk_Futbolistas_TipoDeJugador1` FOREIGN KEY (`idTipoDeJugador`) REFERENCES `TipoDeJugador` (`idTipoDeJugador`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB DEFAULT CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_as_ci;

-- -----------------------------------------------------
-- Table `Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Usuario` (
    `idUsuario` INT NOT NULL AUTO_INCREMENT,
    `Email` VARCHAR(45) NOT NULL,
    `Nombre` VARCHAR(45) NOT NULL,
    `Apellido` VARCHAR(45) NOT NULL,
    `Nacimiento` DATE NOT NULL,
    `Contrasena` CHAR(64) NOT NULL,
    `Tipo` VARCHAR(45) NOT NULL,
    PRIMARY KEY (`idUsuario`),
    UNIQUE INDEX `Email_UNIQUE` (`Email` ASC) VISIBLE
) ENGINE = InnoDB AUTO_INCREMENT = 3 DEFAULT CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_as_ci;

-- -----------------------------------------------------
-- Table `Plantillas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Plantillas` (
    `idPlantilla` INT NOT NULL,
    `Nombre` VARCHAR(45) NOT NULL,
    `idUsuario` INT NOT NULL,
    PRIMARY KEY (`idPlantilla`, `idUsuario`),
    INDEX `fk_Plantillas_Usuario1_idx` (`idUsuario` ASC) VISIBLE,
    CONSTRAINT `fk_Plantillas_Usuario1` FOREIGN KEY (`idUsuario`) REFERENCES `Usuario` (`idUsuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB DEFAULT CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_as_ci;

-- -----------------------------------------------------
-- Table `Puntuacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Puntuacion` (
    `Fecha` TINYINT UNSIGNED NOT NULL,
    `idFutbolista` INT NOT NULL,
    `Puntaje` FLOAT NOT NULL,
    `Cargado_por` VARCHAR(45) NULL,
    PRIMARY KEY (`Fecha`, `idFutbolista`),
    INDEX `fk_Puntuacion_Futbolistas1_idx` (`idFutbolista` ASC) VISIBLE,
    CONSTRAINT `fk_Puntuacion_Futbolistas1` FOREIGN KEY (`idFutbolista`) REFERENCES `Futbolistas` (`idFutbolista`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB DEFAULT CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_as_ci;

-- -----------------------------------------------------
-- Table `Suplente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Suplente` (
    `idFutbolista` INT NOT NULL,
    `idPlantilla` INT NOT NULL,
    PRIMARY KEY (`idFutbolista`, `idPlantilla`),
    INDEX `fk_Suplente_Plantillas1_idx` (`idPlantilla` ASC) VISIBLE,
    CONSTRAINT `fk_Suplente_Futbolistas1` FOREIGN KEY (`idFutbolista`) REFERENCES `Futbolistas` (`idFutbolista`) ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT `fk_Suplente_Plantillas1` FOREIGN KEY (`idPlantilla`) REFERENCES `Plantillas` (`idPlantilla`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `Titular`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Titular` (
    `idFutbolista` INT NOT NULL,
    `idPlantilla` INT NOT NULL,
    PRIMARY KEY (`idFutbolista`, `idPlantilla`),
    INDEX `fk_Titular_Plantillas1_idx` (`idPlantilla` ASC) VISIBLE,
    CONSTRAINT `fk_Titular_Futbolistas1` FOREIGN KEY (`idFutbolista`) REFERENCES `Futbolistas` (`idFutbolista`) ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT `fk_Titular_Plantillas1` FOREIGN KEY (`idPlantilla`) REFERENCES `Plantillas` (`idPlantilla`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `Administrador`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Administrador` (
    `idUsuario` INT NOT NULL,
    `Email` VARCHAR(45) NOT NULL,
    `Nombre` VARCHAR(45) NOT NULL,
    `Apellido` VARCHAR(45) NOT NULL,
    `Nacimiento` DATE NOT NULL,
    `Contrasena` CHAR(64) NOT NULL,
    `Rol` VARCHAR(45) NOT NULL,
    PRIMARY KEY (`idUsuario`, `Email`),
    UNIQUE INDEX `Email_UNIQUE` (`Email` ASC) VISIBLE,
    CONSTRAINT `fk_Administrador_Usuario1` FOREIGN KEY (`idUsuario`) REFERENCES `Usuario` (`idUsuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB;

USE `5to_rosita_fresita`;

-- -----------------------------------------------------
-- procedure alta_usuario
-- -----------------------------------------------------

-- -----------------------------------------------------
-- procedure validar_usuario
-- -----------------------------------------------------
SET SQL_MODE = @OLD_SQL_MODE;

SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS;

SET UNIQUE_CHECKS = @OLD_UNIQUE_CHECKS;

USE `5to_rosita_fresita`;

DROP VIEW IF EXISTS PlantillaTitular;

CREATE VIEW PlantillaTitular AS
SELECT
    f.Nombre,
    f.Apodo,
    f.Nacimiento,
    f.Cotizacion,
    f.Creado_por,
    e.idEquipo,
    e.Nombre AS NombreEquipo,
    tj.idTipoDeJugador,
    tj.Tipo
FROM
    Titular t
    JOIN Futbolistas f USING (idFutbolista)
    JOIN Equipo e ON f.idEquipo = e.idEquipo
    JOIN TipoDeJugador tj ON f.idTipoDeJugador = tj.idTipoDeJugador;

DELIMITER $$

USE `5to_rosita_fresita` $$

CREATE
DEFINER=`5to_agbd`@`localhost`
TRIGGER `5to_rosita_fresita`.`encriptar_contrasena_before_insert`
BEFORE INSERT ON `5to_rosita_fresita`.`Usuario`
FOR EACH ROW
BEGIN

  SET NEW.Contrasena = SHA2(NEW.Contrasena, 256);
END $$

DELIMITER ;