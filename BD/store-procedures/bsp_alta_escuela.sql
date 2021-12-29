DROP procedure IF EXISTS `bsp_alta_escuela`;
DELIMITER $$
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
END$$
DELIMITER ;