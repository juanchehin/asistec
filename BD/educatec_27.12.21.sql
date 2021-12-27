-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 27-12-2021 a las 19:08:31
-- Versión del servidor: 10.4.22-MariaDB
-- Versión de PHP: 7.3.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `educatec`
--
CREATE DATABASE IF NOT EXISTS `educatec` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `educatec`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `asistencias`
--

CREATE TABLE IF NOT EXISTS `asistencias` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Id unico de asistencia',
  `Id_personal` bigint(20) NOT NULL,
  `FechaEntrada` datetime NOT NULL,
  `FechaSalida` datetime NOT NULL,
  `Observacion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_asistencias_personal_idx` (`Id_personal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- RELACIONES PARA LA TABLA `asistencias`:
--   `Id_personal`
--       `personal` -> `Id`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `escuelas`
--

CREATE TABLE IF NOT EXISTS `escuelas` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Escuela` varchar(255) DEFAULT NULL COMMENT 'Nombre de la escuela',
  `Observaciones` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- RELACIONES PARA LA TABLA `escuelas`:
--

--
-- Volcado de datos para la tabla `escuelas`
--

INSERT INTO `escuelas` (`Id`, `Escuela`, `Observaciones`) VALUES
(1, 'Escuela Ej 1', '-'),
(2, 'Escuela Ej 2', '-'),
(3, 'Escuela Ej 3', '-');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `personal`
--

CREATE TABLE IF NOT EXISTS `personal` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'Esta tabla contendra los datos del personal el cual asiste al evento de EDUCATEC',
  `Id_Escuela` int(11) NOT NULL,
  `Apellidos` varchar(60) DEFAULT NULL COMMENT 'Apellidos de la persona la cual se le tomara la asistencia',
  `Nombres` varchar(60) DEFAULT NULL COMMENT 'Nombre de la persona la cual se carga la asistencia',
  `DNI` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_personal_Escuelas1_idx` (`Id_Escuela`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- RELACIONES PARA LA TABLA `personal`:
--   `Id_Escuela`
--       `escuelas` -> `Id`
--

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `asistencias`
--
ALTER TABLE `asistencias`
  ADD CONSTRAINT `fk_asistencias_personal` FOREIGN KEY (`Id_personal`) REFERENCES `personal` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `personal`
--
ALTER TABLE `personal`
  ADD CONSTRAINT `fk_personal_Escuelas1` FOREIGN KEY (`Id_Escuela`) REFERENCES `escuelas` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
