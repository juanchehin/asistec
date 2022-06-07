-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         5.7.31 - MySQL Community Server (GPL)
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.3.0.6295
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
  `HorarioEntrada` datetime DEFAULT NULL COMMENT 'Posee el la fecha y la hora de entrada del personal',
  `HorarioSalida` datetime DEFAULT NULL COMMENT 'Posee el la fecha y la hora de salida del personal',
  `Observacion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`IdAsistencia`),
  KEY `fk_asistencias_personal_idx` (`IdPersonal`),
  CONSTRAINT `fk_asistencias_personal` FOREIGN KEY (`IdPersonal`) REFERENCES `personal` (`IdPersonal`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla asistec.asistencias: ~5 rows (aproximadamente)
/*!40000 ALTER TABLE `asistencias` DISABLE KEYS */;
INSERT INTO `asistencias` (`IdAsistencia`, `IdPersonal`, `HorarioEntrada`, `HorarioSalida`, `Observacion`) VALUES
	(1, 1, '2021-12-27 14:01:00', '2021-12-27 18:02:20', '-'),
	(2, 2, '2021-12-27 14:10:22', '2021-12-27 18:03:20', '-'),
	(3, 2, '2021-12-28 14:02:02', '2021-12-28 18:02:20', '-'),
	(4, 9, '2022-02-10 11:25:42', '2022-02-10 11:35:53', '-'),
	(5, 17, '2022-02-10 11:35:37', NULL, '-'),
	(6, 2, '2022-02-10 11:36:39', NULL, '-');
/*!40000 ALTER TABLE `asistencias` ENABLE KEYS */;

-- Volcando estructura para procedimiento asistec.bsp_alta_asistencia
DELIMITER //
CREATE PROCEDURE `bsp_alta_asistencia`(pDNI INT,pObservaciones VARCHAR(255))
SALIR:BEGIN
	/*
    Permite dar de alta una persona por su DNI. 
    Devuelve OK + Id o el mensaje de error en Mensaje.
    */
	DECLARE pIdAsistencia,pIdPersonal int;
	-- Manejo de error en la transacción
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		SHOW ERRORS;
		SELECT 'Error en la transacción. Contáctese con el administrador.' Mensaje,
				NULL AS Id;
		ROLLBACK;
	END;
    
    -- Controla que el DNI sea obligatoria 
	IF pDNI = '' OR pDNI IS NULL THEN
		SELECT 'Debe proveer un DNI' AS Mensaje, NULL AS Id;
		LEAVE SALIR;
    END IF;
    
    -- Controla que exista el DNI
	IF NOT EXISTS(SELECT DNI FROM Personal WHERE DNI = pDNI) THEN
		SELECT 'DNI inexistente' AS Mensaje;
		LEAVE SALIR;
    END IF;
    
    SET pIdPersonal = (SELECT IdPersonal FROM Personal WHERE DNI = pDNI);    
    
    -- Ver https://docs.google.com/document/d/10qaFXTrJuopwj8B21ujrD-4RjZO4t3I1yn5ce-WRHOo/edit?usp=sharing
    -- Si esta en estado de salida 'S' o como null (primera vez), entonces lo setea como entrada
    IF((((SELECT Estado FROM personal WHERE IdPersonal = pIdPersonal) = 'S') OR ((SELECT Estado FROM personal WHERE IdPersonal = pIdPersonal) IS NULL))) THEN
		START TRANSACTION;
			SET pIdAsistencia = 1 + (SELECT COALESCE(MAX(IdAsistencia),0)
									FROM asistencias);
									
			INSERT INTO asistencias VALUES(pIdAsistencia,pIdPersonal, now(),null, '-');
            UPDATE personal SET Estado = 'E' WHERE IdPersonal = pIdPersonal;
			
			SELECT 'OK' AS Mensaje;
		COMMIT;
    ELSE
		-- Cargo la entrada
		START TRANSACTION;
			SET pIdAsistencia = 1 + (SELECT COALESCE(MAX(IdAsistencia),0)
									FROM asistencias);
									
			-- INSERT INTO asistencias VALUES(pIdAsistencia,pIdPersonal, now(),null, '-',pEstado);
            UPDATE asistencias SET HorarioSalida = now() WHERE (IdPersonal = pIdPersonal and DATE_FORMAT(HorarioEntrada,'%Y/%m/%d') = current_date);
            UPDATE personal SET Estado = 'S' WHERE IdPersonal = pIdPersonal;
			
			SELECT 'OK' AS Mensaje;
		COMMIT;
    END IF;
	
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

-- Volcando estructura para procedimiento asistec.bsp_alta_personal
DELIMITER //
CREATE PROCEDURE `bsp_alta_personal`(pEscuela varchar(60),pApellidos varchar(60),pNombres varchar(60),pDNI int)
SALIR:BEGIN
	/*
    Permite dar de alta un personal controlando que el DNI no exista ya. 
    La da de alta al final del orden, con estado A: Activa. 
    Devuelve OK + Id o el mensaje de error en Mensaje.
    */
	DECLARE pIdPersonal smallint;
    DECLARE pIdEscuela INT;
	-- Manejo de error en la transacción
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		SHOW ERRORS;
		SELECT 'Error en la transacción. Contáctese con el administrador.' Mensaje;
		ROLLBACK;
	END;
    
    -- Controla que la DNI sea obligatoria 
	IF pDNI = '' OR pDNI IS NULL THEN
		SELECT 'Debe proveer un DNI' AS Mensaje, NULL AS Id;
		LEAVE SALIR;
    END IF;
    -- Controla que no exista DNI con el mismo numero
	IF EXISTS(SELECT DNI FROM Personal WHERE DNI = pDNI) THEN
		SELECT 'Ya existe un DNI con ese numero' AS Mensaje;
		LEAVE SALIR;
    END IF;
    
    -- Consulto si existe la escuela, si no, la creo
    IF EXISTS(SELECT Escuela FROM escuelas WHERE Escuela = pEscuela) THEN
		-- Obtengo el id de la escuela seleccionada
		SET pIdEscuela = (SELECT IdEscuela FROM Escuelas WHERE Escuela = pEscuela);
	ELSE
		SET pIdEscuela = 1 + (SELECT COALESCE(MAX(IdEscuela),0)
								FROM escuelas);
                                
		INSERT INTO escuelas VALUES(pIdEscuela,pEscuela,'-');
    END IF;
    
    
	START TRANSACTION;
		SET pIdPersonal = 1 + (SELECT COALESCE(MAX(IdPersonal),0)
								FROM Personal);
                                
		INSERT INTO personal VALUES(pIdPersonal,pIdEscuela,pApellidos,pNombres,pDNI,null);
        
        SELECT 'OK' AS Mensaje;
    COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento asistec.bsp_buscar_escuela
DELIMITER //
CREATE PROCEDURE `bsp_buscar_escuela`(pEscuela varchar(60))
BEGIN
	/*
	Permite buscar una escuela
    */
    SELECT		IdEscuela,Escuela,Observaciones
    FROM		escuelas
    WHERE		Escuela LIKE CONCAT('%',pEscuela,'%');    
END//
DELIMITER ;

-- Volcando estructura para procedimiento asistec.bsp_buscar_personal
DELIMITER //
CREATE PROCEDURE `bsp_buscar_personal`(pDNI int)
BEGIN
	/*
	Permite buscar personal por DNI
    */
    SELECT		IdPersonal,Apellidos,Nombres,DNI,Estado
    FROM		personal
    WHERE		DNI LIKE CONCAT('%',pDNI,'%');    
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
		SELECT		p.DNI,p.Apellidos,p.Nombres,e.Escuela,p.DNI,DATE_FORMAT(a.HorarioEntrada,'%H:%i') as HorarioEntrada,DATE_FORMAT(a.HorarioSalida,'%H:%i') as HorarioSalida,TIMEDIFF(a.HorarioSalida,a.HorarioEntrada ) as HorasTrabajadas
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

-- Volcando estructura para procedimiento asistec.bsp_dame_personal
DELIMITER //
CREATE PROCEDURE `bsp_dame_personal`(pIdPersonal smallint)
SALIR:BEGIN
	/*
	Procedimiento que sirve para instanciar un personal desde la base de datos.
    */
    IF NOT EXISTS(SELECT pIdPersonal FROM personal WHERE IdPersonal = pIdPersonal ) THEN
		SELECT 'El personal no existe!' AS Mensaje;
		LEAVE SALIR;
    END IF;
    
		SELECT	*
		FROM	personal
		WHERE	IdPersonal = pIdPersonal;
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento asistec.bsp_eliminar_escuela
DELIMITER //
CREATE PROCEDURE `bsp_eliminar_escuela`(pIdEscuela int)
SALIR: BEGIN
	/*
    Permite borrar una escuela controlando que no tenga personal asociado
    Reordena. Devuelve OK o el mensaje de error en Mensaje.
    */
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		SHOW ERRORS;
		SELECT 'Error en la transacción. Contáctese con el administrador.' Mensaje;
		ROLLBACK;
	END;
    -- Controla que la escuela no tenga personal
	IF EXISTS(SELECT IdEscuela FROM personal WHERE IdEscuela = pIdEscuela) THEN
		SELECT 'No puede borrar la escuela. Existe personal asociado.' AS Mensaje;
		LEAVE SALIR;
    END IF;
    
	START TRANSACTION;
        -- Borra categorías
        DELETE FROM Escuelas WHERE IdEscuela = pIdEscuela;
		
        SELECT 'OK' AS Mensaje;
	COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento asistec.bsp_eliminar_personal
DELIMITER //
CREATE PROCEDURE `bsp_eliminar_personal`(pIdPersonal int)
SALIR: BEGIN
	/*
    Permite dar de baja un personal
    Devuelve OK o el mensaje de error en Mensaje.
    */
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		SHOW ERRORS;
		SELECT 'Error en la transacción. Contáctese con el administrador.' Mensaje;
		ROLLBACK;
	END;
    
	START TRANSACTION;
        -- Borra personal
        DELETE FROM Personal WHERE IdPersonal = pIdPersonal;
		
        SELECT 'OK' AS Mensaje;
	COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento asistec.bsp_listar_asistencias
DELIMITER //
CREATE PROCEDURE `bsp_listar_asistencias`(in pDesde int)
BEGIN 
	/*
    Procedimiento que devuelve todo el personal de la BD
    */
    SELECT	p.IdPersonal,p.Apellidos,p.Nombres,p.DNI,p.Estado,
    SEC_TO_TIME(SUM(TIME_TO_SEC(TIMEDIFF(a.HorarioSalida,a.HorarioEntrada)))) TotalHoras
    FROM	personal p
    INNER JOIN asistencias a
    on p.IdPersonal = a.IdPersonal
    GROUP BY p.IdPersonal
    LIMIT 		pDesde,5;

END//
DELIMITER ;

-- Volcando estructura para procedimiento asistec.bsp_listar_escuelas
DELIMITER //
CREATE PROCEDURE `bsp_listar_escuelas`(in pDesde int)
BEGIN 
	/*
    Procedimiento que devuelve todas las escuelas de la BD
    */

		SELECT	IdEscuela,Escuela
		FROM	escuelas
		LIMIT 	pDesde,15;

		SELECT 	COUNT(IdEscuela) AS cantEscuelas
		FROM 	escuelas;
END//
DELIMITER ;

-- Volcando estructura para procedimiento asistec.bsp_listar_personal
DELIMITER //
CREATE PROCEDURE `bsp_listar_personal`(in pDesde int)
BEGIN 
	/*
    Procedimiento que devuelve todo el personal de la BD
    */
		SELECT		p.IdPersonal,p.Apellidos,p.Nombres,p.DNI,p.Estado,e.Escuela
		FROM		personal p
		inner join  escuelas e
		on 			p.IdEscuela = e.IdEscuela
		LIMIT 		pDesde,10;
        
		SELECT 	COUNT(IdPersonal) AS cantPersonal
		FROM 	personal;
END//
DELIMITER ;

-- Volcando estructura para tabla asistec.escuelas
CREATE TABLE IF NOT EXISTS `escuelas` (
  `IdEscuela` int(11) NOT NULL AUTO_INCREMENT,
  `Escuela` varchar(255) DEFAULT NULL COMMENT 'Nombre de la escuela',
  `Observaciones` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`IdEscuela`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla asistec.escuelas: ~9 rows (aproximadamente)
/*!40000 ALTER TABLE `escuelas` DISABLE KEYS */;
INSERT INTO `escuelas` (`IdEscuela`, `Escuela`, `Observaciones`) VALUES
	(1, 'Escuela Ej 1', '-'),
	(2, 'Escuela Ej 2', '-'),
	(3, 'Escuela Ej 3', '-'),
	(5, 'sdfs', 'fdsfs'),
	(9, 'Sarmiento', '456'),
	(10, 'Escuela 5', ''),
	(11, 'San jose', 'Los sarmientos'),
	(12, 'Esc1', '-'),
	(13, 'Esc2', '-'),
	(14, 'Esc3', '-');
/*!40000 ALTER TABLE `escuelas` ENABLE KEYS */;

-- Volcando estructura para tabla asistec.personal
CREATE TABLE IF NOT EXISTS `personal` (
  `IdPersonal` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'Esta tabla contendra los datos del personal el cual asiste al evento de asistec',
  `IdEscuela` int(11) NOT NULL,
  `Apellidos` varchar(60) DEFAULT NULL COMMENT 'Apellidos de la persona la cual se le tomara la asistencia',
  `Nombres` varchar(60) DEFAULT NULL COMMENT 'Nombre de la persona la cual se carga la asistencia',
  `DNI` int(11) DEFAULT NULL,
  `Estado` char(1) DEFAULT NULL COMMENT 'Indica el estado de la persona, si es que entro al ciidept o salio (segun lo marcado por la persona que maneja el sistema)\\n\\nE: Entrada\\nS: Salida\\n\\n',
  PRIMARY KEY (`IdPersonal`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla asistec.personal: ~21 rows (aproximadamente)
/*!40000 ALTER TABLE `personal` DISABLE KEYS */;
INSERT INTO `personal` (`IdPersonal`, `IdEscuela`, `Apellidos`, `Nombres`, `DNI`, `Estado`) VALUES
	(1, 1, 'Perez', 'Juan', 12564587, 'E'),
	(2, 1, 'Gomez', 'Roberto', 3698456, 'E'),
	(4, 2, 'sada', 'sadas', 123, 'S'),
	(9, 3, 'Morales', 'Mariano', 3702201, 'S'),
	(10, 9, 'Messi', 'Lionel', 25423123, NULL),
	(11, 1, 'Veron', 'Bruja', 12456457, 'S'),
	(12, 1, 'Dip', 'Hugo', 42157852, 'E'),
	(13, 1, 'Abodacier', 'Roberto', 23121544, 'E'),
	(14, 3, 'Bolati', 'Karelina', 45621157, NULL),
	(15, 10, 'Batistuta', 'Gabriel', 3554125, 'S'),
	(16, 9, 'Noblex', 'Noblex u', 12457863, NULL),
	(17, 1, 'Flores', 'Gabriela Romina', 256452, 'E'),
	(18, 1, 'Lopez', 'Gomelia', 33546875, NULL),
	(19, 5, 'Donato', 'Santino', 121222, NULL),
	(20, 1, 'asdasd1', 'asffff', 111111, NULL),
	(21, 1, 'asasdgf', 'fddf', 12123123, NULL),
	(22, 1, 'asdrw', 'xasdf', 11123451, NULL),
	(23, 12, 'Apellido12', 'Nombre12', 789785, NULL),
	(24, 12, 'Apellido1', 'Nombre1', 1111222, NULL),
	(25, 13, 'Ap2', 'Nom2', 333444, NULL),
	(26, 14, 'Ap3', 'Nom3', 55555666, NULL);
/*!40000 ALTER TABLE `personal` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;