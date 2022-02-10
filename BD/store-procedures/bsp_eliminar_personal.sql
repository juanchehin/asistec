DROP procedure IF EXISTS `bsp_eliminar_personal`;
DELIMITER $$
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
END$$
DELIMITER 