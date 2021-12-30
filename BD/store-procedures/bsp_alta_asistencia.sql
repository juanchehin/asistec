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
	
END$$
DELIMITER ;