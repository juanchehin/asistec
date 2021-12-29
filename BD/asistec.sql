-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         5.7.31 - MySQL Community Server (GPL)
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.2.0.6213
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para asistec
CREATE DATABASE IF NOT EXISTS `asistec` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `asistec`;

-- Volcando estructura para tabla asistec.asistencias
CREATE TABLE IF NOT EXISTS `asistencias` (
  `IdAsistencia` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Id unico de asistencia',
  `IdPersonal` bigint(20) NOT NULL,
  `HorarioEntrada` datetime NOT NULL COMMENT 'Posee el la fecha y la hora de entrada del personal',
  `HorarioSalida` datetime NOT NULL COMMENT 'Posee el la fecha y la hora de salida del personal',
  `Observacion` varchar(255) DEFAULT NULL,
  `Estado` char(1) DEFAULT NULL COMMENT 'E: Entrada\nS: Salida',
  PRIMARY KEY (`IdAsistencia`),
  KEY `fk_asistencias_personal_idx` (`IdPersonal`),
  CONSTRAINT `fk_asistencias_personal` FOREIGN KEY (`IdPersonal`) REFERENCES `personal` (`IdPersonal`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla asistec.asistencias: ~5 rows (aproximadamente)
/*!40000 ALTER TABLE `asistencias` DISABLE KEYS */;
INSERT INTO `asistencias` (`IdAsistencia`, `IdPersonal`, `HorarioEntrada`, `HorarioSalida`, `Observacion`, `Estado`) VALUES
	(1, 1, '2021-12-27 14:01:00', '2021-12-27 18:02:20', '-', NULL),
	(2, 2, '2021-12-27 14:10:22', '2021-12-27 18:03:20', '-', NULL),
	(3, 2, '2021-12-28 14:02:02', '2021-12-28 18:02:20', '-', NULL),
	(4, 2, '2021-12-28 14:01:20', '2021-12-28 18:03:20', '-', NULL),
	(5, 1, '2021-12-28 00:00:00', '2021-12-28 00:00:00', '-', NULL);
/*!40000 ALTER TABLE `asistencias` ENABLE KEYS */;

-- Volcando estructura para procedimiento asistec.bsp_alta_asistencia
DELIMITER //
CREATE PROCEDURE `bsp_alta_asistencia`(pDNI INT,pIdEscuela INT,pApellidos VARCHAR(60),pNombres VARCHAR(60))
SALIR:BEGIN
	/*
    Permite dar de alta una persona por su DNI. 
    Devuelve OK + Id o el mensaje de error en Mensaje.
    */
	DECLARE pIdPersonal, pIdAsistencia int;
	-- Manejo de error en la transacción
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		-- SHOW ERRORS;
		SELECT 'Error en la transacción. Contáctese con el administrador.' Mensaje,
				NULL AS Id;
		ROLLBACK;
	END;
    -- Controla que la categoría sea obligatoria 
	IF pDNI = '' OR pDNI IS NULL THEN
		SELECT 'Debe proveer un DNI' AS Mensaje, NULL AS Id;
		LEAVE SALIR;
    END IF;
    -- Controla que no exista un DNI repetido
	IF EXISTS(SELECT DNI FROM Personal WHERE DNI = pDNI) THEN
		SELECT 'Ya existe un DNI con ese numero' AS Mensaje;
		LEAVE SALIR;
    END IF;
	START TRANSACTION;
		SET pIdPersonal = 1 + (SELECT COALESCE(MAX(IdPersonal),0)
								FROM personal);
		SET pIdAsistencia = 1 + (SELECT COALESCE(MAX(IdAsistencia),0)
								FROM asistencias);
                                
		INSERT INTO personal VALUES(pIdPersonal, pIdEscuela,pApellidos,pNombres);
        INSERT INTO asistencias VALUES(pIdAsistencia,pIdPersonal, now(),null, '-');
        
        SELECT 'OK' AS Mensaje;
    COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento asistec.bsp_alta_escuela
DELIMITER //
CREATE PROCEDURE `bsp_alta_escuela`(pEscuela varchar(60),pObservaciones varchar(255))
SALIR:BEGIN
	/*
    Permite dar de alta una escuela controlando que el nombre no exista ya.
    Devuelve OK o el mensaje de error en Mensaje.
    */
	DECLARE pIdEscuela smallint;
	-- Manejo de error en la transacción
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		-- SHOW ERRORS;
		SELECT 'Error en la transacción. Contáctese con el administrador.' Mensaje,
				NULL AS Id;
		ROLLBACK;
	END;
    -- Controla que la escuela sea obligatoria 
	IF pEscuela = '' OR pEscuela IS NULL THEN
		SELECT 'Debe proveer un nombre para la escuela' AS Mensaje;
		LEAVE SALIR;
    END IF;
    
    -- Controla que no exista una escuela con el mismo nombre
	IF EXISTS(SELECT Escuela FROM Escuelas WHERE Escuela = pEscuela) THEN
		SELECT 'Ya existe una escuela con ese nombre' AS Mensaje;
		LEAVE SALIR;
    END IF;
    
	START TRANSACTION;
		SET pIdEscuela = 1 + (SELECT COALESCE(MAX(IdEscuela),0)
								FROM Escuelas);
                                
		INSERT INTO escuelas VALUES(pIdEscuela, pEscuela, pObservaciones);
        SELECT 'OK' AS Mensaje;
    COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento asistec.bsp_dame_asistencias_por_dia
DELIMITER //
CREATE PROCEDURE `bsp_dame_asistencias_por_dia`(pFecha date)
SALIR:BEGIN
	/*
    Permite listar las asistencias de una fecha dada, devuelve una tabla
    con el listado de los DNI, apellidos ,nombres y escuela
    */
	-- Manejo de error en la transacción
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		SHOW ERRORS;
		SELECT 'Error en la transacción. Contáctese con el administrador.' Mensaje,
				NULL AS Id;
		ROLLBACK;
	END;
    -- Controla que la fecha sea fecha
	IF pFecha = '' OR pFecha IS NULL THEN
		SELECT 'Debe proveer una fecha' AS Mensaje, NULL AS Id;
		LEAVE SALIR;
    END IF;
	
	START TRANSACTION;
		SELECT		p.DNI,p.Apellidos,p.Nombres,e.Escuela,DATE_FORMAT(a.HorarioEntrada,'%H:%i') as HorarioEntrada,DATE_FORMAT(a.HorarioSalida,'%H:%i') as HorarioSalida
		FROM		asistencias a 
					LEFT JOIN personal p on a.Idpersonal = p.IdPersonal
					LEFT JOIN escuelas e on e.IdEscuela = p.IdEscuela
		WHERE		DATE_FORMAT(a.HorarioEntrada,'%Y-%m-%d') = pFecha OR DATE_FORMAT(a.HorarioSalida,'%Y-%m-%d') = pFecha
		GROUP BY	p.IdPersonal
		ORDER BY	a.IdAsistencia asc;
		-- LIMIT 		pDesde,5;
			
		SELECT 'OK' AS Mensaje;    
    COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento asistec.bsp_listar_escuelas
DELIMITER //
CREATE PROCEDURE `bsp_listar_escuelas`()
BEGIN 
	/*
    Procedimiento que devuelve todas las escuelas de la BD
    */
    SELECT	IdEscuela,Escuela
    FROM	escuelas;    
END//
DELIMITER ;

-- Volcando estructura para tabla asistec.escuelas
CREATE TABLE IF NOT EXISTS `escuelas` (
  `IdEscuela` int(11) NOT NULL AUTO_INCREMENT,
  `Escuela` varchar(255) DEFAULT NULL COMMENT 'Nombre de la escuela',
  `Observaciones` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`IdEscuela`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla asistec.escuelas: ~9 rows (aproximadamente)
/*!40000 ALTER TABLE `escuelas` DISABLE KEYS */;
INSERT INTO `escuelas` (`IdEscuela`, `Escuela`, `Observaciones`) VALUES
	(1, 'Escuela Ej 1', '-'),
	(2, 'Escuela Ej 2', '-'),
	(3, 'Escuela Ej 3', '-'),
	(4, '54654', 'sad'),
	(5, 'sdfs', 'fdsfs'),
	(6, 'fds', 'dsf'),
	(7, 'sadas', 'sada'),
	(8, 'fdg', 'gd'),
	(9, 'Sarmiento', '456');
/*!40000 ALTER TABLE `escuelas` ENABLE KEYS */;

-- Volcando estructura para tabla asistec.personal
CREATE TABLE IF NOT EXISTS `personal` (
  `IdPersonal` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'Esta tabla contendra los datos del personal el cual asiste al evento de asistec',
  `IdEscuela` int(11) NOT NULL,
  `Apellidos` varchar(60) DEFAULT NULL COMMENT 'Apellidos de la persona la cual se le tomara la asistencia',
  `Nombres` varchar(60) DEFAULT NULL COMMENT 'Nombre de la persona la cual se carga la asistencia',
  `DNI` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdPersonal`),
  KEY `fk_personal_Escuelas1_idx` (`IdEscuela`),
  CONSTRAINT `fk_personal_Escuelas1` FOREIGN KEY (`IdEscuela`) REFERENCES `escuelas` (`IdEscuela`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla asistec.personal: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `personal` DISABLE KEYS */;
INSERT INTO `personal` (`IdPersonal`, `IdEscuela`, `Apellidos`, `Nombres`, `DNI`) VALUES
	(1, 1, 'Perez', 'Juan', 12564587),
	(2, 1, 'Gomez', 'Roberto', 3698456),
	(3, 3, 'Ruiz', 'Federico', 36541578);
/*!40000 ALTER TABLE `personal` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
