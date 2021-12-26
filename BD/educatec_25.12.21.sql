-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema educatec
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema educatec
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `educatec` DEFAULT CHARACTER SET utf8 ;
USE `educatec` ;

-- -----------------------------------------------------
-- Table `educatec`.`Escuelas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `educatec`.`Escuelas` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Escuela` VARCHAR(255) NULL COMMENT 'Nombre de la escuela',
  `Observaciones` VARCHAR(255) NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `educatec`.`Personal`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `educatec`.`Personal` (
  `Id` BIGINT(20) NOT NULL AUTO_INCREMENT COMMENT 'Esta tabla contendra los datos del personal el cual asiste al evento de EDUCATEC',
  `Apellidos` VARCHAR(60) NULL COMMENT 'Apellidos de la persona la cual se le tomara la asistencia',
  `Nombres` VARCHAR(60) NULL COMMENT 'Nombre de la persona la cual se carga la asistencia',
  `Escuelas_Id` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_personal_Escuelas1_idx` (`Escuelas_Id` ASC),
  CONSTRAINT `fk_personal_Escuelas1`
    FOREIGN KEY (`Escuelas_Id`)
    REFERENCES `educatec`.`Escuelas` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `educatec`.`Asistencias`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `educatec`.`Asistencias` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT 'Id unico de asistencia',
  `DNI` INT NOT NULL,
  `Id_personal` BIGINT(20) NOT NULL,
  `FechaEntrada` DATETIME NOT NULL,
  `FechaSalida` DATETIME NOT NULL,
  `Observacion` VARCHAR(255) NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_asistencias_personal_idx` (`Id_personal` ASC),
  CONSTRAINT `fk_asistencias_personal`
    FOREIGN KEY (`Id_personal`)
    REFERENCES `educatec`.`Personal` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
