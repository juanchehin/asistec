DROP procedure IF EXISTS `bsp_alta_asistencia`;
DELIMITER $$
CREATE PROCEDURE `bsp_alta_asistencia`(pDNI INT,pIdEscuela INT,pApellidos VARCHAR(60),pNombres VARCHAR(60),pEstado CHAR(1))
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
        INSERT INTO asistencias VALUES(pIdAsistencia,pIdPersonal, now(),null, '-',pEstado);
        
        SELECT 'OK' AS Mensaje;
    COMMIT;
END$$
DELIMITER ;