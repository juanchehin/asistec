DROP procedure IF EXISTS `bsp_alta_asistencia`;
DELIMITER $$
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
		-- SHOW ERRORS;
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
	IF EXISTS(SELECT DNI FROM Personal WHERE DNI = pDNI) THEN
		SELECT 'DNI inexistente' AS Mensaje;
		LEAVE SALIR;
    END IF;
    
    SET pIdPersonal = (SELECT IdPersonal FROM Personal WHERE DNI = pDNI);    
    
    
    IF(SELECT Estado FROM asistencias WHERE DNI = pDNI)
		START TRANSACTION;
		SET pIdAsistencia = 1 + (SELECT COALESCE(MAX(IdAsistencia),0)
								FROM asistencias);
                                
        INSERT INTO asistencias VALUES(pIdAsistencia,pIdPersonal, now(),null, '-',pEstado);
        
        SELECT 'OK' AS Mensaje;
		COMMIT;
    ELSE
		START TRANSACTION;
		SET pIdAsistencia = 1 + (SELECT COALESCE(MAX(IdAsistencia),0)
								FROM asistencias);
                                
        INSERT INTO asistencias VALUES(pIdAsistencia,pIdPersonal, now(),null, '-',pEstado);
        
        SELECT 'OK' AS Mensaje;
		COMMIT;
    END IF;
	
END$$
DELIMITER ;