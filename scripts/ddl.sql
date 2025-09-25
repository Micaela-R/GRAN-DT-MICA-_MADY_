USE `5to_rosita_fresita` ;
-- MySQL Workbench Forward Engineering
SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';
-- -----------------------------------------------------
-- Schema 5to_rosita_fresita
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `5to_rosita_fresita` ;
-- -----------------------------------------------------
-- Schema 5to_rosita_fresita
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `5to_rosita_fresita` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_as_ci ;
USE `5to_rosita_fresita` ;
-- -----------------------------------------------------
-- Table `TipoDeJugador`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `TipoDeJugador` (
 `idTipoDeJugador` INT NOT NULL,
 `Tipo` VARCHAR(45) NULL,
 `idFutbolistas` VARCHAR(45) NOT NULL,
 PRIMARY KEY (`idTipoDeJugador`, `idFutbolistas`))
ENGINE = InnoDB;
-- -----------------------------------------------------
-- Table `Equipo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Equipo` (
 `idEquipo` INT NOT NULL,
 `Cantidad` TINYINT(32) NULL,
 `Nombre` VARCHAR(45) NOT NULL,
 PRIMARY KEY (`idEquipo`))
ENGINE = InnoDB;
-- -----------------------------------------------------
-- Table `Puntuacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Puntuacion` (
 `idPuntuacion` INT NOT NULL,
 `idFutbolistas` INT NOT NULL,
 `Puntaje` FLOAT NULL,
 `Fecha` DATE NOT NULL,
 `Cargado_por` VARCHAR(45) NULL,
 PRIMARY KEY (`Fecha`, `idFutbolistas`, `idPuntuacion`))
ENGINE = InnoDB;
-- -----------------------------------------------------
-- Table `Futbolistas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Futbolistas` (
 `idFutbolistas` INT NOT NULL,
 `Nombre` VARCHAR(45) NULL,
 `Apodo` VARCHAR(45) NULL,
 `Nacimiento` DATE NULL,
 `idEquipo` INT NOT NULL,
 `idTipoDeJugador` INT NOT NULL,
 `Cotizacion` DECIMAL(8,2) NULL,
 `Creado_por` VARCHAR(45) NULL,
 `TipoDeJugador_idTipoDeJugador` INT NOT NULL,
 `TipoDeJugador_idFutbolistas` VARCHAR(45) NOT NULL,
 `Equipo_idEquipo` INT NOT NULL,
 `Puntuacion_Fecha` DATE NOT NULL,
 `Puntuacion_idFutbolistas` INT NOT NULL,
 `Puntuacion_idPuntuacion` INT NOT NULL,
 PRIMARY KEY (`idFutbolistas`, `idEquipo`, `idTipoDeJugador`, `TipoDeJugador_idTipoDeJugador`, `TipoDeJugador_idFutbolistas`, `Equipo_idEquipo`, `Puntuacion_Fecha`, `Puntuacion_idFutbolistas`, `Puntuacion_idPuntuacion`),
 INDEX `fk_Futbolistas_TipoDeJugador1_idx` (`TipoDeJugador_idTipoDeJugador` ASC, `TipoDeJugador_idFutbolistas` ASC) VISIBLE,
 INDEX `fk_Futbolistas_Equipo1_idx` (`Equipo_idEquipo` ASC) VISIBLE,
 INDEX `fk_Futbolistas_Puntuacion1_idx` (`Puntuacion_Fecha` ASC, `Puntuacion_idFutbolistas` ASC, `Puntuacion_idPuntuacion` ASC) VISIBLE,
 CONSTRAINT `fk_Futbolistas_TipoDeJugador1`
   FOREIGN KEY (`TipoDeJugador_idTipoDeJugador` , `TipoDeJugador_idFutbolistas`)
   REFERENCES `TipoDeJugador` (`idTipoDeJugador` , `idFutbolistas`)
   ON DELETE NO ACTION
   ON UPDATE NO ACTION,
 CONSTRAINT `fk_Futbolistas_Equipo1`
   FOREIGN KEY (`Equipo_idEquipo`)
   REFERENCES `Equipo` (`idEquipo`)
   ON DELETE NO ACTION
   ON UPDATE NO ACTION,
 CONSTRAINT `fk_Futbolistas_Puntuacion1`
   FOREIGN KEY (`Puntuacion_Fecha` , `Puntuacion_idFutbolistas` , `Puntuacion_idPuntuacion`)
   REFERENCES `Puntuacion` (`Fecha` , `idFutbolistas` , `idPuntuacion`)
   ON DELETE NO ACTION
   ON UPDATE NO ACTION)
ENGINE = InnoDB;
-- -----------------------------------------------------
-- Table `Plantillas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Plantillas` (
 `idPlantilla` INT NOT NULL,
 `Nombre` VARCHAR(45) NULL,
 `idUsuario` VARCHAR(45) NOT NULL,
 PRIMARY KEY (`idPlantilla`, `idUsuario`))
ENGINE = InnoDB;
-- -----------------------------------------------------
-- Table `Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Usuario` (
 `idUsuario` INT NOT NULL,
 `Email` VARCHAR(45) NOT NULL,
 `Nombre` VARCHAR(45) NULL,
 `Apellido` VARCHAR(45) NULL,
 `Nacimiento` DATE NULL,
 `Contrasena` CHAR(64) NULL,
 `Plantillas_idPlantilla` INT NOT NULL,
 `Plantillas_idUsuario` VARCHAR(45) NOT NULL,
 `Tipo` VARCHAR(45) NULL,
 PRIMARY KEY (`idUsuario`, `Email`, `Plantillas_idPlantilla`, `Plantillas_idUsuario`),
 INDEX `fk_Usuario_Plantillas1_idx` (`Plantillas_idPlantilla` ASC, `Plantillas_idUsuario` ASC) VISIBLE,
 CONSTRAINT `fk_Usuario_Plantillas1`
   FOREIGN KEY (`Plantillas_idPlantilla` , `Plantillas_idUsuario`)
   REFERENCES `Plantillas` (`idPlantilla` , `idUsuario`)
   ON DELETE NO ACTION
   ON UPDATE NO ACTION)
ENGINE = InnoDB;
-- -----------------------------------------------------
-- Table `FutbolistaPlantilla`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `FutbolistaPlantilla` (
 `idFutbolista` INT NOT NULL,
 `idPlantilla` INT NOT NULL,
 PRIMARY KEY (`idFutbolista`, `idPlantilla`),
 INDEX `fk_FutbolistaPlantilla_Plantillas1_idx` (`idPlantilla` ASC) VISIBLE,
 CONSTRAINT `fk_FutbolistaPlantilla_Futbolistas1`
   FOREIGN KEY (`idFutbolista`)
   REFERENCES `Futbolistas` (`idFutbolistas`)
   ON DELETE NO ACTION
   ON UPDATE NO ACTION,
 CONSTRAINT `fk_FutbolistaPlantilla_Plantillas1`
   FOREIGN KEY (`idPlantilla`)
   REFERENCES `Plantillas` (`idPlantilla`)
   ON DELETE NO ACTION
   ON UPDATE NO ACTION)
ENGINE = InnoDB;
SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

