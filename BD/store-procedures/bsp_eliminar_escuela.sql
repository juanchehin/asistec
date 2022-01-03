DROP procedure IF EXISTS `bsp_eliminar_escuela`;
DELIMITER $$
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
END$$
DELIMITER 