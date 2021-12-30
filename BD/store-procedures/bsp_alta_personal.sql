DROP procedure IF EXISTS `bsp_alta_personal`;
DELIMITER $$
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
    
    -- Obtengo el id de la escuela seleccionada
    SET pIdEscuela = (SELECT IdEscuela FROM Escuelas WHERE Escuela = pEscuela);
    
	START TRANSACTION;
		SET pIdPersonal = 1 + (SELECT COALESCE(MAX(IdPersonal),0)
								FROM Personal);
                                
		INSERT INTO personal VALUES(pIdPersonal, pIdEscuela,pApellidos,pNombres,pDNI);
        
        SELECT 'OK' AS Mensaje;
    COMMIT;
END$$
DELIMITER ;